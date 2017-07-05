// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingViewModel.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using System.Windows.Media;

    using CryostatControlClient.Communication;
    using CryostatControlClient.Models;
    using CryostatControlClient.ViewModels.LoggingPresets;

    using CryostatControlServer.Data;

    /// <summary>
    /// The logging view model.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:PropertySummaryDocumentationMustMatchAccessors", Justification = "Reviewed, is ok here")]
    public class LoggingViewModel : AbstractViewModel
    {
        /// <summary>
        /// The logging model.
        /// </summary>
        private LoggingModel loggingModel;

        /// <summary>
        /// The logging preset
        /// </summary>
        private ILoggingPreset loggingPreset;

        /// <summary>
        /// The start button command
        /// </summary>
        private ICommand startButtonCommand;

        /// <summary>
        /// The cancel button command
        /// </summary>
        private ICommand cancelButtonCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggingViewModel"/> class.
        /// </summary>
        public LoggingViewModel()
        {
            this.loggingModel = new LoggingModel();
            this.StartButtonCommand = new RelayCommand(this.OnClickStart, param => true);
            this.CancelButtonCommand = new RelayCommand(this.OnClickCancel, param => true);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the he3 pump temperature.
        /// </summary>
        /// <value>
        /// The he3 pump temperature.
        /// </value>
        public bool He3PumpTemp
        {
            get
            {
                return this.loggingModel.He3PumpTemp;
            }

            set
            {
                this.loggingModel.He3PumpTemp = value;
                this.RaisePropertyChanged("He3PumpTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he3 head temperature.
        /// </summary>
        /// <value>
        /// The he3 head temperature.
        /// </value>
        public bool He3HeadTemp
        {
            get
            {
                return this.loggingModel.He3HeadTemp;
            }

            set
            {
                this.loggingModel.He3HeadTemp = value;
                this.RaisePropertyChanged("He3HeadTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he3 switch temperature.
        /// </summary>
        /// <value>
        /// The he3 switch temperature.
        /// </value>
        public bool He3SwitchTemp
        {
            get
            {
                return this.loggingModel.He3SwitchTemp;
            }

            set
            {
                this.loggingModel.He3SwitchTemp = value;
                this.RaisePropertyChanged("He3SwitchTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he4 pump temperature.
        /// </summary>
        /// <value>
        /// The he4 pump temperature.
        /// </value>
        public bool He4PumpTemp
        {
            get
            {
                return this.loggingModel.He4PumpTemp;
            }

            set
            {
                this.loggingModel.He4PumpTemp = value;
                this.RaisePropertyChanged("He4PumpTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he4 head temperature.
        /// </summary>
        /// <value>
        /// The he4 head temperature.
        /// </value>
        public bool He4HeadTemp
        {
            get
            {
                return this.loggingModel.He4HeadTemp;
            }

            set
            {
                this.loggingModel.He4HeadTemp = value;
                this.RaisePropertyChanged("He4HeadTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he4 switch temperature.
        /// </summary>
        /// <value>
        /// The he4 switch temperature.
        /// </value>
        public bool He4SwitchTemp
        {
            get
            {
                return this.loggingModel.He4SwitchTemp;
            }

            set
            {
                this.loggingModel.He4SwitchTemp = value;
                this.RaisePropertyChanged("He4SwitchTemp");
            }
        }

        /// <summary>
        /// Gets or sets the two k plate temperature.
        /// </summary>
        /// <value>
        /// The two k plate temperature.
        /// </value>
        public bool TwoKPlateTemp
        {
            get
            {
                return this.loggingModel.TwoKPlateTemp;
            }

            set
            {
                this.loggingModel.TwoKPlateTemp = value;
                this.RaisePropertyChanged("TwoKPlateTemp");
            }
        }

        /// <summary>
        /// Gets or sets the four k plate temperature.
        /// </summary>
        /// <value>
        /// The four k plate temperature.
        /// </value>
        public bool FourKPlateTemp
        {
            get
            {
                return this.loggingModel.FourKPlateTemp;
            }

            set
            {
                this.loggingModel.FourKPlateTemp = value;
                this.RaisePropertyChanged("FourKPlateTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he3 pump Volt.
        /// </summary>
        /// <value>
        /// The he3 pump Volt.
        /// </value>
        public bool He3PumpVolt
        {
            get
            {
                return this.loggingModel.He3PumpVolt;
            }

            set
            {
                this.loggingModel.He3PumpVolt = value;
                this.RaisePropertyChanged("He3PumpVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he3 switch Volt.
        /// </summary>
        /// <value>
        /// The he3 switch Volt.
        /// </value>
        public bool He3SwitchVolt
        {
            get
            {
                return this.loggingModel.He3SwitchVolt;
            }

            set
            {
                this.loggingModel.He3SwitchVolt = value;
                this.RaisePropertyChanged("He3SwitchVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he4 pump Volt.
        /// </summary>
        /// <value>
        /// The he4 pump Volt.
        /// </value>
        public bool He4PumpVolt
        {
            get
            {
                return this.loggingModel.He4PumpVolt;
            }

            set
            {
                this.loggingModel.He4PumpVolt = value;
                this.RaisePropertyChanged("He4PumpVolt");
            }
        }

        /// <summary>
        /// Gets or sets the he4 switch Volt.
        /// </summary>
        /// <value>
        /// The he4 switch Volt.
        /// </value>
        public bool He4SwitchVolt
        {
            get
            {
                return this.loggingModel.He4SwitchVolt;
            }

            set
            {
                this.loggingModel.He4SwitchVolt = value;
                this.RaisePropertyChanged("He4SwitchVolt");
            }
        }

        /// <summary>
        /// Gets or sets the bluefors50 k shield temperature.
        /// </summary>
        /// <value>
        /// The bluefors50 k shield temperature.
        /// </value>
        public bool Bluefors50KShieldTemp
        {
            get
            {
                return this.loggingModel.Bluefors50KShieldTemp;
            }

            set
            {
                this.loggingModel.Bluefors50KShieldTemp = value;
                this.RaisePropertyChanged("Bluefors50KShieldTemp");
            }
        }

        /// <summary>
        /// Gets or sets the bluefors3 k shield temperature.
        /// </summary>
        /// <value>
        /// The bluefors3 k shield temperature.
        /// </value>
        public bool Bluefors3KShieldTemp
        {
            get
            {
                return this.loggingModel.Bluefors3KShieldTemp;
            }

            set
            {
                this.loggingModel.Bluefors3KShieldTemp = value;
                this.RaisePropertyChanged("Bluefors3KShieldTemp");
            }
        }

        /// <summary>
        /// Gets or sets the compressor water in temperature.
        /// </summary>
        /// <value>
        /// The compressor water in temperature.
        /// </value>
        public bool CompressorWaterInTemp
        {
            get
            {
                return this.loggingModel.CompressorWaterInTemp;
            }

            set
            {
                this.loggingModel.CompressorWaterInTemp = value;
                this.RaisePropertyChanged("CompressorWaterInTemp");
            }
        }

        /// <summary>
        /// Gets or sets the compressor water out temperature.
        /// </summary>
        /// <value>
        /// The compressor water out temperature.
        /// </value>
        public bool CompressorWaterOutTemp
        {
            get
            {
                return this.loggingModel.CompressorWaterOutTemp;
            }

            set
            {
                this.loggingModel.CompressorWaterOutTemp = value;
                this.RaisePropertyChanged("CompressorWaterOutTemp");
            }
        }

        /// <summary>
        /// Gets or sets the compressor helium temperature.
        /// </summary>
        /// <value>
        /// The compressor helium temperature.
        /// </value>
        public bool CompressorHeliumTemp
        {
            get
            {
                return this.loggingModel.CompressorHeliumTemp;
            }

            set
            {
                this.loggingModel.CompressorHeliumTemp = value;
                this.RaisePropertyChanged("CompressorHeliumTemp");
            }
        }

        /// <summary>
        /// Gets or sets the compressor oil temperature.
        /// </summary>
        /// <value>
        /// The compressor oil temperature.
        /// </value>
        public bool CompressorOilTemp
        {
            get
            {
                return this.loggingModel.CompressorOilTemp;
            }

            set
            {
                this.loggingModel.CompressorOilTemp = value;
                this.RaisePropertyChanged("CompressorOilTemp");
            }
        }

        /// <summary>
        /// Gets or sets the compressor low pressure.
        /// </summary>
        /// <value>
        /// The compressor low pressure.
        /// </value>
        public bool CompressorLowPressure
        {
            get
            {
                return this.loggingModel.CompressorLowPressure;
            }

            set
            {
                this.loggingModel.CompressorLowPressure = value;
                this.RaisePropertyChanged("CompressorLowPressure");
            }
        }

        /// <summary>
        /// Gets or sets the compressor low average pressure.
        /// </summary>
        /// <value>
        /// The compressor low average pressure.
        /// </value>
        public bool CompressorLowAveragePressure
        {
            get
            {
                return this.loggingModel.CompressorLowAveragePressure;
            }

            set
            {
                this.loggingModel.CompressorLowAveragePressure = value;
                this.RaisePropertyChanged("CompressorLowAveragePressure");
            }
        }

        /// <summary>
        /// Gets or sets the compressor high pressure.
        /// </summary>
        /// <value>
        /// The compressor high pressure.
        /// </value>
        public bool CompressorHighPressure
        {
            get
            {
                return this.loggingModel.CompressorHighPressure;
            }

            set
            {
                this.loggingModel.CompressorHighPressure = value;
                this.RaisePropertyChanged("CompressorHighPressure");
            }
        }

        /// <summary>
        /// Gets or sets the compressor high average pressure.
        /// </summary>
        /// <value>
        /// The compressor high average pressure.
        /// </value>
        public bool CompressorHighAveragePressure
        {
            get
            {
                return this.loggingModel.CompressorHighAveragePressure;
            }

            set
            {
                this.loggingModel.CompressorHighAveragePressure = value;
                this.RaisePropertyChanged("CompressorHighAveragePressure");
            }
        }

        /// <summary>
        /// Gets or sets the compressor delta average pressure.
        /// </summary>
        /// <value>
        /// The compressor delta average pressure.
        /// </value>
        public bool CompressorDeltaAveragePressure
        {
            get
            {
                return this.loggingModel.CompressorDeltaAveragePressure;
            }

            set
            {
                this.loggingModel.CompressorDeltaAveragePressure = value;
                this.RaisePropertyChanged("CompressorDeltaAveragePressure");
            }
        }

        /// <summary>
        /// Gets or sets the logging interval.
        /// </summary>
        /// <value>
        /// The logging interval.
        /// </value>
        public double LoggingInterval
        {
            get
            {
                return this.loggingModel.LoggingInterval;
            }

            set
            {
                this.loggingModel.LoggingInterval = value;
                this.RaisePropertyChanged("LoggingInterval");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [logging in progress].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [logging in progress]; otherwise, <c>false</c>.
        /// </value>
        public bool LoggingInProgress
        {
            get
            {
                return this.loggingModel.LoggingInProgress;
            }

            set
            {
                this.loggingModel.LoggingInProgress = value;
                this.RaisePropertyChanged("LoggingInProgress");
                this.RaisePropertyChanged("LoggingInProgressColor");
                this.RaisePropertyChanged("LoggingInProgressReversed");
                this.RaisePropertyChanged("LoggingInProgressConverted");
            }
        }

        /// <summary>
        /// Gets a value indicating whether [logging in progress reversed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [logging in progress reversed]; otherwise, <c>false</c>.
        /// </value>
        public bool LoggingInProgressReversed
        {
            get
            {
                return !this.LoggingInProgress;
            }
        }

        /// <summary>
        /// Gets the logging in progress converted.
        /// </summary>
        /// <value>
        /// The logging in progress converted.
        /// </value>
        public string LoggingInProgressConverted
        {
            get
            {
                return this.loggingModel.LoggingInProgress ? "Currently logging" : "Currently not logging";
            }
        }

        /// <summary>
        /// Gets the color of the logging in progress.
        /// </summary>
        /// <value>
        /// The color of the logging in progress.
        /// </value>
        public SolidColorBrush LoggingInProgressColor
        {
            get
            {
                return this.loggingModel.LoggingInProgress ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
            }
        }

        /// <summary>
        /// Gets or sets the preset ComboBox.
        /// </summary>
        /// <value>
        /// The preset ComboBox.
        /// </value>
        public int PresetComboBox
        {
            get
            {
                return this.loggingModel.PresetComboBox;
            }

            set
            {
                this.loggingModel.PresetComboBox = value;
                this.ConvertIntToPreset(value);
                this.RaisePropertyChanged("PresetComboBox");
            }
        }

        #endregion

        /// <summary>
        /// Gets or sets the start button command.
        /// </summary>
        /// <value>
        /// The start button command.
        /// </value>
        public ICommand StartButtonCommand
        {
            get
            {
                return this.startButtonCommand;
            }

            set
            {
                this.startButtonCommand = value;
            }
        }

        /// <summary>
        /// Gets or sets the cancel button command.
        /// </summary>
        /// <value>
        /// The cancel button command.
        /// </value>
        public ICommand CancelButtonCommand
        {
            get
            {
                return this.cancelButtonCommand;
            }

            set
            {
                this.cancelButtonCommand = value;
            }
        }

        /// <summary>
        /// Converts the integer to preset.
        /// </summary>
        /// <param name="presetNumber">The preset number.</param>
        public void ConvertIntToPreset(int presetNumber)
        {
            switch (presetNumber)
            {
                case 0:
                    this.loggingPreset = new LogNothingPreset(this);
                    break;
                case 1:
                    this.loggingPreset = new LogAllPreset(this);
                    break;
                case 2:
                    this.loggingPreset = new LogCompressorPreset(this);
                    break;
                case 3:
                    this.loggingPreset = new LogHe7Preset(this);
                    break;
                case 4:
                    this.loggingPreset = new LogBlueforsPreset(this);
                    break;
            }
        }

        /// <summary>
        /// Get the logging array.
        /// </summary>
        /// <returns>
        /// The <see cref="double[]"/>.
        /// </returns>
        public bool[] GetLoggingArray()
        {
            bool[] loggingDataArray = new bool[(int)DataEnumerator.DataLength];
            loggingDataArray[(int)DataEnumerator.LakePlate50K] = this.Bluefors50KShieldTemp;
            loggingDataArray[(int)DataEnumerator.LakePlate3K] = this.Bluefors3KShieldTemp;
            loggingDataArray[(int)DataEnumerator.ComWaterIn] = this.CompressorWaterInTemp;
            loggingDataArray[(int)DataEnumerator.ComWaterOut] = this.CompressorWaterOutTemp;
            loggingDataArray[(int)DataEnumerator.ComHelium] = this.CompressorHeliumTemp;
            loggingDataArray[(int)DataEnumerator.ComOil] = this.CompressorOilTemp;
            loggingDataArray[(int)DataEnumerator.ComLow] = this.CompressorLowPressure;
            loggingDataArray[(int)DataEnumerator.ComLowAvg] = this.CompressorLowAveragePressure;
            loggingDataArray[(int)DataEnumerator.ComHigh] = this.CompressorHighPressure;
            loggingDataArray[(int)DataEnumerator.ComHighAvg] = this.CompressorHighAveragePressure;
            loggingDataArray[(int)DataEnumerator.ComDeltaAvg] = this.CompressorDeltaAveragePressure;
            loggingDataArray[(int)DataEnumerator.He3Pump] = this.He3PumpTemp;
            loggingDataArray[(int)DataEnumerator.HePlate2K] = this.TwoKPlateTemp;
            loggingDataArray[(int)DataEnumerator.HePlate4K] = this.FourKPlateTemp;
            loggingDataArray[(int)DataEnumerator.He3Head] = this.He3HeadTemp;
            loggingDataArray[(int)DataEnumerator.He4Pump] = this.He4PumpTemp;
            loggingDataArray[(int)DataEnumerator.He4SwitchTemp] = this.He4SwitchTemp;
            loggingDataArray[(int)DataEnumerator.He3SwitchTemp] = this.He3SwitchTemp;
            loggingDataArray[(int)DataEnumerator.He4Head] = this.He4HeadTemp;
            loggingDataArray[(int)DataEnumerator.He3VoltActual] = this.He3PumpVolt;
            loggingDataArray[(int)DataEnumerator.He4SwitchVoltActual] = this.He4SwitchVolt;
            loggingDataArray[(int)DataEnumerator.He3SwitchVoltActual] = this.He3SwitchVolt;
            loggingDataArray[(int)DataEnumerator.He4VoltActual] = this.He4PumpVolt;

            return loggingDataArray;
        }

        /// <summary>
        /// The on click start.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        public void OnClickStart(object obj)
        {
            ServerCheck.SendMessage(new Task(() => { this.StartLogging(); }));
        }

        /// <summary>
        /// The on click cancel.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        public void OnClickCancel(object obj)
        {
            ServerCheck.SendMessage(new Task(() => { ServerCheck.CommandClient.CancelLogging(); }));
        }

        /// <summary>
        /// Starts the logging.
        /// </summary>
        private void StartLogging()
        {
            bool[] dataToBeLogged = this.GetLoggingArray();
            int interval = (int)this.LoggingInterval;
            ServerCheck.CommandClient.StartLogging(interval, dataToBeLogged);
        }
    }
}
