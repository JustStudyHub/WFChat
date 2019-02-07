using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        static TcpListener tcpListener;
        List<Client> clients = new List<Client>();

        protected internal void Listen()
        {            
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("Server started");
                while(true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    Client client = new Client(tcpClient, this);
                    Thread clientThread = new Thread(client.Process);
                    clientThread.Start();
                }
            }
            catch(Exception e )
            {
                Console.WriteLine(e.Message);
            }
        }
        protected internal void AddConection(Client client)
        {
            clients.Add(client);
        }

        protected internal void CloseConection(string id)
        {
            Client client = clients.FirstOrDefault(c => c.Id == id);
            if(client != null)
            {
                client.Close();
                clients.Remove(client);
            }
        }

        protected internal void BroadcastMessages(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id)
                {
                    clients[i].NetworkStream.Write(data, 0, data.Length);
                }
            }
        }

        protected internal void StopServer()
        {
            BroadcastMessages("Server stoped", "");
            tcpListener.Stop();
            foreach(Client c in clients)
            {
                c.Close();
            }
            Environment.Exit(0);
        }
    }
}
