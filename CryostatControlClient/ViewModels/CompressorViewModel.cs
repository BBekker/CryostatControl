// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompressorViewModel.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using System.Windows.Input;
    using System.Windows.Media;

    using CryostatControlClient.Communication;
    using CryostatControlClient.Models;

    /// <summary>
    /// Compressor ViewModel
    /// </summary>
    public class CompressorViewModel : AbstractViewModel
    {
        #region Fields

        /// <summary>
        /// The water in minimum
        /// </summary>
        private const int WaterInMinimum = 10;

        /// <summary>
        /// The water in maximum
        /// </summary>
        private const int WaterInMaximum = 44;

        /// <summary>
        /// The water out minimum
        /// </summary>
        private const int WaterOutMinimum = 10;

        /// <summary>
        /// The water out maximum
        /// </summary>
        private const int WaterOutMaximum = 51;

        /// <summary>
        /// The helium minimum
        /// </summary>
        private const int HeliumMinimum = 10;

        /// <summary>
        /// The helium maximum
        /// </summary>
        private const int HeliumMaximum = 87;

        /// <summary>
        /// The oil minimum
        /// </summary>
        private const int OilMinimum = 10;

        /// <summary>
        /// The oil maximum
        /// </summary>
        private const int OilMaximum = 51;

        /// <summary>
        /// No information string used when dictionary has no correct data
        /// </summary>
        private const string NoInformation = "No information";

        /// <summary>
        /// The compressor model
        /// </summary>
        private CompressorModel compressorModel;

        /// <summary>
        /// The switch command
        /// </summary>
        private ICommand turnOnCommand;

        /// <summary>
        /// The switch command
        /// </summary>
        private ICommand turnOffCommand;

        /// <summary>
        /// The operating state dictionary
        /// </summary>
        private Dictionary<int, string> operatingStateDictionary =
            new Dictionary<int, string>
                {
                    { -1, "Disconnected" },
                    { 0, "Ready to Start" },
                    { 2, "Starting" },
                    { 3, "Running" },
                    { 5, "Stopping" },
                    { 6, "Error Lockout" },
                    { 7, "Error" },
                    { 8, "Helium Cool Down" },
                    { 9, "Error Power Related" },
                    { 16, "Error Recovery" }
                };

        /// <summary>
        /// The warning state dictionary
        /// </summary>
        private Dictionary<int, string> warningStateDictionary =
            new Dictionary<int, string>
                {
                    { 0, "No warnings" },
                    { -1, "Water IN running High" },
                    { -2, "Water IN running Low" },
                    { -4, "Water OUT running High" },
                    { -8, "Water OUT running Low" },
                    { -16, "Oil running High" },
                    { -32, "Oil running Low" },
                    { -64, "Helium running High" },
                    { -128, "Helium running Low" },
                    { -256, "Low Pressure running High" },
                    { -512, "Low Pressure running Low" },
                    { -1024, "High Pressure running High" },
                    { -2048, "High Pressure running Low" },
                    { -4096, "Delta Pressure running High" },
                    { -8192, "Delta Pressure running Low" },
                    { -131072, "Static Pressure running High" },
                    { -262144, "Static Pressure running Low" },
                    { -524288, "Cold head motor Stall" }
                };

        /// <summary>
        /// The error state dictionary
        /// </summary>
        private Dictionary<int, string> errorStateDictionary =
            new Dictionary<int, string>
                {
                    { 0, "No Errors" },
                    { -1, "Water IN High" },
                    { -2, "Water IN Low" },
                    { -4, "Water OUT High" },
                    { -8, "Water OUT Low" },
                    { -16, "Oil High" },
                    { -32, "Oil Low" },
                    { -64, "Helium High" },
                    { -128, "Helium Low" },
                    { -256, "Low Pressure High" },
                    { -512, "Low Pressure Low" },
                    { -1024, "High Pressure High" },
                    { -2048, "High Pressure Low" },
                    { -4096, "Delta Pressure High" },
                    { -8192, "Delta Pressure Low" },
                    { -16384, "Motor Current Low" },
                    { -32768, "Three Phase Error" },
                    { -65536, "Power Supply Error" },
                    { -131072, "Static Pressure High" },
                    { -262144, "Static Pressure Low" },
                };

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CompressorViewModel"/> class.
        /// </summary>
        public CompressorViewModel()
        {
            this.compressorModel = new CompressorModel();

            this.turnOnCommand = new RelayCommand(this.TurnOn, param => true);
            this.turnOffCommand = new RelayCommand(this.TurnOff, param => true);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the color of the connection state.
        /// </summary>
        /// <value>
        /// The color of the connection state.
        /// </value>
        public SolidColorBrush ConnectionStateColor
        {
            get
            {
                return this.DisplayColor((ColorState)this.ConnectionState);
            }
        }

        /// <summary>
        /// Gets the switch command.
        /// </summary>
        /// <value>
        /// The switch command.
        /// </value>
        public ICommand TurnOnCommand
        {
            get
            {
                return this.turnOnCommand;
            }
        }

        /// <summary>
        /// Gets the turn off command.
        /// </summary>
        /// <value>
        /// The turn off command.
        /// </value>
        public ICommand TurnOffCommand
        {
            get
            {
                return this.turnOffCommand;
            }
        }

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
                this.RaisePropertyChanged("CanTurnOn");
                this.RaisePropertyChanged("CanTurnOff");
            }
        }

        /// <summary>
        /// Gets the operating state converted.
        /// </summary>
        public string OperatingStateConverted
        {
            get
            {
                string state;
                return this.operatingStateDictionary.TryGetValue((int)this.compressorModel.OperatingState, out state) ? state : NoInformation;
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
                string state;
                return this.warningStateDictionary.TryGetValue((int)this.compressorModel.WarningState, out state) ? state : NoInformation;
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
                string state;
                return this.errorStateDictionary.TryGetValue((int)this.compressorModel.ErrorState, out state) ? state : NoInformation;
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
                this.RaisePropertyChanged("WaterInTempProgressbar");
                this.RaisePropertyChanged("WaterInTempColor");
            }
        }

        /// <summary>
        /// Gets the water in temporary progressbar.
        /// </summary>
        /// <value>
        /// The water in temporary progressbar.
        /// </value>
        public double WaterInTempProgressbar
        {
            get
            {
                return this.ConvertNanToZeroIfNan(this.compressorModel.WaterInTemp);
            }
        }

        /// <summary>
        /// Gets the color of the water in temporary.
        /// </summary>
        /// <value>
        /// The color of the water in temporary.
        /// </value>
        public SolidColorBrush WaterInTempColor
        {
            get
            {
                if (this.compressorModel.WaterInTemp < WaterInMinimum
                    || this.compressorModel.WaterInTemp > WaterInMaximum)
                {
                    return this.DisplayColor(ColorState.Red);
                }

                return this.DisplayColor(ColorState.Green);
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
                this.RaisePropertyChanged("WaterOutTempProgressbar");
                this.RaisePropertyChanged("WaterOutTempColor");
            }
        }

        /// <summary>
        /// Gets the water out temporary progressbar.
        /// </summary>
        /// <value>
        /// The water out temporary progressbar.
        /// </value>
        public double WaterOutTempProgressbar
        {
            get
            {
                return this.ConvertNanToZeroIfNan(this.compressorModel.WaterOutTemp);
            }
        }

        /// <summary>
        /// Gets the color of the water out temporary.
        /// </summary>
        /// <value>
        /// The color of the water out temporary.
        /// </value>
        public SolidColorBrush WaterOutTempColor
        {
            get
            {
                if (this.compressorModel.WaterOutTemp < WaterOutMinimum
                    || this.compressorModel.WaterOutTemp > WaterOutMaximum)
                {
                    return this.DisplayColor(ColorState.Red);
                }

                return this.DisplayColor(ColorState.Green);
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
                this.RaisePropertyChanged("OilTempProgressbar");
                this.RaisePropertyChanged("OilTempColor");
            }
        }

        /// <summary>
        /// Gets the oil temporary progressbar.
        /// </summary>
        /// <value>
        /// The oil temporary progressbar.
        /// </value>
        public double OilTempProgressbar
        {
            get
            {
                return this.ConvertNanToZeroIfNan(this.compressorModel.OilTemp);
            }
        }

        /// <summary>
        /// Gets the color of the oil temporary.
        /// </summary>
        /// <value>
        /// The color of the oil temporary.
        /// </value>
        public SolidColorBrush OilTempColor
        {
            get
            {
                if (this.compressorModel.OilTemp < OilMinimum
                    || this.compressorModel.OilTemp > OilMaximum)
                {
                    return this.DisplayColor(ColorState.Red);
                }

                return this.DisplayColor(ColorState.Green);
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
                this.RaisePropertyChanged("HeliumTempProgressbar");
                this.RaisePropertyChanged("HeliumTempColor");
            }
        }

        /// <summary>
        /// Gets the helium temporary progressbar.
        /// </summary>
        /// <value>
        /// The helium temporary progressbar.
        /// </value>
        public double HeliumTempProgressbar
        {
            get
            {
                return this.ConvertNanToZeroIfNan(this.compressorModel.HeliumTemp);
            }
        }

        /// <summary>
        /// Gets the color of the helium temporary.
        /// </summary>
        /// <value>
        /// The color of the helium temporary.
        /// </value>
        public SolidColorBrush HeliumTempColor
        {
            get
            {
                if (this.compressorModel.HeliumTemp < HeliumMinimum || this.compressorModel.HeliumTemp > HeliumMaximum)
                {
                    return this.DisplayColor(ColorState.Red);
                }

                return this.DisplayColor(ColorState.Green);
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
                this.RaisePropertyChanged("LowPressureGauge");
            }
        }

        /// <summary>
        /// Gets the low pressure gauge.
        /// </summary>
        /// <value>
        /// The low pressure gauge.
        /// </value>
        public double LowPressureGauge
        {
            get
            {
                return this.ConvertNanToZeroIfNan(this.compressorModel.LowPressure);
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
                this.RaisePropertyChanged("HighPressureGauge");
            }
        }

        /// <summary>
        /// Gets the high pressure gauge.
        /// </summary>
        /// <value>
        /// The high pressure gauge.
        /// </value>
        public double HighPressureGauge
        {
            get
            {
                return this.ConvertNanToZeroIfNan(this.compressorModel.HighPressure);
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
        public double PressureScale
        {
            get
            {
                return this.compressorModel.PressureScale;
            }

            set
            {
                this.compressorModel.PressureScale = value;
                this.RaisePropertyChanged("PressureScale");
                this.RaisePropertyChanged("PressureScaleConverted");
            }
        }

        /// <summary>
        /// Gets the pressure scale converted.
        /// </summary>
        /// <value>
        /// The pressure scale converted.
        /// </value>
        public string PressureScaleConverted
        {
            get
            {
                return this.ConvertPressureScaleToString((int)this.compressorModel.PressureScale);
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
                return this.compressorModel.TempScale;
            }

            set
            {
                this.compressorModel.TempScale = value;
                this.RaisePropertyChanged("TempScale");
                this.RaisePropertyChanged("TempScaleConverted");
            }
        }

        /// <summary>
        /// Gets the temperature scale converted.
        /// </summary>
        /// <value>
        /// The temporary scale converted.
        /// </value>
        public string TempScaleConverted
        {
            get
            {
                return this.ConvertTempScaleToString((int)this.compressorModel.TempScale);
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
                this.RaisePropertyChanged("ConnectionStateColor");
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

        /// <summary>
        /// Gets a value indicating whether this instance can turn on.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can turn on; otherwise, <c>false</c>.
        /// </value>
        public bool CanTurnOn
        {
            get
            {
                return this.CheckTurnOn();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance can turn off.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can turn off; otherwise, <c>false</c>.
        /// </value>
        public bool CanTurnOff
        {
            get
            {
                return this.CheckTurnOff();
            }
        }

        #endregion Properties

        #region Methods
  
        /// <summary>
        /// Converts the nan to zero if nan.
        /// </summary>
        /// <param name="possibleNan">The possible nan.</param>
        /// <returns>0 if Nan; Normal value otherwise</returns>
        public double ConvertNanToZeroIfNan(double possibleNan)
        {
            if (double.IsNaN(possibleNan))
            {
                return 0;
            }

            return possibleNan;
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void TurnOn(object obj)
        {
            ServerCheck.SendMessage(new Task(() => { ServerCheck.CommandClient.SetCompressorState(true); }));
        }

        /// <summary>
        /// Turns the off.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void TurnOff(object obj)
        {
            ServerCheck.SendMessage(new Task(() => { ServerCheck.CommandClient.SetCompressorState(false); }));
        }

        /// <summary>
        /// Checks the turn on.
        /// </summary>
        /// <returns> 
        /// True if the compressor is ready to start, false otherwise.
        /// </returns>
        private bool CheckTurnOn()
        {
            switch ((int)this.OperatingState)
            {
                case 0: return true;
                default: return false;
            }
        }

        /// <summary>
        /// Checks the turn off.
        /// </summary>
        /// <returns>
        /// True if the compressor is running, false otherwise.
        /// </returns>
        private bool CheckTurnOff()
        {
            switch ((int)this.OperatingState)
            {
                case 3: return true;
                default: return false;
            }
        }
        
        /// <summary>
        /// Converts the temperature scale to string.
        /// </summary>
        /// <param name="scale">The scale.</param>
        /// <returns>Converted scale</returns>
        private string ConvertTempScaleToString(int scale)
        {
            switch (scale)
            {
                case 0: return "F";
                case 1: return "C";
                case 2: return "K";
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts the pressure scale to string.
        /// </summary>
        /// <param name="scale">The scale.</param>
        /// <returns>Converted string</returns>
        private string ConvertPressureScaleToString(int scale)
        {
            switch (scale)
            {
                case 0: return "PSI";
                case 1: return "Bar";
                case 2: return "KPA";
            }

            return string.Empty;
        }

        #endregion Methods
    }
}