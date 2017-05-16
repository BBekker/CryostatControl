// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompressorViewModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The abstract view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using CryostatControlClient.Models;

    /// <summary>
    /// Compressor ViewModel
    /// </summary>
    public class CompressorViewModel : AbstractViewModel
    {
        #region Fields

        /// <summary>
        /// The compressor model
        /// </summary>
        private CompressorModel compressorModel;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CompressorViewModel"/> class.
        /// </summary>
        public CompressorViewModel()
        {
            this.compressorModel = new CompressorModel();
        }

        #endregion Constructor

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
                return this.compressorModel.OperatingState;
            }

            set
            {
                this.compressorModel.OperatingState = value;
                this.RaisePropertyChanged("OperatingState");
            }
        }

        /// <summary>
        /// Gets the operating state converted.
        /// </summary>
        public string OperatingStateConverted
        {
            get
            {
                return this.ConvertOperatingStateNumberToString(this.compressorModel.OperatingState);
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
                return this.compressorModel.CompressorRunning;
            }

            set
            {
                this.compressorModel.CompressorRunning = value;
                this.RaisePropertyChanged("CompressorRunning");
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
                return this.compressorModel.WarningState;
            }

            set
            {
                this.compressorModel.WarningState = value;
                this.RaisePropertyChanged("WarningState");
            }
        }

        public string WarningStateConverted
        {
            get
            {
                return this.ConvertWarningStateNumberToString(this.compressorModel.WarningState);
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
                return this.compressorModel.AlarmState;
            }

            set
            {
                this.compressorModel.AlarmState = value;
                this.RaisePropertyChanged("AlarmState");
            }
        }

        /// <summary>
        /// Gets the alarm state converted.
        /// </summary>
        public string AlarmStateConverted
        {
            get
            {
                return this.ConvertAlarmStateNumberToString(this.compressorModel.AlarmState);
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
                return this.compressorModel.CoolantInTemp;
            }

            set
            {
                this.compressorModel.CoolantInTemp = value;
                this.RaisePropertyChanged("CoolantInTemp");
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
                return this.compressorModel.CoolantOutTemp;
            }

            set
            {
                this.compressorModel.CoolantOutTemp = value;
                this.RaisePropertyChanged("CoolantOutTemp");
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
                return this.compressorModel.OilTemp;
            }

            set
            {
                this.compressorModel.OilTemp = value;
                this.RaisePropertyChanged("OilTemp");
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
                return this.compressorModel.HeliumTemp;
            }

            set
            {
                this.compressorModel.HeliumTemp = value;
                this.RaisePropertyChanged("HeliumTemp");
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
                return this.compressorModel.LowPressure;
            }

            set
            {
                this.compressorModel.LowPressure = value;
                this.RaisePropertyChanged("LowPressure");
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
                return this.compressorModel.LowPressureAverage;
            }

            set
            {
                this.compressorModel.LowPressureAverage = value;
                this.RaisePropertyChanged("LowPressureAverage");
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
                return this.compressorModel.HighPressure;
            }

            set
            {
                this.compressorModel.HighPressure = value;
                this.RaisePropertyChanged("HighPressure");
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
                return this.compressorModel.HighPressureAverage;
            }

            set
            {
                this.compressorModel.HighPressureAverage = value;
                this.RaisePropertyChanged("HighPressureAverage");
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
                return this.compressorModel.DeltaPressureAverage;
            }

            set
            {
                this.compressorModel.DeltaPressureAverage = value;
                this.RaisePropertyChanged("DeltaPressureAverage");
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
                return this.compressorModel.MotorCurrent;
            }

            set
            {
                this.compressorModel.MotorCurrent = value;
                this.RaisePropertyChanged("MotorCurrent");
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
                return this.compressorModel.HoursOfOperation;
            }

            set
            {
                this.compressorModel.HoursOfOperation = value;
                this.RaisePropertyChanged("HoursOfOperation");
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
                return this.compressorModel.PressureScale;
            }

            set
            {
                this.compressorModel.PressureScale = value;
                this.RaisePropertyChanged("PressureScale");
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
                return this.compressorModel.TempScale;
            }

            set
            {
                this.compressorModel.TempScale = value;
                this.RaisePropertyChanged("TempScale");
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
                return this.compressorModel.PanelSerialNumber;
            }

            set
            {
                this.compressorModel.PanelSerialNumber = value;
                this.RaisePropertyChanged("PanelSerialNumber");
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
                return this.compressorModel.ModelMajorMinorNumbers;
            }

            set
            {
                this.compressorModel.ModelMajorMinorNumbers = value;
                this.RaisePropertyChanged("ModelMajorMinorNumbers");
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
                return this.compressorModel.PowerOn;
            }

            set
            {
                this.compressorModel.PowerOn = value;
                this.RaisePropertyChanged("PowerOn");
            }
        }

        #endregion Properties

        /// <summary>
        /// Convert operating state number to string.
        /// </summary>
        /// <param name="operatingStateNumber">
        /// The operating state number.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ConvertOperatingStateNumberToString(int operatingStateNumber)
        {
            switch (operatingStateNumber)
            {
                case 0: return "Ready to Start";
                case 2: return "Starting";
                case 3: return "Running";
                case 5: return "Stopping";
                case 6: return "Error Lockout";
                case 7: return "Error";
                case 8: return "Helium Cool Down";
                case 9: return "Error Power Related";
                case 16: return "Error Recovery";
                default: return "No Information";
            }
        }

        /// <summary>
        /// Convert warning state number to string.
        /// </summary>
        /// <param name="warningStateNumber">
        /// The warning state number.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ConvertWarningStateNumberToString(int warningStateNumber)
        {
            switch (warningStateNumber)
            {
                case 0: return "No warnings";
                case -1: return "Coolant IN running High";
                case -2: return "Coolant IN running Low";
                case -4: return "Coolant OUT running High";
                case -8: return "Coolant OUT running Low";
                case -16: return "Oil running High";
                case -32: return "Oil running Low";
                case -64: return "Helium running High";
                case -128: return "Helium running Low";
                case -256: return "Low Pressure running High";
                case -512: return "Low Pressure running Low";
                case -1024: return "High Pressure running High";
                case -2048: return "High Pressure running Low";
                case -4096: return "Delta Pressure running High";
                case -8192: return "Delta Pressure running Low";
                case -131072: return "Static Pressure running High";
                case -262144: return "Static Pressure running Low";
                case -524288: return "Cold head motor Stall";
                default: return "No Information";
            }
        }

        /// <summary>
        /// Convert alarm state number to string.
        /// </summary>
        /// <param name="alarmStateNumber">
        /// The alarm state number.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ConvertAlarmStateNumberToString(int alarmStateNumber)
        {
            switch (alarmStateNumber)
            {
                case 0: return "No Errors";
                case -1: return "Coolant IN High";
                case -2: return "Coolant IN Low";
                case -4: return "Coolant OUT High";
                case -8: return "Coolant OUT Low";
                case -16: return "Oil High";
                case -32: return "Oil Low";
                case -64: return "Helium High";
                case -128: return "Helium Low";
                case -256: return "Low Pressure High";
                case -512: return "Low Pressure Low";
                case -1024: return "High Pressure High";
                case -2048: return "High Pressure Low";
                case -4096: return "Delta Pressure High";
                case -8192: return "Delta Pressure Low";
                case -16384: return "Motor Current Low";
                case -32768: return "Three Phase Error";
                case -65536: return "Power Supply Error";
                case -131072: return "Static Pressure High";
                case -262144: return "Static Pressure Low";
                default: return "No Information";
            }
        }
    }
}
