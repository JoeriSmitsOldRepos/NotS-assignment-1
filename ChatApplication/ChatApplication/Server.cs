using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatApplication
{
    class Server
    {
        private int port;
        private IPAddress ipAddress = IPAddress.Any;
        private TcpListener server;
        public delegate void PrintTextDelegate(String input);

        public Server(int port)
        {
            this.port = port;
            IPEndPoint _endpoint = new IPEndPoint(ipAddress, port);
            server = new TcpListener(_endpoint);
        }

        public void Start()
        {
            server.Start();
        }

        public void ReceiveData(PrintTextDelegate PrintTextDelegate)
        {
            byte[] _byteArray = new byte[1024];
            string _data;
            Thread _t = new Thread(delegate ()
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                PrintTextDelegate("Connected!");

                bool listen = true;
                while (listen)
                {
                    int i;
                    i = stream.Read(_byteArray, 0, _byteArray.Length);

                    // Translate data bytes to a ASCII string.
                    _data = Encoding.ASCII.GetString(_byteArray);

                    if(_data == "bye")
                    {
                        listen = false;
                    }

                    PrintTextDelegate(_data);

                    // Clearing the variables
                    _data = null;
                    Array.Clear(_byteArray, 0, _byteArray.Length);
                }

                _byteArray = Encoding.ASCII.GetBytes("bye");
                stream.Write(_byteArray, 0, _byteArray.Length);

                stream.Close();
                client.Close();
                PrintTextDelegate("Connection closed.");
            });
            _t.Start();
        }
    }
}
