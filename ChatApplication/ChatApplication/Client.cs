using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ChatApplication
{
    class Client
    {
        private TcpClient client;
        private NetworkStream stream;
        public delegate void PrintTextDelegate(String input);
        private PrintTextDelegate printTextDelegate;

        public Client(IPAddress ipAddress, int port, PrintTextDelegate printTextDelegate)
        {
            this.printTextDelegate = printTextDelegate;

            IPEndPoint _endpoint = new IPEndPoint(ipAddress, port);
            Thread _t = new Thread(delegate ()
            {
                client = new TcpClient();
                client.Connect(_endpoint);
                stream = client.GetStream();
                printTextDelegate("Connected!");
            });
            _t.Start();
        }

        public void SendMessage(string message)
        {
            byte[] _byteArray = new byte[1024];

            _byteArray = Encoding.ASCII.GetBytes(message);
            stream.Write(_byteArray, 0, _byteArray.Length);
            printTextDelegate(message);
        }
    }
}
