// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Heater.cs" company="SRON">
//   All rights reserved.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   Representation a heater element on the H7 cooler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System;

    /// <summary>
    /// The he 7 cooler.
    /// </summary>
    public partial class He7Cooler
    {
        /// <summary>
        /// Representation a heater element on the H7 cooler.
        /// </summary>
        public class Heater
        {
            /// <summary>
            /// The default safe range high.
            /// </summary>
            private const double DefaultSafeRangeHigh = 10.0;

            /// <summary>
            /// The default safe range low.
            /// </summary>
            private const double DefaultSafeRangeLow = 0.0;

            /// <summary>
            /// The channel where current voltage is read.
            /// </summary>
            private Channels inchannel;

            /// <summary>
            /// The channel where to output the voltage setpoint.
            /// </summary>
            private Channels outchannel;

            /// <summary>
            /// The H7 cooler device.
            /// </summary>
            private He7Cooler device;

            /// <summary>
            /// Initializes a new instance of the <see cref="Heater"/> class.
            /// </summary>
            /// <param name="outputChannel">
            /// The voltage output channel.
            /// </param>
            /// <param name="inputChannel">
            /// The voltage input channel.
            /// </param>
            /// <param name="device">
            /// The He7 cooler device the heater is connected to.
            /// </param>
            public Heater(Channels outputChannel, Channels inputChannel, He7Cooler device)
            {
                this.inchannel = inputChannel;
                this.outchannel = outputChannel;
                this.device = device;
                device.channelsToRead.Add(inputChannel);
                this.SafeRangeHigh = DefaultSafeRangeHigh;
                this.SafeRangeLow = DefaultSafeRangeLow;
            }

            /// <summary>
            /// Gets or sets the voltage safe range high side.
            /// </summary>
            public double SafeRangeHigh { get; set; }

            /// <summary>
            /// Gets or sets the voltage safe range low side.
            /// </summary>
            public double SafeRangeLow { get; set; }

            /// <summary>
            /// Gets or sets the voltage of the heater.
            /// </summary>
            public double Voltage
            {
                get => this.device.values[this.inchannel];
                set => this.SetOutput(this.Voltage);
            }

            /// <summary>
            /// The set output.
            /// </summary>
            /// <param name="volts">
            /// The volts.
            /// </param>
            private void SetOutput(double volts)
            {
                if (volts > this.SafeRangeHigh || volts < this.SafeRangeLow)
                {
                    throw new ArgumentOutOfRangeException(
                        $"Voltage setpoint of {volts} is out of the safe range from {this.SafeRangeLow} to {this.SafeRangeHigh}");
                }

                this.device.SetVoltage(this.outchannel, volts);
            }
        }
    }
}