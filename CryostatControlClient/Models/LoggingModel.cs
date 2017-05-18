// --------------------------------------------------------------------------------------------------------------------
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
        private int he3ColdHeadTemp;

        /// <summary>
        /// The he3 warm head temperature
        /// </summary>
        private int he3WarmHeadTemp;

        /// <summary>
        /// The he3 switch temperature
        /// </summary>
        private int he3SwitchTemp;

        /// <summary>
        /// The he4 cold head temperature
        /// </summary>
        private int he4ColdHeadTemp;

        /// <summary>
        /// The he4 warm head temperature
        /// </summary>
        private int he4WarmHeadTemp;

        /// <summary>
        /// The he4 switch temperature
        /// </summary>
        private int he4SwitchTemp;

        /// <summary>
        /// The two k plate temperature
        /// </summary>
        private int twoKPlateTemp;

        /// <summary>
        /// The four k plate temperature
        /// </summary>
        private int fourKPlateTemp;

        /// <summary>
        /// The he3 pump volt
        /// </summary>
        private int he3PumpVolt;

        /// <summary>
        /// The he3 switch volt
        /// </summary>
        private int he3SwitchVolt;

        /// <summary>
        /// The he4 pump volt
        /// </summary>
        private int he4PumpVolt;

        /// <summary>
        /// The he4 switch volt
        /// </summary>
        private int he4SwitchVolt;

        /// <summary>
        /// The bluefors50 k shield temperature
        /// </summary>
        private int bluefors50KShieldTemp;

        /// <summary>
        /// The bluefors3 k shield temperature
        /// </summary>
        private int bluefors3KShieldTemp;

        /// <summary>
        /// The bluefors heater
        /// </summary>
        private int blueforsHeater;

        /// <summary>
        /// The bluefors50 k shield pressure
        /// </summary>
        private int bluefors50KShieldPressure;

        /// <summary>
        /// The bluefors3 k shield pressure
        /// </summary>
        private int bluefors3KShieldPressure;

        /// <summary>
        /// The compressor water in temperature
        /// </summary>
        private int compressorWaterInTemp;

        /// <summary>
        /// The compressor water out temperature
        /// </summary>
        private int compressorWaterOutTemp;

        /// <summary>
        /// The compressor helium temperature
        /// </summary>
        private int compressorHeliumTemp;

        /// <summary>
        /// The compressor oil temperature
        /// </summary>
        private int compressorOilTemp;

        /// <summary>
        /// The compressor low pressure
        /// </summary>
        private int compressorLowPressure;

        /// <summary>
        /// The compressor low average pressure
        /// </summary>
        private int compressorLowAveragePressure;

        /// <summary>
        /// The compressor high pressure
        /// </summary>
        private int compressorHighPressure;

        /// <summary>
        /// The compressor high average pressure
        /// </summary>
        private int compressorHighAveragePressure;

        /// <summary>
        /// The compressor delta average pressure
        /// </summary>
        private int compressorDeltaAveragePressure;

        /// <summary>
        /// The logging interval
        /// </summary>
        private int loggingInterval;

        /// <summary>
        /// Gets or sets the he3 cold head temperature.
        /// </summary>
        /// <value>
        /// The he3 cold head temperature.
        /// </value>
        public int He3ColdHeadTemp
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
        public int He3WarmHeadTemp
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
        public int He3SwitchTemp
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
        public int He4ColdHeadTemp
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
        public int He4WarmHeadTemp
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
        public int He4SwitchTemp
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
        public int TwoKPlateTemp
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
        public int FourKPlateTemp
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
        /// Gets or sets the he3 pump volt1.
        /// </summary>
        /// <value>
        /// The he3 pump volt1.
        /// </value>
        public int He3PumpVolt1
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
        /// Gets or sets the he3 switch volt1.
        /// </summary>
        /// <value>
        /// The he3 switch volt1.
        /// </value>
        public int He3SwitchVolt1
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
        /// Gets or sets the he4 pump volt1.
        /// </summary>
        /// <value>
        /// The he4 pump volt1.
        /// </value>
        public int He4PumpVolt1
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
        /// Gets or sets the he4 switch volt1.
        /// </summary>
        /// <value>
        /// The he4 switch volt1.
        /// </value>
        public int He4SwitchVolt1
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
        public int Bluefors50KShieldTemp
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
        public int Bluefors3KShieldTemp
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
        public int BlueforsHeater
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
        public int Bluefors50KShieldPressure
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
        public int Bluefors3KShieldPressure
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
        public int CompressorWaterInTemp
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
        public int CompressorWaterOutTemp
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
        public int CompressorHeliumTemp
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
        public int CompressorOilTemp
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
        public int CompressorLowPressure
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
        public int CompressorLowAveragePressure
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
        public int CompressorHighPressure
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
        public int CompressorHighAveragePressure
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
        public int CompressorDeltaAveragePressure
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
        public int LoggingInterval
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
    }
}
