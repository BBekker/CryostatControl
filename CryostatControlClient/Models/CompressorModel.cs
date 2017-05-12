//-----------------------------------------------------------------------
// <copyright file="CompressorModel.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;

    /// <summary>
    /// Model for the compressor
    /// </summary>
    /// <seealso cref="CryostatControlClient.Models.AbstractModel" />
    public class CompressorModel : AbstractModel
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
        /// The coolant in temporary
        /// </summary>
        private int coolantInTemp;

        /// <summary>
        /// The coolant out temporary
        /// </summary>
        private int coolantOutTemp;

        /// <summary>
        /// The oil temporary
        /// </summary>
        private int oilTemp;

        /// <summary>
        /// The helium temporary
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
        /// The temporary scale
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
                this.OnPropertyChanged("OperatingState");
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
                this.OnPropertyChanged("CompressorRunning");
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
                this.OnPropertyChanged("WarningState");
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
                this.OnPropertyChanged("AlarmState");
            }
        }

        /// <summary>
        /// Gets or sets the coolant in temporary.
        /// </summary>
        /// <value>
        /// The coolant in temporary.
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
                this.OnPropertyChanged("CoolantInTemp");
            }
        }

        /// <summary>
        /// Gets or sets the coolant out temporary.
        /// </summary>
        /// <value>
        /// The coolant out temporary.
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
                this.OnPropertyChanged("CoolantOutTemp");
            }
        }

        /// <summary>
        /// Gets or sets the oil temporary.
        /// </summary>
        /// <value>
        /// The oil temporary.
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
                this.OnPropertyChanged("OilTemp");
            }
        }

        /// <summary>
        /// Gets or sets the helium temporary.
        /// </summary>
        /// <value>
        /// The helium temporary.
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
                this.OnPropertyChanged("HeliumTemp");
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
                this.OnPropertyChanged("LowPressure");
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
                this.OnPropertyChanged("LowPressureAverage");
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
                this.OnPropertyChanged("HighPressure");
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
                this.OnPropertyChanged("HighPressureAverage");
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
                this.OnPropertyChanged("DeltaPressureAverage");
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
                this.OnPropertyChanged("MotorCurrent");
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
                this.OnPropertyChanged("HoursOfOperation");
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
                this.OnPropertyChanged("PressureScale");
            }
        }

        /// <summary>
        /// Gets or sets the temporary scale.
        /// </summary>
        /// <value>
        /// The temporary scale.
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
                this.OnPropertyChanged("TempScale");
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
                this.OnPropertyChanged("PanelSerialNumber");
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
                this.OnPropertyChanged("ModelMajorMinorNumbers");
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
                this.OnPropertyChanged("PowerOn");
            }
        }

        #endregion Properties
    }
}