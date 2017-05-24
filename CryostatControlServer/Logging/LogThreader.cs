﻿// --------------------------------------------------------------------------------------------------------------------
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

        public void StartSpecificDataLogging(int interval, double[] toBeLoggedOrNotToBeLogged)
        {
            DateTime currentDateTime = DateTime.Now;
            SpecificDataLogger specificDataLogger = new SpecificDataLogger(this.dataReader, toBeLoggedOrNotToBeLogged);
            string filePath = specificDataLogger.CreateFile(currentDateTime);
            specificDataLogger.WriteInitialLine(filePath, toBeLoggedOrNotToBeLogged);
            Timer loggingThread = new Timer(this.SpecificDataLogging, specificDataLogger, filePath, interval);
        }

        private void SpecificDataLogging(object state)
        {
            logSpecificData.WriteDataToFile(filePath, this.dataReader.GetDataArray());
        }
    }
}
