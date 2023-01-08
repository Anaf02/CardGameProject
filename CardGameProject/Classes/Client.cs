using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CardGameProject.Classes
{
    internal class Client
    {
        public TcpClient TcpClient { get; set; }

        public Client()
        {
            TcpClient = new TcpClient();
        }

        public void Connect(string IP, Int32 port)
        {
            TcpClient.Connect(IPAddress.Parse(IP), port);
        }

        public void Write(string data)
        {
            if (TcpClient.Connected)
            {
                BinaryWriter binaryWriter = new BinaryWriter(TcpClient.GetStream());
                binaryWriter.Write(data);
                binaryWriter.Flush();
            }
        }

        public string Read()
        {
            BinaryReader binaryReader = new BinaryReader(TcpClient.GetStream());
            if (TcpClient.Connected)
            {
                return binaryReader.ReadString();
            }

            throw new Exception("Client not connected");
        }
    }
}
