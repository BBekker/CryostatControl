// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagedTcpStream.cs" company="SRON">
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
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// ManagedStream
    /// ManagedStream is a standardized class to communicate to a TCP or Serial Port. It tries to handle as many common issues as possible.
    /// Methods are not re-entrant, since most devices are neither. THe code calling methods in this class should take care to only issue one command at the time.
    /// </summary>
    public class ManagedTcpStream : BaseManagedStream
    {
        /// <summary>
        /// The port.
        /// </summary>
        private readonly int port;

        /// <summary>
        /// The TCP client.
        /// </summary>
        private readonly TcpClient tcpClient = new TcpClient();

        /// <summary>
        /// The TCP timeout.
        /// </summary>
        private readonly TimeSpan tcpTimeout = TimeSpan.FromMilliseconds(5000);

        /// <summary>
        /// The IP.
        /// </summary>
        private string ip;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedTcpStream"/> class.
        /// </summary>
        /// <param name="ip">
        /// The IP.
        /// </param>
        /// <param name="port">
        /// The port.
        /// </param>
        public ManagedTcpStream(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        /// <summary>
        ///     Closes the connection.
        /// </summary>
        public override void Close()
        {
            this.ContainedStream.Flush();
            this.tcpClient.Close();
            return;
        }

        /// <summary>
        ///     Determines whether this instance is connected.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsConnected()
        {
            return this.tcpClient.Connected;
        }

        /// <summary>
        ///     Connect to a (remote) TCP port.
        ///     Must be called before calling any other method.
        /// </summary>
        /// <exception cref="System.TimeoutException">TCP Connection timed out</exception>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        public override void Open()
        {
            var connectTask = this.tcpClient.ConnectAsync(IPAddress.Parse(this.ip), this.port);
            Console.WriteLine("Connecting to port...");
            if (!connectTask.Wait(this.tcpTimeout))
            {
                throw new TimeoutException("TCP Connection timed out");
            }

            this.tcpClient.SendTimeout = (int)this.tcpTimeout.TotalMilliseconds;
            this.tcpClient.ReceiveTimeout = (int)this.tcpTimeout.TotalMilliseconds;
            this.ContainedStream = this.tcpClient.GetStream();

            this.Init();
        }
    }
}