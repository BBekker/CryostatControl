﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataClientCallback.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlClient
{
    using System;
    using CryostatControlClient.ServiceReference1;

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
        public void SendData(float[] data)
        {
            Console.WriteLine("Received: {0}", data[0]);
        }

        #endregion Methods
    }
}