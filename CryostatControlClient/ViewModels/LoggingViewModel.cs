// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingViewModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the LoggingViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System;

    using CryostatControlClient.Models;
    using CryostatControlClient.ViewModels.LoggingPresets;

    /// <summary>
    /// The logging view model.
    /// </summary>
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
        /// Initializes a new instance of the <see cref="LoggingViewModel"/> class.
        /// </summary>
        public LoggingViewModel()
        {
            //this.loggingPreset = new LogAllPreset(this);
            this.loggingModel = new LoggingModel();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the he3 cold head temperature.
        /// </summary>
        /// <value>
        /// The he3 cold head temperature.
        /// </value>
        public bool He3ColdHeadTemp
        {
            get
            {
                return this.loggingModel.He3ColdHeadTemp;
            }

            set
            {
                this.loggingModel.He3ColdHeadTemp = value;
                this.RaisePropertyChanged("He3ColdHeadTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he3 warm head temperature.
        /// </summary>
        /// <value>
        /// The he3 warm head temperature.
        /// </value>
        public bool He3WarmHeadTemp
        {
            get
            {
                return this.loggingModel.He3WarmHeadTemp;
            }

            set
            {
                this.loggingModel.He3WarmHeadTemp = value;
                this.RaisePropertyChanged("He3WarmHeadTemp");
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
        /// Gets or sets the he4 cold head temperature.
        /// </summary>
        /// <value>
        /// The he4 cold head temperature.
        /// </value>
        public bool He4ColdHeadTemp
        {
            get
            {
                return this.loggingModel.He4ColdHeadTemp;
            }

            set
            {
                this.loggingModel.He4ColdHeadTemp = value;
                this.RaisePropertyChanged("He4ColdHeadTemp");
            }
        }

        /// <summary>
        /// Gets or sets the he4 warm head temperature.
        /// </summary>
        /// <value>
        /// The he4 warm head temperature.
        /// </value>
        public bool He4WarmHeadTemp
        {
            get
            {
                return this.loggingModel.He4WarmHeadTemp;
            }

            set
            {
                this.loggingModel.He4WarmHeadTemp = value;
                this.RaisePropertyChanged("He4WarmHeadTemp");
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
        /// Gets or sets the bluefors heater.
        /// </summary>
        /// <value>
        /// The bluefors heater.
        /// </value>
        public bool BlueforsHeater
        {
            get
            {
                return this.loggingModel.BlueforsHeater;
            }

            set
            {
                this.loggingModel.BlueforsHeater = value;
                this.RaisePropertyChanged("BlueforsHeater");
            }
        }

        /// <summary>
        /// Gets or sets the bluefors50 k shield pressure.
        /// </summary>
        /// <value>
        /// The bluefors50 k shield pressure.
        /// </value>
        public bool Bluefors50KShieldPressure
        {
            get
            {
                return this.loggingModel.Bluefors50KShieldPressure;
            }

            set
            {
                this.loggingModel.Bluefors50KShieldPressure = value;
                this.RaisePropertyChanged("Bluefors50KShieldPressure");
            }
        }

        /// <summary>
        /// Gets or sets the bluefors3 k shield pressure.
        /// </summary>
        /// <value>
        /// The bluefors3 k shield pressure.
        /// </value>
        public bool Bluefors3KShieldPressure
        {
            get
            {
                return this.loggingModel.Bluefors3KShieldPressure;
            }

            set
            {
                this.loggingModel.Bluefors3KShieldPressure = value;
                this.RaisePropertyChanged("Bluefors3KShieldPressure");
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
        /// Converts the int to preset.
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
    }
}
