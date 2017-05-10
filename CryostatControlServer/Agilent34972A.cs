//-----------------------------------------------------------------------
// <copyright file="Agilent34972A.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
// <author>Bernard Bekker</author>
//-----------------------------------------------------------------------

namespace CryostatControlServer
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    using CryostatControlServer.Streams;

    /// <summary>
    /// Agilent34972 class
    /// </summary>
    public class Agilent34972A
    {
        /// <summary>
        /// The TCP port.
        /// </summary>
        private const int TcpPort = 5025;

        /// <summary>
        /// The dig switch channels.
        /// </summary>
        private static readonly Channels[] DigSwitchChannels = { Channels.SensHe3HeadT, Channels.SensHe4HeadT, Channels.PumpHe3, Channels.PumpHe4 };

        /// <summary>
        /// The connection.
        /// </summary>
        private readonly ManagedStream connection = new ManagedStream();

        /// <summary>
        /// used DAQ channels.
        /// </summary> 
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
        public enum Channels
        {
            // Digital Channel
            CtrlDigOut = 201,

            // Heaters
            PumpHe3 = 204,

            PumpHe4 = 205,

            Sens2KplateT = 104,

            Sens4KplateT = 105,

            SensHe3HeadT = 107,

            // Heater sensors
            SensHe3Pump = 110,

            SensHe3PumpT = 101,

            SensHe3Switch = 112,

            SensHe3SwitchT = 103,

            SensHe4HeadT = 108,

            SensHe4Pump = 109,

            // Temperature sensors
            SensHe4PumpT = 106,

            SensHe4Switch = 111,

            SensHe4SwitchT = 102,

            SwitchHe3 = 305,

            SwitchHe4 = 304,
        }

        /// <summary>
        ///     Gets voltages from the device
        /// </summary>
        /// <param name="channelIds">Sensor ID's to measure.</param>
        /// <returns>array of voltages in the same ordering as channelIds</returns>
        public double[] GetVoltages(Channels[] channelIds)
        {
            try
            {
                Monitor.Enter(this.connection);
                var nSensors = channelIds.Length;
                var nChan = new int[nSensors];
                var rVolt = new double[nSensors];
               
                var readVolt = new double[nSensors];

                // construct a command to read all specified voltages
                var cmdStr = "ROUT:SCAN (@";

                for (var k = 0; k < nSensors - 1; k++)
                {
                    cmdStr += $"{channelIds[k]},";
                }

                cmdStr += $"{channelIds[nSensors - 1]})\n";
                cmdStr += "READ?\n";
                this.connection.WriteString(cmdStr);

                // read response
                var res = this.connection.ReadString();

                // Extract data
                var values = GetDataFromString(res);

                // split into voltages and channels
                for (var k = 0; k < nSensors; k++)
                {
                    rVolt[k] = values[2 * k];
                    nChan[k] = (int)values[(2 * k) + 1];
                }

                // Order temperature in order of sens_IDs
                for (var k = 0; k < nSensors; k++)
                {
                    for (var i = 0; i < nSensors; i++)
                    {
                        if ((int)channelIds[i] == nChan[k])
                        {
                            readVolt[i] = rVolt[k];
                        }
                    }
                }

                // Write ABOR command to return
                this.connection.WriteString("ABOR\n");
                this.CheckState();

                return readVolt;
            }
            finally
            {
                Monitor.Exit(this.connection);
            }
        }

        /// <summary>
        /// Initializes the specified IP address.
        /// </summary>
        /// <param name="ipAddress">The IP address.</param>
        public void Init(string ipAddress)
        {
            this.connection.ConnectTCP(ipAddress, TcpPort);

            // -------- INITIALIZE AGILENT CONTROLLER
            this.connection.WriteString("FORM:READ:CHAN ON\n");
            this.CheckState();
        }

        /// <summary>
        /// Set digital output.
        /// </summary>
        /// <param name="switch_ID">
        /// The switch_ id.
        /// </param>
        /// <param name="b_set">
        /// The b_set.
        /// </param>
        public void SetDigitalOutput(Channels switch_ID, bool b_set)
        {
            try
            {
                Monitor.Enter(this.connection);

                // Get current digital output values
                this.connection.WriteString($"SOUR:DIG:DATA:BYTE? (@{(int)Channels.CtrlDigOut})\n");
                var resString = this.connection.ReadString();
                var getByte = int.Parse(resString); // TODO: Catch error

                // find corresponding bits
                var bitVal = 1;
                for (var k = 0; k < DigSwitchChannels.Length; k++)
                {
                    if (switch_ID == DigSwitchChannels[k])
                    {
                        bitVal = 1 << k;
                        if (k < 2)
                        {
                            b_set = !b_set;
                        }

                        break;
                    }
                }

                // set or clear the bit in the old values
                var setByte = 0;
                if (b_set)
                {
                    // Set bit : 1
                    setByte = getByte | bitVal;
                }
                else
                {
                    // Set bit : 0
                    setByte = getByte - (getByte & bitVal);
                }

                // write new configuration
                this.connection.WriteString($"SOUR:DIG:DATA:BYTE {setByte}, (@{(int)Channels.CtrlDigOut})\n");
            }
            finally
            {
                Monitor.Exit(this.connection);
            }
        }

        /// <summary>
        ///     Sets the heater voltage.
        /// </summary>
        /// <param name="heatId">The heater identifier.</param>
        /// <param name="setVoltage">The set voltage.</param>
        public void SetHeaterVoltage(Channels heatId, double setVoltage)
        {
            try
            {
                Monitor.Enter(this.connection);
                this.connection.WriteString($"SOUR:VOLT {setVoltage:F3}, (@{(int)heatId})\n");
            }
            finally
            {
                Monitor.Exit(this.connection);
            }
        }

        /// <summary>
        /// Get returned data from string.
        /// </summary>
        /// <param name="dataString">
        /// The data string.
        /// </param>
        /// <returns>
        /// The <see cref="double[]"/>.
        /// </returns>
        private static double[] GetDataFromString(string dataString)
        {
            var split = dataString.Split(',');
            var results = new double[split.Length];
            for (var i = 0; i < split.Length; i++)
            {
                results[i] = double.Parse(split[i]);
            }

            return results;
        }

        /// <summary>
        /// Checks if the device is in a consistent state and all commands are performed. used for synchronisation.
        /// </summary>
        /// <exception cref="System.Exception">invalid agilent state</exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        private void CheckState()
        {
            try
            {
                Monitor.Enter(this.connection);
                this.connection.WriteString("*OPC?\n");

                var res = int.Parse(this.connection.ReadString());
                if (res < 1)
                {
                    throw new Exception("invalid agilent state");
                }
            }
            finally
            {
                Monitor.Exit(this.connection);
            }
        }
    }
}