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
            this.mainWindow = this.mainApp.MainWindow as MainWindow;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Handles the data for the BlueFors
        /// </summary>
        /// <param name="data">The data.</param>
        public void SendBlueForsData(float[] data)
        {
            this.mainWindow.UpdateBluefors(data);
            Console.WriteLine("Received BlueFors: {0}", data[0]);
        }

        /// <summary>
        /// Handles the data for the Compressor
        /// </summary>
        /// <param name="data">The data.</param>
        public void SendCompressorData(float[] data)
        {
            this.mainWindow.UpdateCompressor(data);
            Console.WriteLine("Received Compressor: {0}", data[0]);
        }

        /// <summary>
        /// Handles the data for the Helium cooler
        /// </summary>
        /// <param name="data">The data.</param>
        public void SendHelium7Data(float[] data)
        {
            this.mainWindow.UpdateHe7(data);
            Console.WriteLine("Received Helium 7: {0}", data[0]);
        }

        #endregion Methods
    }
}