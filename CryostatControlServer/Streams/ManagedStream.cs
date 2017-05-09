using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Stream containedStream { get; set; }

        private TcpClient tcpClient = new TcpClient();
        private SerialPort serialPort;

        private readonly TimeSpan TCP_TIMEOUT = TimeSpan.FromMilliseconds(1000);
        private byte[] readbuffer = new byte[1024];

        private StreamReader reader;
        private StreamWriter writer;

        private const bool DEBUG = true;
        

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

            tcpClient.SendTimeout = 1000;
            tcpClient.ReceiveTimeout = 1000;
            containedStream = tcpClient.GetStream();
            
            connectionType = ConnectionType.TCP;
            init();
        }

        public void ConnectCOM(string portname, int boudrate)
        {
            serialPort = new SerialPort(portname, boudrate);
            serialPort.DataBits = 7;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.Odd;
            serialPort.Handshake = Handshake.None;
            serialPort.Open();
            containedStream = serialPort.BaseStream;

            connectionType = ConnectionType.COM;
            init();
        }

        public void close()
        {
            switch (connectionType)
            {
                case ConnectionType.NONE: return;
                case ConnectionType.TCP: tcpClient.Close();
                    return;
                case ConnectionType.COM: serialPort.Close();
                    return;
            }
        }

        private void init()
        {
            reader = new StreamReader(containedStream, Encoding.ASCII, false, 1024, true);
            writer = new StreamWriter(containedStream, Encoding.ASCII, 1024, true);
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
            if (DEBUG)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(stringToWrite);
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (isConnected())
            {
                writer.Write(stringToWrite);
                writer.Flush();
            }

        }


        //TODO: modify read to read until a \r\n or \n
        public string ReadString()
        {
            string res = reader.ReadLine();
            if (DEBUG)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(res);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return res;
        }

        public async Task<string> ReadStringAsync()
        {
            string res = await reader.ReadLineAsync();
            if (DEBUG)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(res);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return res;
        }

    }
}
