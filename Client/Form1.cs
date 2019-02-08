using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private const string host = "127.0.0.1";
        private const int port = 8888;
        static bool stopReciving;
        static string userName;
        static string nameTag = "#UN#";
        Thread receiveThread;
        static TcpClient client;
        static NetworkStream networkStream;
        public Form1()
        {
            InitializeComponent();
            stopReciving = false;
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            //Monitor.Enter(networkStream);
            //receiveThread.Suspend();
            //Disconect();
            //stopReciving = true;
            //receiveThread.Resume();
            //Disconect();
            //Monitor.Exit(networkStream);
            Dispose();
        }

        private void btn_JoinChat_Click(object sender, EventArgs e)
        {
            if(tb_UserName.Text != "")
            {
                tb_UserName.ReadOnly = true;
                btn_JoinChat.Enabled = false;

                client = new TcpClient();
                try
                {
                    client.Connect(host, port);
                    networkStream = client.GetStream();

                    userName = tb_UserName.Text;
                    byte[] data = Encoding.Unicode.GetBytes(nameTag + userName);
                    networkStream.Write(data, 0, data.Length);

                    receiveThread = new Thread(ReceiveMessages);
                    receiveThread.IsBackground = true;
                    receiveThread.Start();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't jon to chat " + ex.Message);
                }
                finally
                {

                }
            }
        }

        private void btn_SendMsg_Click(object sender, EventArgs e)
        {
            string message = tb_sendMsg.Text;
            rtb_MsgBox.Text += message + Environment.NewLine;
            sendMessage(message);
            tb_sendMsg.Text = "";
        }

        private void sendMessage(string message)
        {
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(message);
                networkStream.Write(data, 0, data.Length);
            }
            catch(Exception e)
            {
                MessageBox.Show("Can't send message " + e.Message);
            }
        }
        void ReceiveMessages()
        {
            while (!stopReciving)
            {
                try
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = networkStream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (networkStream.DataAvailable);

                    string message = builder.ToString();

                    Action action = () =>
                    {
                        rtb_MsgBox.Text += message + Environment.NewLine;
                    };
                    Invoke(action);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Can't receive message " + e.Message);
                    Disconect();
                }
                finally
                {
                }
            }
            Disconect();
        }

        void Disconect()
        {
            if(networkStream != null)
            {
                networkStream.Close();
            }
            if(client != null)
            {
                client.Close();
            }
        }

       
    }
}
