// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneralLoggingPreset.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the GeneralLoggingPreset type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels.LoggingPresets
{
    /// <summary>
    /// The general logging preset.
    /// </summary>
    public interface ILoggingPreset
    {

        /// <summary>
        /// Sets the logging values.
        /// </summary>
        /// <param name="loggingViewModel">The logging view model.</param>
        new void SetLoggingValues(LoggingViewModel loggingViewModel);
    }
}
