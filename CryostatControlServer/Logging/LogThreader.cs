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

        private DataReader dataReader;

        public LogThreader(DataReader dataReader)
        {
            this.dataReader = dataReader;
        }

        public void StartSpecificDataLogging(int interval, bool[] toBeLoggedOrNotToBeLogged)
        {
            DateTime currentDateTime = DateTime.Now;
            SpecificDataLogger specificDataLogger = new SpecificDataLogger(this.dataReader, toBeLoggedOrNotToBeLogged);
            string mainFolderName = @"c:/Logging/Specific";
            string filePath = specificDataLogger.CreateFile(currentDateTime, mainFolderName);
            specificDataLogger.WriteInitialLine(filePath, toBeLoggedOrNotToBeLogged);
            Timer loggingThread = new Timer(this.SpecificDataLogging, specificDataLogger, filePath, interval);
        }

        private void SpecificDataLogging(object state)
        {
            logSpecificData.WriteDataToFile(filePath, this.dataReader.GetDataArray());
        }
    }
}
