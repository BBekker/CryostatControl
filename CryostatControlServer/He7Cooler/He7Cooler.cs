// --------------------------------------------------------------------------------------------------------------------
// <copyright file="He7Cooler.cs" company="SRON">
//   All rights reserved. 2017.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   Defines the He7Cooler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// He7 Cooler class. 
    /// Represents the He7 cooler controls. Read and set voltages and digital bits.
    /// </summary>
    public partial class He7Cooler
    { 
        /// <summary>
        /// The interval between voltage samples
        /// </summary>
        private const int ReadInterval = 100;

        /// <summary>
        /// The connected device.
        /// </summary>
        private readonly Agilent34972A device = new Agilent34972A();

        /// <summary>
        /// The channels to read.
        /// </summary>
        private List<Channels> channelsToRead = new List<Channels>();

        /// <summary>
        /// The current voltage of each channel.
        /// </summary>
        private Dictionary<Channels, double> values = new Dictionary<Channels, double>();

        /// <summary>
        /// The thread reading voltages.
        /// </summary>
        private Thread readThread;

        /// <summary>
        /// Is the sampling of voltages started.
        /// </summary>
        private bool isStarted = false;

        /// <summary>
        /// Connect to the Agilent device.
        /// </summary>
        /// <param name="ip">
        /// The IP to connect to.
        /// </param>
        public void Connect(string ip)
        {
            this.device.Init(ip);
            this.isStarted = true;
            this.readThread = new Thread(this.MainLoop);
            this.readThread.Start();
        }

        /// <summary>
        /// Stop the reading thread and disconnect from the device.
        /// </summary>
        public void Disconnect()
        {
            this.isStarted = false;
            this.device.Disconnect();
        }

        /// <summary>
        /// Read the voltages of all registered channels
        /// </summary>
        public void ReadVoltages()
        {
            Channels[] channels = this.channelsToRead.ToArray();
            double[] voltages = this.device.GetVoltages(channels);
            for (int i = 0; i < channels.Length; i++)
            {
                this.values[channels[i]] = voltages[i];
            }
        }

        /// <summary>
        /// The set digital switch.
        /// </summary>
        /// <param name="theSwitch">
        /// The switch.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetDigitalSwitch(DigitalSwitch theSwitch, bool value)
        {
            this.device.SetDigitalOutput((int)theSwitch, value);
        }

        /// <summary>
        /// Set the voltage of a channel
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        /// <param name="volts">
        /// The voltage
        /// </param>
        protected void SetVoltage(Channels channel, double volts)
        {
            this.device.SetHeaterVoltage(channel, volts);
        }

        /// <summary>
        /// The add channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        protected void AddChannel(Channels channel)
        {
            this.channelsToRead.Add(channel);
        }

        /// <summary>
        /// The remove channel.
        /// </summary>
        /// <param name="channel">
        /// The channel.
        /// </param>
        protected void RemoveChannel(Channels channel)
        {
            this.channelsToRead.Remove(channel);
        }

        /// <summary>
        /// The main loop of the thread that reads voltages from the He7 cooler.
        /// </summary>
        private void MainLoop()
        {
            while (this.isStarted)
            {
                this.ReadVoltages();
                Thread.Sleep(ReadInterval);
            }
        }
    }
}