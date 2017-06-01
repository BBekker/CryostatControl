// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataClientCallback.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlClient
{
    using System;
    using CryostatControlClient.ServiceReference1;
    using CryostatControlClient.Views;

    /// <summary>
    /// Class which handles the data callback calls from the server
    /// </summary>
    /// <seealso cref="CryostatControlClient.ServiceReference1.IDataGetCallback" />
    public class DataClientCallback : IDataGetCallback
    {
        #region Fields

        /// <summary>
        /// The main application
        /// </summary>
        private App mainApp;

        /// <summary>
        /// The main window
        /// </summary>
        private MainWindow mainWindow;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataClientCallback"/> class.
        /// </summary>
        /// <param name="app">The main application.</param>
        public DataClientCallback(App app)
        {
            this.mainApp = app;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the data retrieved for all sensors.
        /// </summary>
        /// <param name="data">The data.</param>
        public void SendData(double[] data)
        {
            this.mainApp.Dispatcher.Invoke(() =>
            {
                if (this.mainWindow == null)
                {
                    this.mainWindow = this.mainApp.MainWindow as MainWindow;
                }
                this.mainWindow.UpdateViewModels(data);
            });
        }

        /// <summary>
        /// Sends the modus.
        /// </summary>
        /// <param name="modus">The modus.</param>
        public void SendModus(int modus)
        {
            this.mainApp.Dispatcher.Invoke(() =>
            {
                if (this.mainWindow == null)
                {
                    this.mainWindow = this.mainApp.MainWindow as MainWindow;
                }
                this.mainWindow.SetState(modus);
            });
        }

        /// <summary>
        /// Sets the state of the logging.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [status].</param>
        public void SetLoggingState(bool status)
        {
            this.mainApp.Dispatcher.Invoke(() =>
            {
                if (this.mainWindow == null)
                {
                    this.mainWindow = this.mainApp.MainWindow as MainWindow;
                }
                this.mainWindow.SetIsLogging(status);
            });
        }

        #endregion Methods
    }
}