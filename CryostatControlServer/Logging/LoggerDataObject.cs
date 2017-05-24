// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerDataObject.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the LoggerDataObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Logging
{
    /// <summary>
    /// The logger data object.
    /// </summary>
    public class LoggerDataObject
    {
        /// <summary>
        /// The abstract log data.
        /// </summary>
        private AbstractLogData abstractLogData;

        /// <summary>
        /// The file path.
        /// </summary>
        private string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerDataObject"/> class.
        /// </summary>
        /// <param name="abstractLogData">
        /// The abstract log data.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public LoggerDataObject(AbstractLogData abstractLogData, string filePath)
        {
            this.abstractLogData = abstractLogData;
            this.filePath = filePath;
        }

        /// <summary>
        /// The get abstract log data.
        /// </summary>
        /// <returns>
        /// The <see cref="AbstractLogData"/>.
        /// </returns>
        public AbstractLogData GetAbstractLogData()
        {
            return this.abstractLogData;
        }

        /// <summary>
        /// Get file path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetFilePath()
        {
            return this.filePath;
        }
    }
}
