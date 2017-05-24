// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManagedCOMStream.cs" company="SRON">
//   blabla copyright.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
// ManagedCOMStream
// ManagedCOMStream is an implementation of IManagedStream to communicate to a Serial Port. It tries to handle as many common issues as possible.
// Methods are not re-entrant, since most devices are neither. THe code calling methods in this class should take care to only issue one command at the time.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Streams
{
    using System.IO;
    using System.IO.Ports;

    /// <summary>
    /// ManagedCOMStream
    /// ManagedCOMStream is an implementation of IManagedStream to communicate to a Serial Port. It tries to handle as many common issues as possible.
    /// Methods are not re-entrant, since most devices are neither. THe code calling methods in this class should take care to only issue one command at the time.
    /// </summary>
    internal class ManagedCOMStream : BaseManagedStream
    {
        /// <summary>
        /// The baud rate of the com port.
        /// </summary>
        private readonly int baudRate;

        /// <summary>
        /// The port name.
        /// </summary>
        private readonly string portname;

        /// <summary>
        /// The serial port.
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedCOMStream"/> class.
        /// </summary>
        /// <param name="portname">The port name.</param>
        /// <param name="baudRate">The baud rate.</param>
        public ManagedCOMStream(string portname, int baudRate)
        {
            this.portname = portname;
            this.baudRate = baudRate;
        }

        /// <summary>
        ///     Closes the connection.
        /// </summary>
        public override void Close()
        {
            this.ContainedStream.Flush();
            this.serialPort.Close();
        }

        /// <summary>
        ///     Determines whether this instance is connected.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsConnected()
        {
            return this.serialPort.IsOpen;
        }

        /// <summary>
        ///     Connect to a COM port and setup the stream.
        ///     Must be called before calling any other method
        /// </summary>
        public override void Open()
        {
            this.serialPort =
                new SerialPort(this.portname, this.baudRate)
                    {
                        DataBits = 7,
                        StopBits = StopBits.One,
                        Parity = Parity.Odd,
                        Handshake = Handshake.None
                    };
            this.serialPort.Open();
            this.ContainedStream = this.serialPort.BaseStream;
            this.ContainedStream.ReadTimeout = 2000;
            this.Init();
        }
    }
}