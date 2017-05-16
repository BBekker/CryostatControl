//-----------------------------------------------------------------------
// <copyright file="CompressorModel.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;

    /// <summary>
    /// The compressor model.
    /// </summary>
    public class CompressorModel
    {
        #region Fields

        /// <summary>
        /// The operating state
        /// </summary>
        private int operatingState;

        /// <summary>
        /// The compressor running
        /// </summary>
        private int compressorRunning;

        /// <summary>
        /// The warning state
        /// </summary>
        private int warningState;

        /// <summary>
        /// The alarm state
        /// </summary>
        private int alarmState;

        /// <summary>
        /// The coolant in temperature
        /// </summary>
        private int coolantInTemp;

        /// <summary>
        /// The coolant out temperature
        /// </summary>
        private int coolantOutTemp;

        /// <summary>
        /// The oil temperature
        /// </summary>
        private int oilTemp;

        /// <summary>
        /// The helium temperature
        /// </summary>
        private int heliumTemp;

        /// <summary>
        /// The low pressure
        /// </summary>
        private int lowPressure;

        /// <summary>
        /// The low pressure average
        /// </summary>
        private int lowPressureAverage;

        /// <summary>
        /// The high pressure
        /// </summary>
        private int highPressure;

        /// <summary>
        /// The high pressure average
        /// </summary>
        private int highPressureAverage;

        /// <summary>
        /// The delta pressure average
        /// </summary>
        private int deltaPressureAverage;

        /// <summary>
        /// The motor current
        /// </summary>
        private int motorCurrent;

        /// <summary>
        /// The hours of operation
        /// </summary>
        private int hoursOfOperation;

        /// <summary>
        /// The pressure scale
        /// </summary>
        private int pressureScale;

        /// <summary>
        /// The temperature scale
        /// </summary>
        private int tempScale;

        /// <summary>
        /// The panel serial number
        /// </summary>
        private int panelSerialNumber;

        /// <summary>
        /// The model major minor numbers
        /// </summary>
        private int modelMajorMinorNumbers;

        /// <summary>
        /// The power on
        /// </summary>
        private bool powerOn;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the state of the operating.
        /// </summary>
        /// <value>
        /// The state of the operating.
        /// </value>
        public int OperatingState
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
        /// Gets or sets the compressor running.
        /// </summary>
        /// <value>
        /// The compressor running.
        /// </value>
        public int CompressorRunning
        {
            get
            {
                return this.compressorRunning;
            }

            set
            {
                this.compressorRunning = value;
            }
        }

        /// <summary>
        /// Gets or sets the state of the warning.
        /// </summary>
        /// <value>
        /// The state of the warning.
        /// </value>
        public int WarningState
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
        public int AlarmState
        {
            get
            {
                return this.alarmState;
            }

            set
            {
                this.alarmState = value;
            }
        }

        /// <summary>
        /// Gets or sets the coolant in temperature.
        /// </summary>
        /// <value>
        /// The coolant in temperature.
        /// </value>
        public int CoolantInTemp
        {
            get
            {
                return this.coolantInTemp;
            }

            set
            {
                this.coolantInTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets the coolant out temperature.
        /// </summary>
        /// <value>
        /// The coolant out temperature.
        /// </value>
        public int CoolantOutTemp
        {
            get
            {
                return this.coolantOutTemp;
            }

            set
            {
                this.coolantOutTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets the oil temperature.
        /// </summary>
        /// <value>
        /// The oil temperature.
        /// </value>
        public int OilTemp
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
        public int HeliumTemp
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
        public int LowPressure
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
        public int LowPressureAverage
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
        public int HighPressure
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
        public int HighPressureAverage
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
        public int DeltaPressureAverage
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
        /// Gets or sets the motor current.
        /// </summary>
        /// <value>
        /// The motor current.
        /// </value>
        public int MotorCurrent
        {
            get
            {
                return this.motorCurrent;
            }

            set
            {
                this.motorCurrent = value;
            }
        }

        /// <summary>
        /// Gets or sets the hours of operation.
        /// </summary>
        /// <value>
        /// The hours of operation.
        /// </value>
        public int HoursOfOperation
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
        public int PressureScale
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
        public int TempScale
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
        /// Gets or sets the panel serial number.
        /// </summary>
        /// <value>
        /// The panel serial number.
        /// </value>
        public int PanelSerialNumber
        {
            get
            {
                return this.panelSerialNumber;
            }

            set
            {
                this.panelSerialNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the model major minor numbers.
        /// </summary>
        /// <value>
        /// The model major minor numbers.
        /// </value>
        public int ModelMajorMinorNumbers
        {
            get
            {
                return this.modelMajorMinorNumbers;
            }

            set
            {
                this.modelMajorMinorNumbers = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [power on].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [power on]; otherwise, <c>false</c>.
        /// </value>
        public bool PowerOn
        {
            get
            {
                return this.powerOn;
            }

            set
            {
                this.powerOn = value;
            }
        }

        #endregion Properties
    }
}