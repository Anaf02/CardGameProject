using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CardGameProject.Classes
{
    internal class Client
    {
        public TcpClient tcpClient { get; set; }

        public Client()
        {
            tcpClient = new TcpClient();
        }

        public void Connect(string IP, Int32 port)
        {
            tcpClient.Connect(IPAddress.Parse(IP), port);
        }

        public void Write(string data)
        {
            if (tcpClient.Connected)
            {
                BinaryWriter binaryWriter = new BinaryWriter(tcpClient.GetStream());
                binaryWriter.Write(data);
                binaryWriter.Flush();
            }
        }

        public string Read()
        {
            BinaryReader binaryReader = new BinaryReader(tcpClient.GetStream());
            if (tcpClient.Connected)
            {
                return binaryReader.ReadString();
            }

            throw new Exception("Client not connected");
        }
    }
}