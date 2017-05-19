// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogHe7Preset.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The log He7 preset.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels.LoggingPresets
{
    /// <summary>
    /// The log he 7 preset.
    /// </summary>
    public class LogHe7Preset : ILoggingPreset
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogHe7Preset"/> class.
        /// </summary>
        /// <param name="loggingViewModel">
        /// The logging view model.
        /// </param>
        public LogHe7Preset(LoggingViewModel loggingViewModel)
        {
            this.SetLoggingValues(loggingViewModel);
        }

        /// <summary>
        /// Sets the logging values.
        /// </summary>
        /// <param name="loggingViewModel">The logging view model.</param>
        public void SetLoggingValues(LoggingViewModel loggingViewModel)
        {
            loggingViewModel.LoggingInterval = 10.0;

            loggingViewModel.He3PumpVolt = true;
            loggingViewModel.He3SwitchVolt = true;
            loggingViewModel.He4PumpVolt = true;
            loggingViewModel.He4SwitchVolt = true;

            loggingViewModel.FourKPlateTemp = true;
            loggingViewModel.TwoKPlateTemp = true;
            loggingViewModel.Bluefors3KShieldTemp = false;
            loggingViewModel.Bluefors50KShieldTemp = false;
            loggingViewModel.CompressorHeliumTemp = false;
            loggingViewModel.CompressorOilTemp = false;
            loggingViewModel.CompressorWaterInTemp = false;
            loggingViewModel.CompressorWaterOutTemp = false;
            loggingViewModel.He3HeadTemp = true;
            loggingViewModel.He4SwitchTemp = true;
            loggingViewModel.He4HeadTemp = true;
            loggingViewModel.He3SwitchTemp = true;
            loggingViewModel.He3PumpTemp = true;
            loggingViewModel.He4PumpTemp = true;

            loggingViewModel.CompressorDeltaAveragePressure = false;
            loggingViewModel.CompressorDeltaAveragePressure = false;
            loggingViewModel.CompressorHighPressure = false;
            loggingViewModel.CompressorHighAveragePressure = false;
            loggingViewModel.CompressorLowPressure = false;
            loggingViewModel.CompressorLowAveragePressure = false;

            loggingViewModel.BlueforsHeater = false;
        }
    }
}
