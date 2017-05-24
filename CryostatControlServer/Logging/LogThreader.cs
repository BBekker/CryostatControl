// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogThreader.cs" company="SRON">
// k
// </copyright>
// <summary>
//   Defines the LogThreader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.Logging
{
    using System;
    using System.Threading;

    using CryostatControlServer.Data;

    public class LogThreader
    {
        #region Fields

        private DataReader dataReader;

        #endregion Fields

        #region Constructors

        public LogThreader(DataReader dataReader)
        {
            this.dataReader = dataReader;
        }

        #endregion Constructors

        #region Methods

        public void StartSpecificDataLogging(int interval, bool[] toBeLoggedOrNotToBeLogged)
        {
            DateTime currentDateTime = DateTime.Now;
            SpecificDataLogger specificDataLogger = new SpecificDataLogger(this.dataReader, toBeLoggedOrNotToBeLogged);
            string mainFolderName = @"c:/Logging/Specific";
            string filePath = specificDataLogger.CreateFile(currentDateTime, mainFolderName);
            specificDataLogger.WriteInitialLine(filePath, toBeLoggedOrNotToBeLogged);
            Timer loggingThread = new Timer(this.SpecificDataLogging, specificDataLogger, filePath, interval);
        }

        public void StopSpecificDataLogging()
        {
        }

        public void StartGeneralDataLogging()
        {
        }

        private void SpecificDataLogging(object state)
        {
            logSpecificData.WriteDataToFile(filePath, this.dataReader.GetDataArray());
        }

        #endregion Methods
    }
}