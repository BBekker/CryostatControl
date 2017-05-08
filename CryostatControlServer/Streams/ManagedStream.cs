using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlServer.Streams
{
    class ManagedStream
    {
        private Stream containedStream;

        private TcpClient tcpClient = new TcpClient();
        private SerialPort serialPort;

        private readonly TimeSpan TCP_TIMEOUT = TimeSpan.FromMilliseconds(1000);
        private byte[] readbuffer = new byte[1024];


        enum ConnectionType
        {
            NONE,
            TCP,
            COM
        }

        private ConnectionType connectionType = ConnectionType.NONE;

        public void ConnectTCP(string ip, int port)
        {
            Task connectTask = tcpClient.ConnectAsync(IPAddress.Parse(ip), port);
            Console.WriteLine("Connecting to port...");
            if (!connectTask.Wait(TCP_TIMEOUT))
            {
                throw new TimeoutException("TCP Connection timed out");
            }

            tcpClient.SendTimeout = 500;
            tcpClient.ReceiveTimeout = 500;
            containedStream = tcpClient.GetStream();
            
            connectionType = ConnectionType.TCP;
        }

        public void ConnectCOM(string portname, int boudrate)
        {
            serialPort = new SerialPort(portname, boudrate);
            serialPort.Open();
            containedStream = serialPort.BaseStream;

            connectionType = ConnectionType.COM;
        }


        public bool isConnected()
        {
            switch (connectionType)
            {
                    case ConnectionType.NONE: return false;
                    case ConnectionType.TCP: return tcpClient.Connected;
                    case ConnectionType.COM: return serialPort.IsOpen;
            }
            return false;
        }

        public void WriteString(string stringToWrite)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(stringToWrite);
            if (isConnected())
            {
                containedStream.Write(buffer, 0, stringToWrite.Length);
            }

        }


        //TODO: modify read to read until a \r\n or \n
        public string ReadString()
        {
            int bytes = containedStream.Read(readbuffer, 0, 1024);
            string res = Encoding.ASCII.GetString(readbuffer, 0, bytes);
            return res;
        }

        public async Task<string> ReadStringAsync()
        {
            int bytes = await containedStream.ReadAsync(readbuffer, 0, 1024);
            string res = Encoding.ASCII.GetString(readbuffer, 0, bytes);
            return res;
        }

    }
}
