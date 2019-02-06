using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        protected internal string Id { get; private set; }
        protected internal string UserName { get; private set; }
        protected internal NetworkStream NetworkStream { get; private set; }
        TcpClient tcpClient;       
        Server server;

        public Client(TcpClient client, Server server)
        {
            Id = Guid.NewGuid().ToString();
            tcpClient = client;
            this.server = server;
            server.AddConection(this);
        }
        protected internal void Process()
        {
            try
            {
                NetworkStream = tcpClient.GetStream();
                string message;
                while (!GetUserName())
                {
                    NetworkStream = tcpClient.GetStream();
                }
                try
                {
                    while(true)
                    {
                        NetworkStream = tcpClient.GetStream();
                        message = $"{UserName}: {GetMessage()}";
                        server.BroadcastMessages(message, this.Id);
                        Console.WriteLine(message);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }            
            finally
            {
                server.CloseConection(Id);
                Close();
            }
        }
        string GetMessage()
        {
            byte[] messageData = new byte[64];
            int bytes = 0;
            StringBuilder sb = new StringBuilder();
            do
            {
                bytes = NetworkStream.Read(messageData, 0, messageData.Length);
                sb.Append(Encoding.Unicode.GetString(messageData, 0, bytes));
            }
            while (NetworkStream.DataAvailable);
            return sb.ToString();
        }
        bool GetUserName()
        {
            string temp = GetMessage();
            if (temp.StartsWith("#UN#"))
            {
                UserName = temp.Substring(4);
                return true;
            }
            return false;
        }

        protected internal void Close()
        {
            if( tcpClient != null)
            {
                tcpClient.Close();
            }
            if( NetworkStream != null)
            {
                NetworkStream.Close();
            }
        }
    }
}
