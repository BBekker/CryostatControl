// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LakeShore.cs" company="SRON">
//   Copyright (c) SRON. All rights reserved.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   Connection and comunication to the LakeShore 355 temperature controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using CryostatControlServer.Streams;

    /// <summary>
    /// Connection and comunication to the LakeShore 355 temperature controller.
    /// </summary>
    internal class LakeShore
    {
        #region const values

        private const string Coldplate3K = "A";
        private const string Coldplate5K = "B";

        private const int Boudrate = 57600;
        #endregion const 

        /// <summary>
        /// The connection.
        /// </summary>
        private readonly ManagedStream ms = new ManagedStream();

        /// <summary>
        /// The time of the last command. Commands need to be spaced at least 50ms
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private DateTime lastCommand;

        /// <summary>
        /// Initializes by connecting to the specified port name.
        /// </summary>
        /// <param name="portname">The port name.</param>
        public void Init(string portname)
        {
            this.ms.ConnectCOM(portname, Boudrate);

            this.lastCommand = DateTime.Now;

            this.ms.WriteString("MODE 1\n");
            this.OPC();
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            this.ms.Close();
        }

        /// <summary>
        /// Reads the sensor temperature in Kelvin.
        /// </summary>
        /// <param name="sensor">The sensor.</param>
        /// <returns>sensor temperature in K</returns>
        public double ReadTemperature(string sensor)
        {
            try
            {
                Monitor.Enter(this.ms);
                this.WaitCommandInterval();
                this.ms.WriteString($"KRDG? {sensor}\n");
                string response = this.ms.ReadString();
                return double.Parse(response);
            }
            finally
            {
                Monitor.Exit(this.ms);
            }
        }

        /// <summary>
        /// Sends OPC command to device and waits for response.
        /// Used to confirm connection and synchronisation of state of the device.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public void OPC()
        {
            try
            {
                Monitor.Enter(this.ms);
                this.WaitCommandInterval();
                this.ms.WriteString("OPC?\n");
                this.ms.ReadString();
            }
            finally
            {
                Monitor.Exit(this.ms);
            }
        }

        /// <summary>
        /// Wait until the specified minimum time between commands is passed.
        /// The lakeshore355 manual specifies a minimum time of 50ms between commands.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void WaitCommandInterval()
        {
            while (DateTime.Now - this.lastCommand < TimeSpan.FromMilliseconds(50))
            {
                Thread.Sleep(DateTime.Now - this.lastCommand);
            }

            this.lastCommand = DateTime.Now;
        }
    }
}