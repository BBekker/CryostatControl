// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sensor.cs" company="SRON">
//   All rights reserved.
// </copyright>
// <author>Bernard Bekker</author>
// <summary>
//   The he 7 cooler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer.He7Cooler
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;

    using CryostatControlServer.Data;
    using CryostatControlServer.Logging;

    /// <summary>
    /// The he 7 cooler.
    /// </summary>
    public partial class He7Cooler
    {
        #region Classes

        /// <summary>
        /// Representation of a sensor on the H7 cooler.
        /// </summary>
        public class Sensor : ISensor
        {
            #region Fields

            /// <summary>
            /// The sensor calibration.
            /// </summary>
            private Calibration calibration;

            /// <summary>
            /// The Agilent data channel.
            /// </summary>
            private Channels channel;

            /// <summary>
            /// The He7 cooler.
            /// </summary>
            private He7Cooler device;

            #endregion Fields

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="Sensor"/> class.
            /// </summary>
            /// <param name="channel">
            /// The agilent channel of the sensor.
            /// </param>
            /// <param name="device">
            /// The He7 cooler device.
            /// </param>
            /// <param name="calibration">
            /// The calibration.
            /// </param>
            public Sensor(Channels channel, He7Cooler device, Calibration calibration)
            {
                this.channel = channel;
                this.calibration = calibration;
                this.device = device;
                device.AddChannel(channel);
            }

            #endregion Constructors

            #region Destructors

            /// <summary>
            /// Finalizes an instance of the <see cref="Sensor"/> class.  Removes it from the list of channels to read.
            /// </summary>
            ~Sensor()
            {
                this.device.RemoveChannel(this.channel);
            }

            #endregion Destructors

            #region Properties

            /// <summary>
            /// Gets or sets the interval.
            /// This is ignored for now, sensors are always read as fast as possible.
            /// </summary>
            public int Interval { get; set; }

            /// <summary>
            /// Gets the current calibrated value of the sensor.
            /// </summary>
            public double Value => this.calibration.ConvertValue(this.device.values[this.channel]);

            #endregion Properties

            #region Classes

            #endregion Classes
        }

        #endregion Classes

    }
}