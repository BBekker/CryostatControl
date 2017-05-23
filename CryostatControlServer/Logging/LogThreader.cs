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

        public void StartSpecificDataLogging(int interval, double[] toBeLoggedOrNotToBeLogged)
        {
            DateTime currentDateTime = DateTime.Now;
            LogSpecificData logSpecificData = new LogSpecificData(this.dataReader, toBeLoggedOrNotToBeLogged);
            string filePath = logSpecificData.CreateFile(currentDateTime);
            logSpecificData.WriteInitialLine(filePath, toBeLoggedOrNotToBeLogged);
//            Timer loggingThread = new Timer(this.SpecificDataLogging, logSpecificData, filePath, interval);
        }

//        private void SpecificDataLogging(object state)
//        {
//            logSpecificData.WriteDataToFile(filePath, this.dataReader.GetDataArray());
//        }
    }
}
