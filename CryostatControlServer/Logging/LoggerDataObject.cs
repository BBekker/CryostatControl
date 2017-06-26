// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerDataObject.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
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
        private AbstractDataLogger abstractDataLogger;

        /// <summary>
        /// The file path.
        /// </summary>
        private string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerDataObject"/> class.
        /// </summary>
        /// <param name="abstractDataLogger">
        /// The abstract log data.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public LoggerDataObject(AbstractDataLogger abstractDataLogger, string filePath)
        {
            this.abstractDataLogger = abstractDataLogger;
            this.filePath = filePath;
        }

        /// <summary>
        /// The get abstract log data.
        /// </summary>
        /// <returns>
        /// The <see cref="AbstractDataLogger" />.
        /// </returns>
        public AbstractDataLogger GetAbstractLogData()
        {
            return this.abstractDataLogger;
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
