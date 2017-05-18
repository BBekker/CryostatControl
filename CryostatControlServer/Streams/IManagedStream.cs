// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IManagedStream.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   Defines the IManagedStream type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Streams
{
    using System.Threading.Tasks;

    /// <summary>
    /// The ManagedStream interface.
    /// </summary>
    public interface IManagedStream
    {
        /// <summary>
        /// Close the connections.
        /// </summary>
        void Close();

        /// <summary>
        /// Is the stream connected?
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsConnected();

        /// <summary>
        /// Open the connection.
        /// </summary>
        void Open();

        /// <summary>
        /// The read string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string ReadString();

        /// <summary>
        /// The read string async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<string> ReadStringAsync();

        /// <summary>
        /// The write string.
        /// </summary>
        /// <param name="stringToWrite">string to write to the device</param>
        void WriteString(string stringToWrite);
    }
}