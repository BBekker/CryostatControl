// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILoggingPreset.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
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
        void SetLoggingValues(LoggingViewModel loggingViewModel);
    }
}
