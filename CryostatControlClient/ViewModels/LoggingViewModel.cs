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
        /// Gets or sets a value indicating whether he 3 pump temp.
        /// </summary>
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
        /// Gets or sets a value indicating whether he 3 head temp.
        /// </summary>
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
        /// Gets or sets a value indicating whether he 4 pump temp.
        /// </summary>
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
        /// Gets or sets a value indicating whether he 4 head temp.
        /// </summary>
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

        /// <summary>
        /// Get the logging array.
        /// </summary>
        /// <returns>
        /// The <see cref="double[]"/>.
        /// </returns>
        public double[] GetLoggingArray()
        {
            double[] loggingArray = new double[42];
            loggingArray[0] = this.ConvertBoolToDouble(this.Bluefors50KShieldTemp);
            loggingArray[1] = this.ConvertBoolToDouble(this.Bluefors3KShieldTemp);
            loggingArray[2] = this.ConvertBoolToDouble(this.CompressorWaterInTemp);
            loggingArray[3] = this.ConvertBoolToDouble(this.CompressorWaterOutTemp);
            loggingArray[4] = this.ConvertBoolToDouble(this.CompressorHeliumTemp);
            loggingArray[5] = this.ConvertBoolToDouble(this.CompressorOilTemp);
            loggingArray[6] = this.ConvertBoolToDouble(this.CompressorLowPressure);
            loggingArray[7] = this.ConvertBoolToDouble(this.CompressorLowAveragePressure);
            loggingArray[8] = this.ConvertBoolToDouble(this.CompressorHighPressure);
            loggingArray[9] = this.ConvertBoolToDouble(this.CompressorHighAveragePressure);
            loggingArray[10] = this.ConvertBoolToDouble(this.CompressorDeltaAveragePressure);
            loggingArray[11] = this.ConvertBoolToDouble(this.He3PumpTemp);
            loggingArray[12] = this.ConvertBoolToDouble(this.TwoKPlateTemp);
            loggingArray[13] = this.ConvertBoolToDouble(this.FourKPlateTemp);
            loggingArray[14] = this.ConvertBoolToDouble(this.He3HeadTemp);
            loggingArray[15] = this.ConvertBoolToDouble(this.He4PumpTemp);
            loggingArray[16] = this.ConvertBoolToDouble(this.He4SwitchTemp);
            loggingArray[17] = this.ConvertBoolToDouble(this.He3SwitchTemp);
            loggingArray[18] = this.ConvertBoolToDouble(this.He4HeadTemp);
            loggingArray[19] = this.ConvertBoolToDouble(this.He3PumpVolt);
            loggingArray[20] = this.ConvertBoolToDouble(this.He4SwitchVolt);
            loggingArray[21] = this.ConvertBoolToDouble(this.He3SwitchVolt);
            loggingArray[22] = this.ConvertBoolToDouble(this.He4PumpVolt);

            loggingArray[39] = this.ConvertBoolToDouble(this.BlueforsHeater);

            loggingArray[41] = this.LoggingInterval;
            return loggingArray;
        }

        /// <summary>
        /// Converts the bool to double.
        /// </summary>
        /// <param name="boolVal">if set to <c>true</c> [bool value].</param>
        /// <returns>Converted bool to int</returns>
        public double ConvertBoolToDouble(bool boolVal)
        {
            if (boolVal == true)
            {
                return 1;
            }
            return 0;
        }
    }
}
