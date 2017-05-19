// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogAllPreset.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the LogAllPreset type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels.LoggingPresets
{
    /// <summary>
    /// The log all preset.
    /// </summary>
    public class LogAllPreset : ILoggingPreset
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogAllPreset"/> class.
        /// </summary>
        /// <param name="loggingViewModel">
        /// The logging view model.
        /// </param>
        public LogAllPreset(LoggingViewModel loggingViewModel)
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
            loggingViewModel.Bluefors3KShieldTemp = true;
            loggingViewModel.Bluefors50KShieldTemp = true;
            loggingViewModel.CompressorHeliumTemp = true;
            loggingViewModel.CompressorOilTemp = true;
            loggingViewModel.CompressorWaterInTemp = true;
            loggingViewModel.CompressorWaterOutTemp = true;
            loggingViewModel.He3HeadTemp = true;
            loggingViewModel.He4SwitchTemp = true;
            loggingViewModel.He4HeadTemp = true;
            loggingViewModel.He3SwitchTemp = true;
            loggingViewModel.He3PumpTemp = true;
            loggingViewModel.He4PumpTemp = true;

            loggingViewModel.CompressorDeltaAveragePressure = true;
            loggingViewModel.CompressorDeltaAveragePressure = true;
            loggingViewModel.CompressorHighPressure = true;
            loggingViewModel.CompressorHighAveragePressure = true;
            loggingViewModel.CompressorLowPressure = true;
            loggingViewModel.CompressorLowAveragePressure = true;

            loggingViewModel.BlueforsHeater = true;
        }
    }
}
