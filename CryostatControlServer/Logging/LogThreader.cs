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
    using System.IO;
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
        private const string GeneralMainFolder = @"c:\CryostatLogging\General";

        /// <summary>
        /// The specific main folder.
        /// </summary>
        private const string SpecificMainFolder = @"c:\CryostatLogging\Specific";

        /// <summary>
        /// The start time.
        /// </summary>
        private const int StartTime = 0;

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

            SpecificDataLogger specificDataLogger = new SpecificDataLogger(toBeLoggedOrNotToBeLogged, interval);
            LoggerDataObject loggerDataObject = this.CreateNewSpecificLoggingFile(specificDataLogger);
            
            this.specificLoggingThread = new Timer(this.SpecificDataLogging, loggerDataObject, StartTime, this.ConvertSecondsToMs(interval));
            this.specificLoggingInProgress = true;
        }

        /// <summary>
        /// The stop specific data logging.
        /// </summary>
        public void StopSpecificDataLogging()
        {
            if (this.specificLoggingThread != null)
            {
                this.specificLoggingThread.Dispose();
            }
            this.specificLoggingInProgress = false;
        }

        /// <summary>
        /// The start general data logging.
        /// </summary>
        public void StartGeneralDataLogging()
        {
            GeneralDataLogger generalDataLogger = new GeneralDataLogger();
            LoggerDataObject loggerDataObject = this.CreateNewGeneralLoggingFile(generalDataLogger);
            this.generalLoggingThread = new Timer(this.GeneralDataLogging, loggerDataObject, StartTime, this.ConvertSecondsToMs(GeneralLogInterval));
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
        /// The check if new file is needed.
        /// </summary>
        /// <param name="filepath">
        /// The filepath.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool NewFileIsNeeded(string filepath)
        {
            string logDay = Path.GetFileName(filepath);
            if (logDay == null || !logDay.Contains(".csv"))
            {
                DebugLogger.Error(this.GetType().Name, "Can't find logfile name for checking if a new file is needed.");
                return false;
            }

            logDay = logDay.Replace(".csv", string.Empty);
            string currentDay = DateTime.Now.Day.ToString();
            if (!logDay.Equals(currentDay))
            {
                return true;
            }

            return false;
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
            if (this.NewFileIsNeeded(filePath))
            {
                this.StopGeneralDataLogging();
                this.StartGeneralDataLogging();
                return;
            }

            specificDataLogger.WriteGeneralData(filePath, this.dataReader.GetDataArray(), DateTime.Now.ToString("HH:mm:ss"));
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
            if (this.NewFileIsNeeded(filePath))
            {
                this.StopSpecificDataLogging();
                this.StartSpecificDataLogging(specificDataLogger.GetInterval(), specificDataLogger.GetToBeLoggedOrNotToBeLogged());
                return;
            }

            specificDataLogger.WriteSpecificData(filePath, this.dataReader.GetDataArray(), DateTime.Now.ToString("HH:mm:ss"));
        }

        /// <summary>
        /// Creates the new general logging file.
        /// </summary>
        /// <param name="generalDataLogger">The general data logger.</param>
        /// <returns>General Logger Data Object</returns>
        private LoggerDataObject CreateNewGeneralLoggingFile(GeneralDataLogger generalDataLogger)
        {
            string filePath = generalDataLogger.CreateFile(GeneralMainFolder);

            generalDataLogger.WriteInitialLine(filePath, generalDataLogger.CreateArrayWithOnlyTrue());
            return new LoggerDataObject(generalDataLogger, filePath);
        }

        /// <summary>
        /// Creates the new specific logging file.
        /// </summary>
        /// <param name="specificDataLogger">The specific data logger.</param>
        /// <returns>Specific logger Data Object</returns>
        private LoggerDataObject CreateNewSpecificLoggingFile(SpecificDataLogger specificDataLogger)
        {
            string filePath = specificDataLogger.CreateFile(SpecificMainFolder);

            specificDataLogger.WriteInitialLine(filePath, specificDataLogger.GetToBeLoggedOrNotToBeLogged());
            return new LoggerDataObject(specificDataLogger, filePath);
        }

        #endregion Methods
    }
}