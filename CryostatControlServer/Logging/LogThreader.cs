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

    /// <summary>
    /// The log threader.
    /// </summary>
    public class LogThreader
    {
        #region Fields

        /// <summary>
        /// The general log interval in seconds.
        /// </summary>
        private const int GeneralLogInterval = 10;

        /// <summary>
        /// The general main folder.
        /// </summary>
        private const string GeneralMainFolder = @"c:/Logging/General";

        /// <summary>
        /// The specific main folder.
        /// </summary>
        private const string SpecificMainFolder = @"c:/Logging/Specific";

        /// <summary>
        /// The data reader.
        /// </summary>
        private DataReader dataReader;

        /// <summary>
        /// The specific logging thread.
        /// </summary>
        private Timer specificLoggingThread;

        /// <summary>
        /// The general logging thread.
        /// </summary>
        private Timer generalLoggingThread;

        /// <summary>
        /// Specific logging in progress boolean.
        /// </summary>
        private bool specificLoggingInProgress;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogThreader"/> class.
        /// </summary>
        /// <param name="dataReader">
        /// The data reader.
        /// </param>
        public LogThreader(DataReader dataReader)
        {
            this.dataReader = dataReader;
            this.specificLoggingInProgress = false;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// The start specific data logging.
        /// </summary>
        /// <param name="interval">
        /// The interval.
        /// </param>
        /// <param name="toBeLoggedOrNotToBeLogged">
        /// The to be logged or not to be logged.
        /// </param>
        public void StartSpecificDataLogging(int interval, bool[] toBeLoggedOrNotToBeLogged)
        {
            if (this.specificLoggingInProgress)
            {
                this.StopSpecificDataLogging();
            }
            DateTime currentDateTime = DateTime.Now;
            SpecificDataLogger specificDataLogger = new SpecificDataLogger(toBeLoggedOrNotToBeLogged);

            string filePath = specificDataLogger.CreateFile(currentDateTime, SpecificMainFolder);

            specificDataLogger.WriteInitialLine(filePath, toBeLoggedOrNotToBeLogged);
            LoggerDataObject loggerDataObject = new LoggerDataObject(specificDataLogger, filePath);
            int startTime = 0;
            this.specificLoggingThread = new Timer(this.SpecificDataLogging, loggerDataObject, startTime, this.ConvertSecondsToMs(interval));
            this.specificLoggingInProgress = true;
        }

        /// <summary>
        /// The stop specific data logging.
        /// </summary>
        public void StopSpecificDataLogging()
        {
            this.specificLoggingThread.Dispose();
            this.specificLoggingInProgress = false;
        }

        /// <summary>
        /// The start general data logging.
        /// </summary>
        public void StartGeneralDataLogging()
        {
            Console.WriteLine("starting!");
            DateTime currentDateTime = DateTime.Now;
            GeneralDataLogger generalDataLogger = new GeneralDataLogger();

            string filePath = generalDataLogger.CreateFile(currentDateTime, GeneralMainFolder);

            generalDataLogger.WriteInitialLine(filePath, generalDataLogger.CreateArrayWithOnlyTrue());
            LoggerDataObject loggerDataObject = new LoggerDataObject(generalDataLogger, filePath);
            int startTime = 0;
            this.generalLoggingThread = new Timer(this.GeneralDataLogging, loggerDataObject, startTime, this.ConvertSecondsToMs(GeneralLogInterval));

        }

        /// <summary>
        /// The stop general data logging.
        /// </summary>
        public void StopGeneralDataLogging()
        {
            this.generalLoggingThread.Dispose();
        }

        /// <summary>
        /// Gets the specific logging in progress.
        /// </summary>
        /// <returns>True if it is in progress</returns>
        public bool GetSpecificLoggingInProgress()
        {
            return this.specificLoggingInProgress;
        }

        /// <summary>
        /// Convert seconds to mili seconds.
        /// </summary>
        /// <param name="seconds">
        /// The seconds.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int ConvertSecondsToMs(int seconds)
        {
            return seconds * 1000;
        }

        /// <summary>
        /// The general data logging.
        /// </summary>
        /// <param name="loggerDataObject">
        /// The logger data object.
        /// </param>
        private void GeneralDataLogging(object loggerDataObject)
        {
            GeneralDataLogger specificDataLogger = (GeneralDataLogger)((LoggerDataObject)loggerDataObject).GetAbstractLogData();
            string filePath = ((LoggerDataObject)loggerDataObject).GetFilePath();
            specificDataLogger.WriteGeneralData(filePath, this.dataReader.GetDataArray(), DateTime.Now.ToString("hh:mm:ss"));
        }

        /// <summary>
        /// The specific data logging.
        /// </summary>
        /// <param name="loggerDataObject">
        /// The logger data object.
        /// </param>
        private void SpecificDataLogging(object loggerDataObject)
        {
            SpecificDataLogger specificDataLogger = (SpecificDataLogger)((LoggerDataObject)loggerDataObject).GetAbstractLogData();
            string filePath = ((LoggerDataObject)loggerDataObject).GetFilePath();
            specificDataLogger.WriteSpecificData(filePath, this.dataReader.GetDataArray(), DateTime.Now.ToString("hh:mm:ss"));
        }

        #endregion Methods
    }
}