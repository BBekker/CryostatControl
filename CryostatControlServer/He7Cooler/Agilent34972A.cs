//-----------------------------------------------------------------------
// <copyright file="Agilent34972A.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
// <author>Bernard Bekker</author>
//-----------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
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
        /// The connection.
        /// </summary>
        private readonly ManagedStream connection = new ManagedStream();

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
                var numSensors = channelIds.Length;
                var returnedChannels = new int[numSensors];
                var returnedVolts = new double[numSensors];
               
                var readVolt = new double[numSensors];

                // construct a command to read all specified voltages
                var cmdStr = "ROUT:SCAN (@";
                for (var k = 0; k < numSensors - 1; k++)
                {
                    cmdStr += $"{channelIds[k]},";
                }

                cmdStr += $"{channelIds[numSensors - 1]})\n";
                cmdStr += "READ?\n";

                this.connection.WriteString(cmdStr);
                var res = this.connection.ReadString();
                var values = GetDataFromString(res);

                // split into voltages and channels
                for (var k = 0; k < numSensors; k++)
                {
                    returnedVolts[k] = values[2 * k];
                    returnedChannels[k] = (int)values[(2 * k) + 1];
                }

                // Order temperature in order of sens_IDs
                for (var k = 0; k < numSensors; k++)
                {
                    for (var i = 0; i < numSensors; i++)
                    {
                        if ((int)channelIds[i] == returnedChannels[k])
                        {
                            readVolt[i] = returnedVolts[k];
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

            this.connection.WriteString("FORM:READ:CHAN ON\n");
            this.CheckState();
        }

        /// <summary>
        /// Disconnect the device.
        /// </summary>
        public void Disconnect()
        {
            this.connection.Close();
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
        public void SetDigitalOutput(int bit, bool b_set)
        {
            try
            {
                Monitor.Enter(this.connection);

                // Get current digital output values
                this.connection.WriteString($"SOUR:DIG:DATA:BYTE? (@{(int)Channels.CtrlDigOut})\n");
                var resString = this.connection.ReadString();
                var getByte = int.Parse(resString); // TODO: Catch error

                var bitVal = 1 << bit;
                if (bit < 2)
                {
                    b_set = !b_set;
                }
                        
                // set or clear the bit in the old values
                var setByte = 0;
                if (b_set)
                {
                    setByte = getByte | bitVal;
                }
                else
                {
                    setByte = getByte - (getByte & bitVal);
                }
                
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