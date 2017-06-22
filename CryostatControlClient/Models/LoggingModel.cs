// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggingModel.cs" company="SRON">
//  Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Models
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The logging model.
    /// </summary>
    public class LoggingModel
    {
        /// <summary>
        /// The he3 pump temperature
        /// </summary>
        private bool he3PumpTemp;

        /// <summary>
        /// The he3 head temperature
        /// </summary>
        private bool he3HeadTemp;

        /// <summary>
        /// The he3 switch temperature
        /// </summary>
        private bool he3SwitchTemp;

        /// <summary>
        /// The he4 pump temperature
        /// </summary>
        private bool he4PumpTemp;

        /// <summary>
        /// The he4 head temperature
        /// </summary>
        private bool he4HeadTemp;

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
        /// The bluefors 50 k shield temperature
        /// </summary>
        private bool bluefors50KShieldTemp;

        /// <summary>
        /// The bluefors 3 k shield temperature
        /// </summary>
        private bool bluefors3KShieldTemp;

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
        /// The logging in progress
        /// </summary>
        private bool loggingInProgress;


        /// <summary>
        /// Gets or sets a value indicating whether [he3 pump temperature] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 pump temperature] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He3PumpTemp
        {
            get
            {
                return this.he3PumpTemp;
            }

            set
            {
                this.he3PumpTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [he3 head temperature] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 head temperature] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He3HeadTemp
        {
            get
            {
                return this.he3HeadTemp;
            }

            set
            {
                this.he3HeadTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [he3 switch temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 switch temperature]  will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [he4 pump temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 pump temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He4PumpTemp
        {
            get
            {
                return this.he4PumpTemp;
            }

            set
            {
                this.he4PumpTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [he4 head temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 head temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He4HeadTemp
        {
            get
            {
                return this.he4HeadTemp;
            }

            set
            {
                this.he4HeadTemp = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [he4 switch temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 switch temperature]  will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [two k plate temperature] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [two k plate temperature] will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [four k plate temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [four k plate temperature] will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [he3 pump volt]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 pump volt]  will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [he3 switch volt]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 switch volt]  will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [he4 pump volt]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 pump volt] will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [he4 switch volt]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 switch volt]  will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [bluefors50 k shield temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [bluefors50 k shield temperature]  will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [bluefors3 k shield temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [bluefors3 k shield temperature]  will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [compressor water in temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor water in temperature]  will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [compressor water out temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor water out temperature] will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [compressor helium temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor helium temperature] will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [compressor oil temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor oil temperature]  will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [compressor low pressure]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor low pressure] will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [compressor low average pressure] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor low average pressure] will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [compressor high pressure] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor high pressure] will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [compressor high average pressure] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor high average pressure] will be logged; otherwise, <c>false</c>.
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
        /// Gets or sets a value indicating whether [compressor delta average pressure] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor delta average pressure] will be logged; otherwise, <c>false</c>.
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
                return this.loggingInProgress;
            }

            set
            {
                this.loggingInProgress = value;
            }
        }
    }
}
