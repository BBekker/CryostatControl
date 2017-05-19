// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseManagedStream.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   Defines the BaseManagedStream type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Streams
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The base managed stream.
    /// </summary>
    public abstract class BaseManagedStream : IManagedStream
    {
        #region Fields

        /// <summary>
        /// The buffer size of the reader and writer.
        /// </summary>
        private const int BufferSize = 1024;

        /// <summary>
        /// The reader.
        /// </summary>
        private StreamReader reader;

        /// <summary>
        /// The stream writer.
        /// </summary>
        private StreamWriter writer;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the contained stream.
        /// </summary>
        protected Stream ContainedStream { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The open.
        /// </summary>
        public abstract void Open();

        /// <summary>
        /// The close.
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// The is connected.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public abstract bool IsConnected();

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

            //#if (DEBUG)
            //            {
            //                Console.ForegroundColor = ConsoleColor.Green;
            //                Console.Write(res);
            //                Console.ForegroundColor = ConsoleColor.White;
            //            }
            //#endif
            return res;
        }

        /// <summary>
        ///     Reads the string asynchronous. Same as ReadString
        /// </summary>
        /// <returns>the read string</returns>
        public async Task<string> ReadStringAsync()
        {
            var res = await this.reader.ReadLineAsync();

            //#if (DEBUG)
            //            {
            //                Console.ForegroundColor = ConsoleColor.Green;
            //                Console.Write(res);
            //                Console.ForegroundColor = ConsoleColor.White;
            //            }
            //#endif
            return res;
        }

        /// <summary>
        ///     Initialization code shared by connectTCP and connectCOM.
        /// </summary>
        internal void Init()
        {
            this.reader = new StreamReader(this.ContainedStream, Encoding.ASCII, false, BufferSize, true);
            this.writer = new StreamWriter(this.ContainedStream, Encoding.ASCII, BufferSize, true);
        }

        #endregion Methods
    }
}