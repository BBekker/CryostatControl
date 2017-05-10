// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagedStream.cs" company="SRON">
//   blabla copyright.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   ManagedStream
//   ManagedStream is a standerdized class to communicate to a TCP or Serial Port. It tries to handle as many common issues as possible.
//   Methods are not re-entrant, since most devices are neither. THe code calling methods in this class should take care to only issue one command at the time.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Streams
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.IO.Ports;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// ManagedStream
    /// ManagedStream is a standardized class to communicate to a TCP or Serial Port. It tries to handle as many common issues as possible.
    /// Methods are not re-entrant, since most devices are neither. THe code calling methods in this class should take care to only issue one command at the time.
    /// </summary>
    internal class ManagedStream
    {
        /// <summary>
        /// The tcp timeout.
        /// </summary>
        private readonly TimeSpan tcpTimeout = TimeSpan.FromMilliseconds(1000);

        /// <summary>
        /// The tcp client.
        /// </summary>
        private readonly TcpClient tcpClient = new TcpClient();

        /// <summary>
        /// The connection type.
        /// </summary>
        private ConnectionType connectionType = ConnectionType.NONE;

        /// <summary>
        /// The reader.
        /// </summary>
        private StreamReader reader;

        /// <summary>
        /// The serial port.
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// The stream writer.
        /// </summary>
        private StreamWriter writer;

        /// <summary>
        /// the contained stream.
        /// </summary>
        private Stream containedStream;

        /// <summary>
        /// The connection type.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
        private enum ConnectionType
        {
            NONE,
            TCP,
            COM
        }

        /// <summary>
        ///     Connect to a (remote) TCP port.
        ///     Must be called before calling any other method.
        /// </summary>
        /// <param name="ip">The ip adress to connect to.</param>
        /// <param name="port">The TCP port to connect to.</param>
        /// <exception cref="System.TimeoutException">TCP Connection timed out</exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public void ConnectTCP(string ip, int port)
        {
            var connectTask = this.tcpClient.ConnectAsync(IPAddress.Parse(ip), port);
            Console.WriteLine("Connecting to port...");
            if (!connectTask.Wait(this.tcpTimeout))
            {
                throw new TimeoutException("TCP Connection timed out");
            }

            this.tcpClient.SendTimeout = 1000;
            this.tcpClient.ReceiveTimeout = 1000;
            this.containedStream = this.tcpClient.GetStream();

            this.connectionType = ConnectionType.TCP;
            this.Init();
        }

        /// <summary>
        ///     Connect to a COM port and setup the stream.
        ///     Must be called before calling any other method
        /// </summary>
        /// <param name="portname">The portname.</param>
        /// <param name="boudrate">The boudrate.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        // ReSharper disable once InconsistentNaming
        public void ConnectCOM(string portname, int boudrate)
        {
            this.serialPort = new SerialPort(portname, boudrate);
            this.serialPort.DataBits = 7;
            this.serialPort.StopBits = StopBits.One;
            this.serialPort.Parity = Parity.Odd;
            this.serialPort.Handshake = Handshake.None;
            this.serialPort.Open();
            this.containedStream = this.serialPort.BaseStream;

            this.connectionType = ConnectionType.COM;
            this.Init();
        }

        /// <summary>
        ///     Closes the connection.
        /// </summary>
        public void Close()
        {
            this.containedStream.Flush();
            switch (this.connectionType)
            {
                case ConnectionType.NONE: return;
                case ConnectionType.TCP:
                    this.tcpClient.Close();
                    return;
                case ConnectionType.COM:
                    this.serialPort.Close();
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///     Determines whether this instance is connected.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConnected()
        {
            switch (this.connectionType)
            {
                case ConnectionType.NONE: return false;
                case ConnectionType.TCP: return this.tcpClient.Connected;
                case ConnectionType.COM: return this.serialPort.IsOpen;
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
            this.writer.Write(stringToWrite);
            this.writer.Flush();      
        }

        /// <summary>
        ///     Reads a complete line from the port.
        ///     Reads until either a newline (\n), carriage return (\r) or combination. The terminator is not included.
        /// </summary>
        /// <returns> The read string</returns>
        public string ReadString()
        {
            var res = this.reader.ReadLine();
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
            var res = await this.reader.ReadLineAsync();
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
        ///     Initialization code shared by connectTCP and connectCOM.
        /// </summary>
        private void Init()
        {
            this.reader = new StreamReader(this.containedStream, Encoding.ASCII, false, 1024, true);
            this.writer = new StreamWriter(this.containedStream, Encoding.ASCII, 1024, true);
        }
    }
}