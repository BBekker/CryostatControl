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
    using CryostatControlClient.Communication;
    using CryostatControlClient.ViewModels;

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

        private DataReceiver dataReceiver;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataClientCallback"/> class.
        /// </summary>
        /// <param name="app">The main application.</param>
        public DataClientCallback(App app)
        {
            this.mainApp = app;
            dataReceiver = new DataReceiver();
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

                this.dataReceiver.UpdateViewModels(data, ((MainWindow)this.mainApp.MainWindow).Container);
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

                this.dataReceiver.SetState(modus, ((MainWindow)this.mainApp.MainWindow).Container);
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

                this.dataReceiver.SetIsLogging(status, ((MainWindow)this.mainApp.MainWindow).Container);
            });
        }

        /// <summary>
        /// Updates the countdown.
        /// </summary>
        /// <param name="time">The time.</param>
        public void UpdateCountdown(DateTime time)
        {
            this.mainApp.Dispatcher.Invoke(() =>
                {
                    if (this.mainWindow == null)
                    {
                        this.mainWindow = this.mainApp.MainWindow as MainWindow;
                    }

                    this.dataReceiver.UpdateCountdown(time, ((MainWindow)this.mainApp.MainWindow).Container);
                });
        }

        /// <summary>
        /// The update notification.
        /// </summary>
        /// <param name="notification">
        /// The notification.
        /// </param>
        public void UpdateNotification(string[] notification)
        {
            if (this.mainWindow == null)
            {
                this.mainWindow = this.mainApp.MainWindow as MainWindow;
            }

            this.dataReceiver.UpdateNotification(notification, ((MainWindow)this.mainApp.MainWindow).Container);
        }

        #endregion Methods
    }
}