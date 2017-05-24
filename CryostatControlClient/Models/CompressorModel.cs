//-----------------------------------------------------------------------
// <copyright file="CompressorModel.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;

    using Dragablz.Dockablz;

    /// <summary>
    /// The compressor model.
    /// </summary>
    public class CompressorModel
    {
        #region Fields

        /// <summary>
        /// The operating state
        /// </summary>
        private double operatingState;

        /// <summary>
        /// The warning state
        /// </summary>
        private double warningState;

        /// <summary>
        /// The error state
        /// </summary>
        private double errorState;

        /// <summary>
        /// The water in temperature
        /// </summary>
        private double waterInTemp;

        /// <summary>
        /// The water out temperature
        /// </summary>
        private double waterOutTemp;

        /// <summary>
        /// The oil temperature
        /// </summary>
        private double oilTemp;

        /// <summary>
        /// The helium temperature
        /// </summary>
        private double heliumTemp;

        /// <summary>
        /// The low pressure
        /// </summary>
        private double lowPressure;

        /// <summary>
        /// The low pressure average
        /// </summary>
        private double lowPressureAverage;

        /// <summary>
        /// The high pressure
        /// </summary>
        private double highPressure;

        /// <summary>
        /// The high pressure average
        /// </summary>
        private double highPressureAverage;

        /// <summary>
        /// The delta pressure average
        /// </summary>
        private double deltaPressureAverage;

        /// <summary>
        /// The hours of operation
        /// </summary>
        private double hoursOfOperation;

        /// <summary>
        /// The pressure scale
        /// </summary>
        private double pressureScale;

        /// <summary>
        /// The temperature scale
        /// </summary>
        private double tempScale;

        /// <summary>
        /// The connection state
        /// </summary>
        private double connectionState;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the state of the operating.
        /// </summary>
        /// <value>
        /// The state of the operating.
        /// </value>
        public double OperatingState
        {
            get
            {
                return this.operatingState;
            }

            set
            {
                this.operatingState = value;
            }
        }

        /// <summary>
        /// Gets or sets the state of the warning.
        /// </summary>
        /// <value>
        /// The state of the warning.
        /// </value>
        public double WarningState
        {
            get
            {
                return this.warningState;
            }

            set
            {
                this.warningState = value;
            }
        }

        /// <summary>
        /// Gets or sets the state of the alarm.
        /// </summary>
        /// <value>
        /// The state of the alarm.
        /// </value>
        public double ErrorState
        {
            get
            {
                return this.errorState;
            }

            set
            {
                this.errorState = value;
            }
        }

        /// <summary>
        /// Gets or sets the coolant in temperature.
        /// </summary>
        /// <value>
        /// The coolant in temperature.
        /// </value>
        public double WaterInTemp
        {
            get
            {
                return this.waterInTemp;
            }

            set
            {
                this.waterInTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets the coolant out temperature.
        /// </summary>
        /// <value>
        /// The coolant out temperature.
        /// </value>
        public double WaterOutTemp
        {
            get
            {
                return this.waterOutTemp;
            }

            set
            {
                this.waterOutTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets the oil temperature.
        /// </summary>
        /// <value>
        /// The oil temperature.
        /// </value>
        public double OilTemp
        {
            get
            {
                return this.oilTemp;
            }

            set
            {
                this.oilTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets the helium temperature.
        /// </summary>
        /// <value>
        /// The helium temperature.
        /// </value>
        public double HeliumTemp
        {
            get
            {
                return this.heliumTemp;
            }

            set
            {
                this.heliumTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets the low pressure.
        /// </summary>
        /// <value>
        /// The low pressure.
        /// </value>
        public double LowPressure
        {
            get
            {
                return this.lowPressure;
            }

            set
            {
                this.lowPressure = value;
            }
        }

        /// <summary>
        /// Gets or sets the low pressure average.
        /// </summary>
        /// <value>
        /// The low pressure average.
        /// </value>
        public double LowPressureAverage
        {
            get
            {
                return this.lowPressureAverage;
            }

            set
            {
                this.lowPressureAverage = value;
            }
        }

        /// <summary>
        /// Gets or sets the high pressure.
        /// </summary>
        /// <value>
        /// The high pressure.
        /// </value>
        public double HighPressure
        {
            get
            {
                return this.highPressure;
            }

            set
            {
                this.highPressure = value;
            }
        }

        /// <summary>
        /// Gets or sets the high pressure average.
        /// </summary>
        /// <value>
        /// The high pressure average.
        /// </value>
        public double HighPressureAverage
        {
            get
            {
                return this.highPressureAverage;
            }

            set
            {
                this.highPressureAverage = value;
            }
        }

        /// <summary>
        /// Gets or sets the delta pressure average.
        /// </summary>
        /// <value>
        /// The delta pressure average.
        /// </value>
        public double DeltaPressureAverage
        {
            get
            {
                return this.deltaPressureAverage;
            }

            set
            {
                this.deltaPressureAverage = value;
            }
        }

        /// <summary>
        /// Gets or sets the hours of operation.
        /// </summary>
        /// <value>
        /// The hours of operation.
        /// </value>
        public double HoursOfOperation
        {
            get
            {
                return this.hoursOfOperation;
            }

            set
            {
                this.hoursOfOperation = value;
            }
        }

        /// <summary>
        /// Gets or sets the pressure scale.
        /// </summary>
        /// <value>
        /// The pressure scale.
        /// </value>
        public double PressureScale
        {
            get
            {
                return this.pressureScale;
            }

            set
            {
                this.pressureScale = value;
            }
        }

        /// <summary>
        /// Gets or sets the temperature scale.
        /// </summary>
        /// <value>
        /// The temperature scale.
        /// </value>
        public double TempScale
        {
            get
            {
                return this.tempScale;
            }

            set
            {
                this.tempScale = value;
            }
        }

        /// <summary>
        /// Gets or sets the connection state.
        /// </summary>
        /// <value>
        /// The connection state.
        /// </value>
        public double ConnectionState
        {
            get
            {
                return this.connectionState;
            }

            set
            {
                this.connectionState = value;
            }
        }

        #endregion Properties
    }
}