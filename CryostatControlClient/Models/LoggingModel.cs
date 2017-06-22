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
        /// Gets or sets a value indicating whether [he3 pump temperature] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 pump temperature] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He3PumpTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [he3 head temperature] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 head temperature] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He3HeadTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [he3 switch temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 switch temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He3SwitchTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [he4 pump temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 pump temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He4PumpTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [he4 head temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 head temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He4HeadTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [he4 switch temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 switch temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He4SwitchTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [two k plate temperature] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [two k plate temperature] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool TwoKPlateTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [four k plate temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [four k plate temperature] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool FourKPlateTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [he3 pump volt]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 pump volt]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He3PumpVolt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [he3 switch volt]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he3 switch volt]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He3SwitchVolt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [he4 pump volt]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 pump volt] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He4PumpVolt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [he4 switch volt]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [he4 switch volt]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool He4SwitchVolt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [bluefors50 k shield temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [bluefors50 k shield temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool Bluefors50KShieldTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [bluefors3 k shield temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [bluefors3 k shield temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool Bluefors3KShieldTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [compressor water in temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor water in temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool CompressorWaterInTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [compressor water out temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor water out temperature] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool CompressorWaterOutTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [compressor helium temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor helium temperature] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool CompressorHeliumTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [compressor oil temperature]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor oil temperature]  will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool CompressorOilTemp { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [compressor low pressure]  will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor low pressure] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool CompressorLowPressure { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [compressor low average pressure] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor low average pressure] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool CompressorLowAveragePressure { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [compressor high pressure] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor high pressure] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool CompressorHighPressure { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [compressor high average pressure] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor high average pressure] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool CompressorHighAveragePressure { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [compressor delta average pressure] will be logged.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [compressor delta average pressure] will be logged; otherwise, <c>false</c>.
        /// </value>
        public bool CompressorDeltaAveragePressure { get; set; }

        /// <summary>
        /// Gets or sets the logging interval.
        /// </summary>
        /// <value>
        /// The logging interval.
        /// </value>
        public double LoggingInterval { get; set; }

        /// <summary>
        /// Gets or sets the preset ComboBox.
        /// </summary>
        /// <value>
        /// The preset ComboBox.
        /// </value>
        public int PresetComboBox { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [logging in progress].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [logging in progress]; otherwise, <c>false</c>.
        /// </value>
        public bool LoggingInProgress { get; set; }
    }
}
