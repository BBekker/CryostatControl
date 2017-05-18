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
    using System;
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
        public double OperatingState
        {
            get
            {
                return this.compressorModel.OperatingState;
            }

            set
            {
                this.compressorModel.OperatingState = value;
                this.RaisePropertyChanged("OperatingState");
                this.RaisePropertyChanged("OperatingStateConverted");
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
        /// Gets or sets the state of the warning.
        /// </summary>
        /// <value>
        /// The state of the warning.
        /// </value>
        public double WarningState
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

        /// <summary>
        /// Gets the warning state converted.
        /// </summary>
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
        public double ErrorState
        {
            get
            {
                return this.compressorModel.ErrorState;
            }

            set
            {
                this.compressorModel.ErrorState = value;
                this.RaisePropertyChanged("ErrorState");
            }
        }

        /// <summary>
        /// Gets the alarm state converted.
        /// </summary>
        public string ErrorStateConverted
        {
            get
            {
                return this.ConvertErrorStateNumberToString(this.compressorModel.ErrorState);
            }
        }

        /// <summary>
        /// Gets or sets the Water in temperature.
        /// </summary>
        /// <value>
        /// The Water in temperature.
        /// </value>
        public double WaterInTemp
        {
            get
            {
                return this.compressorModel.WaterInTemp;
            }

            set
            {
                this.compressorModel.WaterInTemp = value;
                this.RaisePropertyChanged("WaterInTemp");
            }
        }

        /// <summary>
        /// Gets or sets the Water out temperature.
        /// </summary>
        /// <value>
        /// The Water out temperature.
        /// </value>
        public double WaterOutTemp
        {
            get
            {
                return this.compressorModel.WaterOutTemp;
            }

            set
            {
                this.compressorModel.WaterOutTemp = value;
                this.RaisePropertyChanged("WaterOutTemp");
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
                return this.compressorModel.OilTemp;
            }

            set
            {
                this.compressorModel.OilTemp = value;
                this.RaisePropertyChanged("OilTemp");
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
        public double LowPressure
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
        public double LowPressureAverage
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
        public double HighPressure
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
        public double HighPressureAverage
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
        public double DeltaPressureAverage
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
        /// Gets or sets the hours of operation.
        /// </summary>
        /// <value>
        /// The hours of operation.
        /// </value>
        public double HoursOfOperation
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
        public string PressureScale
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
        /// Gets or sets the temperature scale.
        /// </summary>
        /// <value>
        /// The temperature scale.
        /// </value>
        public string TempScale
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
        /// Gets or sets a value indicating whether [power on].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [power on]; otherwise, <c>false</c>.
        /// </value>
        public double ConnectionState
        {
            get
            {
                return this.compressorModel.ConnectionState;
            }

            set
            {
                this.compressorModel.ConnectionState = value;
                this.RaisePropertyChanged("ConnectionState");
                this.RaisePropertyChanged("ConnectionStateConverted");
            }
        }

        /// <summary>
        /// Gets the connection state converted.
        /// </summary>
        public string ConnectionStateConverted
        {
            get
            {
                return this.ConvertConnectionStateNumberToString(this.compressorModel.ConnectionState);
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
        public string ConvertOperatingStateNumberToString(double operatingStateNumber)
        {
            switch ((int)operatingStateNumber)
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
        public string ConvertWarningStateNumberToString(double warningStateNumber)
        {
            switch ((int)warningStateNumber)
            {
                case 0: return "No warnings";
                case -1: return "Water IN running High";
                case -2: return "Water IN running Low";
                case -4: return "Water OUT running High";
                case -8: return "Water OUT running Low";
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
        /// <param name="errorStateNumber">
        /// The alarm state number.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ConvertErrorStateNumberToString(double errorStateNumber)
        {
            switch ((int)errorStateNumber)
            {
                case 0: return "No Errors";
                case -1: return "Water IN High";
                case -2: return "Water IN Low";
                case -4: return "Water OUT High";
                case -8: return "Water OUT Low";
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
