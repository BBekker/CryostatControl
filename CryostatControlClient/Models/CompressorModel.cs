//-----------------------------------------------------------------------
// <copyright file="CompressorModel.cs" company="SRON">
//     Copyright (c) 2017 SRON
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;
    using System.Collections.Generic;

    using Dragablz.Dockablz;

    /// <summary>
    /// The compressor model.
    /// </summary>
    public class CompressorModel
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the state of operation.
        /// </summary>
        /// <value>
        /// The state of operiation.
        /// </value>
        public double OperatingState { get; set; } = -1;

        /// <summary>
        /// Gets or sets the state of the warning.
        /// </summary>
        /// <value>
        /// The state of the warning.
        /// </value>
        public double WarningState { get; set; }

        /// <summary>
        /// Gets or sets the state of the error.
        /// </summary>
        /// <value>
        /// The state of the error.
        /// </value>
        public double ErrorState { get; set; }

        /// <summary>
        /// Gets or sets the water in temperature.
        /// </summary>
        /// <value>
        /// The water in temperature.
        /// </value>
        public double WaterInTemp { get; set; }

        /// <summary>
        /// Gets or sets the water out temperature.
        /// </summary>
        /// <value>
        /// The water out temperature.
        /// </value>
        public double WaterOutTemp { get; set; }

        /// <summary>
        /// Gets or sets the oil temperature.
        /// </summary>
        /// <value>
        /// The oil temperature.
        /// </value>
        public double OilTemp { get; set; }

        /// <summary>
        /// Gets or sets the helium temperature.
        /// </summary>
        /// <value>
        /// The helium temperature.
        /// </value>
        public double HeliumTemp { get; set; }

        /// <summary>
        /// Gets or sets the low pressure.
        /// </summary>
        /// <value>
        /// The low pressure.
        /// </value>
        public double LowPressure { get; set; }

        /// <summary>
        /// Gets or sets the low pressure average.
        /// </summary>
        /// <value>
        /// The low pressure average.
        /// </value>
        public double LowPressureAverage { get; set; }

        /// <summary>
        /// Gets or sets the high pressure.
        /// </summary>
        /// <value>
        /// The high pressure.
        /// </value>
        public double HighPressure { get; set; }

        /// <summary>
        /// Gets or sets the high pressure average.
        /// </summary>
        /// <value>
        /// The high pressure average.
        /// </value>
        public double HighPressureAverage { get; set; }

        /// <summary>
        /// Gets or sets the delta pressure average.
        /// </summary>
        /// <value>
        /// The delta pressure average.
        /// </value>
        public double DeltaPressureAverage { get; set; }

        /// <summary>
        /// Gets or sets the hours of operation.
        /// </summary>
        /// <value>
        /// The hours of operation.
        /// </value>
        public double HoursOfOperation { get; set; }

        /// <summary>
        /// Gets or sets the pressure scale.
        /// </summary>
        /// <value>
        /// The pressure scale.
        /// </value>
        public double PressureScale { get; set; } = -1;

        /// <summary>
        /// Gets or sets the temperature scale.
        /// </summary>
        /// <value>
        /// The temperature scale.
        /// </value>
        public double TempScale { get; set; } = -1;

        /// <summary>
        /// Gets or sets the connection state.
        /// </summary>
        /// <value>
        /// The connection state.
        /// </value>
        public double ConnectionState { get; set; }

        #endregion Properties
    }
}