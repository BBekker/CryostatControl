// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogBlueforsPreset.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The log Bluefors preset.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels.LoggingPresets
{
    /// <summary>
    /// The log nothing preset.
    /// </summary>
    public class LogBlueforsPreset : ILoggingPreset
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogBlueforsPreset"/> class.
        /// </summary>
        /// <param name="loggingViewModel">
        /// The logging view model.
        /// </param>
        public LogBlueforsPreset(LoggingViewModel loggingViewModel)
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

            loggingViewModel.He3PumpVolt = false;
            loggingViewModel.He3SwitchVolt = false;
            loggingViewModel.He4PumpVolt = false;
            loggingViewModel.He4SwitchVolt = false;

            loggingViewModel.FourKPlateTemp = false;
            loggingViewModel.TwoKPlateTemp = false;
            loggingViewModel.Bluefors3KShieldTemp = true;
            loggingViewModel.Bluefors50KShieldTemp = true;
            loggingViewModel.CompressorHeliumTemp = false;
            loggingViewModel.CompressorOilTemp = false;
            loggingViewModel.CompressorWaterInTemp = false;
            loggingViewModel.CompressorWaterOutTemp = false;
            loggingViewModel.He3HeadTemp = false;
            loggingViewModel.He4SwitchTemp = false;
            loggingViewModel.He4HeadTemp = false;
            loggingViewModel.He3SwitchTemp = false;
            loggingViewModel.He3PumpTemp = false;
            loggingViewModel.He4PumpTemp = false;

            loggingViewModel.CompressorDeltaAveragePressure = false;
            loggingViewModel.CompressorDeltaAveragePressure = false;
            loggingViewModel.CompressorHighPressure = false;
            loggingViewModel.CompressorHighAveragePressure = false;
            loggingViewModel.CompressorLowPressure = false;
            loggingViewModel.CompressorLowAveragePressure = false;

            loggingViewModel.BlueforsHeater = true;
        }
    }
}
