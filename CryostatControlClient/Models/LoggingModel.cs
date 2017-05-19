﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the LoggingModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Models
{
    /// <summary>
    /// The logging model.
    /// </summary>
    public class LoggingModel
    {

        /// <summary>
        /// The he3 cold head temperature
        /// </summary>
        private bool he3ColdHeadTemp;

        /// <summary>
        /// The he3 warm head temperature
        /// </summary>
        private bool he3WarmHeadTemp;

        /// <summary>
        /// The he3 switch temperature
        /// </summary>
        private bool he3SwitchTemp;

        /// <summary>
        /// The he4 cold head temperature
        /// </summary>
        private bool he4ColdHeadTemp;

        /// <summary>
        /// The he4 warm head temperature
        /// </summary>
        private bool he4WarmHeadTemp;

        /// <summary>
        /// The he4 switch temperature
        /// </summary>
        private bool he4SwitchTemp;

        /// <summary>
        /// The two k plate temperature
        /// </summary>
        private bool twoKPlateTemp;

        /// <summary>
        /// The four k plate temperature
        /// </summary>
        private bool fourKPlateTemp;

        /// <summary>
        /// The he3 pump volt
        /// </summary>
        private bool he3PumpVolt;

        /// <summary>
        /// The he3 switch volt
        /// </summary>
        private bool he3SwitchVolt;

        /// <summary>
        /// The he4 pump volt
        /// </summary>
        private bool he4PumpVolt;

        /// <summary>
        /// The he4 switch volt
        /// </summary>
        private bool he4SwitchVolt;

        /// <summary>
        /// The bluefors50 k shield temperature
        /// </summary>
        private bool bluefors50KShieldTemp;

        /// <summary>
        /// The bluefors3 k shield temperature
        /// </summary>
        private bool bluefors3KShieldTemp;

        /// <summary>
        /// The bluefors heater
        /// </summary>
        private bool blueforsHeater;

        /// <summary>
        /// The bluefors50 k shield pressure
        /// </summary>
        private bool bluefors50KShieldPressure;

        /// <summary>
        /// The bluefors3 k shield pressure
        /// </summary>
        private bool bluefors3KShieldPressure;

        /// <summary>
        /// The compressor water in temperature
        /// </summary>
        private bool compressorWaterInTemp;

        /// <summary>
        /// The compressor water out temperature
        /// </summary>
        private bool compressorWaterOutTemp;

        /// <summary>
        /// The compressor helium temperature
        /// </summary>
        private bool compressorHeliumTemp;

        /// <summary>
        /// The compressor oil temperature
        /// </summary>
        private bool compressorOilTemp;

        /// <summary>
        /// The compressor low pressure
        /// </summary>
        private bool compressorLowPressure;

        /// <summary>
        /// The compressor low average pressure
        /// </summary>
        private bool compressorLowAveragePressure;

        /// <summary>
        /// The compressor high pressure
        /// </summary>
        private bool compressorHighPressure;

        /// <summary>
        /// The compressor high average pressure
        /// </summary>
        private bool compressorHighAveragePressure;

        /// <summary>
        /// The compressor delta average pressure
        /// </summary>
        private bool compressorDeltaAveragePressure;

        /// <summary>
        /// The logging interval
        /// </summary>
        private double loggingInterval;

        /// <summary>
        /// The preset ComboBox
        /// </summary>
        private int presetComboBox;

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
                return this.he3ColdHeadTemp;
            }

            set
            {
                this.he3ColdHeadTemp = value;
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
                return this. he3WarmHeadTemp;
            }

            set
            {
                this.he3WarmHeadTemp = value;
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
                return this.he3SwitchTemp;
            }

            set
            {
                this.he3SwitchTemp = value;
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
                return this.he4ColdHeadTemp;
            }

            set
            {
                this.he4ColdHeadTemp = value;
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
                return this.he4WarmHeadTemp;
            }

            set
            {
                this.he4WarmHeadTemp = value;
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
                return this.he4SwitchTemp;
            }

            set
            {
                this.he4SwitchTemp = value;
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
                return this.twoKPlateTemp;
            }

            set
            {
                this.twoKPlateTemp = value;
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
                return this.fourKPlateTemp;
            }

            set
            {
                this.fourKPlateTemp = value;
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
                return this.he3PumpVolt;
            }

            set
            {
                this.he3PumpVolt = value;
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
                return this.he3SwitchVolt;
            }

            set
            {
                this.he3SwitchVolt = value;
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
                return this.he4PumpVolt;
            }

            set
            {
                this.he4PumpVolt = value;
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
                return this.he4SwitchVolt;
            }

            set
            {
                this.he4SwitchVolt = value;
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
                return this.bluefors50KShieldTemp;
            }

            set
            {
                this.bluefors50KShieldTemp = value;
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
                return this.bluefors3KShieldTemp;
            }

            set
            {
                this.bluefors3KShieldTemp = value;
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
                return this.blueforsHeater;
            }

            set
            {
                this.blueforsHeater = value;
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
                return this.bluefors50KShieldPressure;
            }

            set
            {
                this.bluefors50KShieldPressure = value;
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
                return this.bluefors3KShieldPressure;
            }

            set
            {
                this.bluefors3KShieldPressure = value;
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
                return this.compressorWaterInTemp;
            }

            set
            {
                this.compressorWaterInTemp = value;
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
                return this.compressorWaterOutTemp;
            }

            set
            {
                this.compressorWaterOutTemp = value;
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
                return this.compressorHeliumTemp;
            }

            set
            {
                this.compressorHeliumTemp = value;
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
                return this.compressorOilTemp;
            }

            set
            {
                this.compressorOilTemp = value;
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
                return this.compressorLowPressure;
            }

            set
            {
                this.compressorLowPressure = value;
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
                return this.compressorLowAveragePressure;
            }

            set
            {
                this.compressorLowAveragePressure = value;
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
                return this.compressorHighPressure;
            }

            set
            {
                this.compressorHighPressure = value;
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
                return this.compressorHighAveragePressure;
            }

            set
            {
                this.compressorHighAveragePressure = value;
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
                return this.compressorDeltaAveragePressure;
            }

            set
            {
                this.compressorDeltaAveragePressure = value;
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
                return this.loggingInterval;
            }

            set
            {
                this.loggingInterval = value;
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
                return this.presetComboBox;
            }

            set
            {
                this.presetComboBox = value;
            }
        }
    }
}
