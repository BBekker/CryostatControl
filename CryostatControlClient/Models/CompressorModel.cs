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
        private float operatingState;

        /// <summary>
        /// The warning state
        /// </summary>
        private float warningState;

        /// <summary>
        /// The error state
        /// </summary>
        private float errorState;

        /// <summary>
        /// The water in temperature
        /// </summary>
        private float waterInTemp;

        /// <summary>
        /// The water out temperature
        /// </summary>
        private float waterOutTemp;

        /// <summary>
        /// The oil temperature
        /// </summary>
        private float oilTemp;

        /// <summary>
        /// The helium temperature
        /// </summary>
        private float heliumTemp;

        /// <summary>
        /// The low pressure
        /// </summary>
        private float lowPressure;

        /// <summary>
        /// The low pressure average
        /// </summary>
        private float lowPressureAverage;

        /// <summary>
        /// The high pressure
        /// </summary>
        private float highPressure;

        /// <summary>
        /// The high pressure average
        /// </summary>
        private float highPressureAverage;

        /// <summary>
        /// The delta pressure average
        /// </summary>
        private float deltaPressureAverage;

        /// <summary>
        /// The hours of operation
        /// </summary>
        private float hoursOfOperation;

        /// <summary>
        /// The pressure scale
        /// </summary>
        private string pressureScale;

        /// <summary>
        /// The temperature scale
        /// </summary>
        private string tempScale;

        /// <summary>
        /// The connection state
        /// </summary>
        private float connectionState;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the state of the operating.
        /// </summary>
        /// <value>
        /// The state of the operating.
        /// </value>
        public float OperatingState
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
        public float WarningState
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
        public float ErrorState
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
        public float WaterInTemp
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
        public float WaterOutTemp
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
        public float OilTemp
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
        public float HeliumTemp
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
        public float LowPressure
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
        public float LowPressureAverage
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
        public float HighPressure
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
        public float HighPressureAverage
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
        public float DeltaPressureAverage
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
        public float HoursOfOperation
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
        public string PressureScale
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
        public string TempScale
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
        public float ConnectionState
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