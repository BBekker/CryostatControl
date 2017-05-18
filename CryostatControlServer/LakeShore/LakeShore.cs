// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LakeShore.cs" company="SRON">
//   Copyright (c) SRON. All rights reserved.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   Connection and comunication to the LakeShore 355 temperature controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.LakeShore
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    using CryostatControlServer.Streams;

    /// <summary>
    /// Connection and communication to the LakeShore 355 temperature controller.
    /// </summary>
    public class LakeShore
    {
        /// <summary>
        /// The 3K cold plate id
        /// </summary>
        public const string ColdPlate3K = "A";

        /// <summary>
        /// The 5k cold plate id
        /// </summary>
        public const string ColdPlate5K = "B";

        /// <summary>
        /// The baud rate of the  COM connection
        /// </summary>
        private const int BaudRate = 57600;

        /// <summary>
        /// The read interval.
        /// </summary>
        private const int ReadInterval = 1000;

        /// <summary>
        /// The time of the last command. Commands need to be spaced at least 50ms
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
        private DateTime lastCommand;

        /// <summary>
        /// The connection.
        /// </summary>
        private IManagedStream ms;

        /// <summary>
        /// The read thread.
        /// </summary>
        private Thread readthread;

        /// <summary>
        /// Gets or sets the latest sensor values;
        /// </summary>
        public double[] SensorValues { get; set; } = new double[2] { 0, 0 };

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            // Stop the read thread inside a lock to prevent stopping while thread holds the lock.
            Monitor.Enter(this.ms);
            this.readthread.Abort();
            Monitor.Exit(this.ms);
            this.ms.Close();
        }

        /// <summary>
        /// Initializes by connecting to the specified port name.
        /// </summary>
        /// <param name="portname">The port name.</param>
        public void Init(string portname)
        {
            this.ms = new ManagedCOMStream(portname, BaudRate);
            this.ms.Open();

            this.StartReading();
        }

        /// <summary>
        /// Initializes by connecting to the specified port name.
        /// </summary>
        /// <param name="managedStream">
        /// The managed Stream.
        /// </param>
        public void Init(IManagedStream managedStream)
        {
            this.ms = managedStream;
            this.ms.Open();

            this.StartReading();
        }

        /// <summary>
        /// Sends OPC command to device and waits for response.
        /// Used to confirm connection and synchronisation of state of the device.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
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
        /// Reads the sensor temperature in Kelvin.
        /// </summary>
        /// <param name="sensor">The sensor.</param>
        /// <returns>sensor temperature in K</returns>
        private double ReadTemperature(string sensor)
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
        /// Start reading temperatures.
        /// </summary>
        private void StartReading()
        {
            this.lastCommand = DateTime.Now;

            this.ms.WriteString("MODE 1\n");
            this.OPC();

            this.readthread = new Thread(
                () =>
                    {
                        while (true)
                        {
                            this.SensorValues[0] = this.ReadTemperature("A");
                            this.SensorValues[1] = this.ReadTemperature("B");
                            Thread.Sleep(ReadInterval);
                        }
                    });
            this.readthread.Start();
        }

        /// <summary>
        /// Wait until the specified minimum time between commands is passed.
        /// The lakeshore355 manual specifies a minimum time of 50ms between commands.
        /// </summary>
        [SuppressMessage(
            "StyleCop.CSharp.DocumentationRules",
            "SA1650:ElementDocumentationMustBeSpelledCorrectly",
            Justification = "Reviewed. Suppression is OK here.")]
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