// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogCompressorPreset.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the LogCompressorPreset type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels.LoggingPresets
{
    /// <summary>
    /// The log compressor preset.
    /// </summary>
    public class LogCompressorPreset : ILoggingPreset
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LogCompressorPreset"/> class.
        /// </summary>
        /// <param name="loggingViewModel">The logging view model.</param>
        public LogCompressorPreset(LoggingViewModel loggingViewModel)
        {
            this.SetLoggingValues(loggingViewModel);
        }

        #region Implementation of ILoggingPreset


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
            loggingViewModel.Bluefors3KShieldTemp = false;
            loggingViewModel.Bluefors50KShieldTemp = false;
            loggingViewModel.CompressorHeliumTemp = true;
            loggingViewModel.CompressorOilTemp = true;
            loggingViewModel.CompressorWaterInTemp = true;
            loggingViewModel.CompressorWaterOutTemp = true;
            loggingViewModel.He3HeadTemp = false;
            loggingViewModel.He4SwitchTemp = false;
            loggingViewModel.He4HeadTemp = false;
            loggingViewModel.He3SwitchTemp = false;
            loggingViewModel.He3PumpTemp = false;
            loggingViewModel.He4PumpTemp = false;

            loggingViewModel.CompressorDeltaAveragePressure = true;
            loggingViewModel.CompressorDeltaAveragePressure = true;
            loggingViewModel.CompressorHighPressure = true;
            loggingViewModel.CompressorHighAveragePressure = true;
            loggingViewModel.CompressorLowPressure = true;
            loggingViewModel.CompressorLowAveragePressure = true;

            loggingViewModel.BlueforsHeater = false;
        }

        #endregion
    }
}
