using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static Thread serverThread;
        static Server server;
        static void Main(string[] args)
        {
            try
            {
                server = new Server();
                serverThread = new Thread(server.Listen);
                serverThread.Start();
            }
            catch(Exception e)
            {
                server.StopServer();
                Console.WriteLine(e.Message);
            }
        }
    }
}
