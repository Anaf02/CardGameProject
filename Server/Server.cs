using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        public TcpListener tcpListener { get; set; }

        public TcpClient Client1 { get; set;}

        public TcpClient Client2 { get; set;}

        public string Player1Name { get; set; }

        public string Player2Name { get; set; }

        public Server(Int32 portNumber) 
        {
            tcpListener = new TcpListener(IPAddress.Any, portNumber);
        }

        public void StartServer()
        {
            tcpListener.Start();
        }

        public bool AcceptConnection()
        {
            if (Client1 == null)
            {
                Client1 = tcpListener.AcceptTcpClient();
                BinaryReader binaryReader = new BinaryReader(Client1.GetStream());
                Player1Name = binaryReader.ReadString();
                return Client1.Connected;
            }
            else if (Client2 == null)
            {
                Client2 = tcpListener.AcceptTcpClient();
                BinaryReader binaryReader = new BinaryReader(Client2.GetStream());
                Player2Name = binaryReader.ReadString();
                return Client2.Connected;
            }
            return false ;
        }

        public void Disconnect()
        {
            Client1.Close();
            Client2.Close();
        }

        public void StopServer()
        {
            tcpListener.Stop();
        }

        public void StartGame()
        {
            string start = "start";
            BinaryWriter binaryWriter1 = new BinaryWriter(Client1.GetStream());
            BinaryWriter binaryWriter2 = new BinaryWriter(Client2.GetStream());
            binaryWriter1.Write($"name!2!{Player2Name}");
            binaryWriter2.Write($"name!1!{Player1Name}");
            binaryWriter1.Flush();
            binaryWriter2.Flush();

            binaryWriter1.Write(start);
            binaryWriter1.Flush();

        }

        public void TransferData()
        {
            NetworkStream networkStream1 = Client1.GetStream();
            NetworkStream networkStream2 = Client2.GetStream();
            while (Client1.Connected && Client2.Connected)
            {
                if (networkStream1.DataAvailable)
                {
                    networkStream1.CopyTo(networkStream2);
                }
                if (networkStream2.DataAvailable)
                {
                    networkStream2.CopyTo(networkStream1);
                }
            }
        }

        public static IPAddress GetPcAddress()
        {
            var ipAddressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            IPAddress ipAddress = IPAddress.Any;
            foreach (var address in ipAddressList)
            {
                if (address.AddressFamily.Equals(AddressFamily.InterNetwork))
                    ipAddress = address;
            }
            return ipAddress;
        }
    }
}
