using System;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlServer.Streams
{
    internal class ManagedStream
    {
        private readonly TimeSpan TCP_TIMEOUT = TimeSpan.FromMilliseconds(1000);

        private ConnectionType _connectionType = ConnectionType.NONE;

        private StreamReader _reader;
        private SerialPort _serialPort;

        private readonly TcpClient _tcpClient = new TcpClient();
        private StreamWriter _writer;
        public Stream ContainedStream { get; set; }

        /// <summary>
        ///     Connect to a (remote) TCP port.
        ///     Must be called before calling any other method.
        /// </summary>
        /// <param name="ip">The ip adress to connect to.</param>
        /// <param name="port">The TCP port to connect to.</param>
        /// <exception cref="System.TimeoutException">TCP Connection timed out</exception>
        public void ConnectTCP(string ip, int port)
        {
            var connectTask = _tcpClient.ConnectAsync(IPAddress.Parse(ip), port);
            Console.WriteLine("Connecting to port...");
            if (!connectTask.Wait(TCP_TIMEOUT))
                throw new TimeoutException("TCP Connection timed out");

            _tcpClient.SendTimeout = 1000;
            _tcpClient.ReceiveTimeout = 1000;
            ContainedStream = _tcpClient.GetStream();

            

            _connectionType = ConnectionType.TCP;
            Init();
        }

        /// <summary>
        ///     Connect to a COM port and setup the stream.
        ///     Must be called before calling any other method
        /// </summary>
        /// <param name="portname">The portname.</param>
        /// <param name="boudrate">The boudrate.</param>
        public void ConnectCOM(string portname, int boudrate)
        {
            _serialPort = new SerialPort(portname, boudrate);
            _serialPort.DataBits = 7;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.Odd;
            _serialPort.Handshake = Handshake.None;
            _serialPort.Open();
            ContainedStream = _serialPort.BaseStream;

            _connectionType = ConnectionType.COM;
            Init();
        }

        /// <summary>
        ///     Closes the connection.
        /// </summary>
        public void Close()
        {
            ContainedStream.Flush();
            switch (_connectionType)
            {
                case ConnectionType.NONE: return;
                case ConnectionType.TCP:
                    _tcpClient.Close();
                    return;
                case ConnectionType.COM:
                    _serialPort.Close();
                    return;
            }
        }

        /// <summary>
        ///     Initialisation code shared by connectTCP and connectCOM.
        /// </summary>
        private void Init()
        {
            _reader = new StreamReader(ContainedStream, Encoding.ASCII, false, 1024, true);
            _writer = new StreamWriter(ContainedStream, Encoding.ASCII, 1024, true);
        }

        /// <summary>
        ///     Determines whether this instance is connected.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConnected()
        {
            switch (_connectionType)
            {
                case ConnectionType.NONE: return false;
                case ConnectionType.TCP: return _tcpClient.Connected;
                case ConnectionType.COM: return _serialPort.IsOpen;
            }
            return false;
        }

        /// <summary>
        ///     Writes a string to the device. Does not add a terminator.
        /// </summary>
        /// <param name="stringToWrite">The string to write.</param>
        public void WriteString(string stringToWrite)
        {
#if (DEBUG)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(stringToWrite);
                Console.ForegroundColor = ConsoleColor.White;
            }
#endif
            if (IsConnected())
            {
                _writer.Write(stringToWrite);
                _writer.Flush();
            }
        }


        /// <summary>
        ///     Reads a complete line from the port.
        ///     Reads until either a newline (\n), carriage return (\r) or combination. The terminator is not included.
        /// </summary>
        /// <returns> The read string</returns>
        public string ReadString()
        {
            var res = _reader.ReadLine();
#if (DEBUG)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(res);
                Console.ForegroundColor = ConsoleColor.White;
            }
#endif
            return res;
        }

        /// <summary>
        ///     Reads the string asynchronous. Same as ReadString
        /// </summary>
        /// <returns>the read string</returns>
        public async Task<string> ReadStringAsync()
        {
            var res = await _reader.ReadLineAsync();
#if (DEBUG)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(res);
                Console.ForegroundColor = ConsoleColor.White;
            }
#endif
            return res;
        }


        private enum ConnectionType
        {
            NONE,
            TCP,
            COM
        }
    }
}