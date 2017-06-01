// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelContainer.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The abstract view model.
// </summary>

namespace CryostatControlClient.ViewModels
{
    /// <summary>
    /// The data context.
    /// </summary>
    public class ViewModelContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelContainer" /> class.
        /// </summary>
        public ViewModelContainer()
        {
            this.BlueforsViewModel = new BlueforsViewModel();
            this.CompressorViewModel = new CompressorViewModel();
            this.He7ViewModel = new He7ViewModel();
            this.LoggingViewModel = new LoggingViewModel();
            this.ModusViewModel = new ModusViewModel();
            this.SettingsViewModel = new SettingsViewModel();
        }

        /// <summary>
        /// Gets the BlueforsViewModel.
        /// </summary>
        /// <value>
        /// The BlueforsViewModel.
        /// </value>
        public BlueforsViewModel BlueforsViewModel { get; }

        /// <summary>
        /// Gets the CompressorViewModel.
        /// </summary>
        /// <value>
        /// The CompressorViewModel.
        /// </value>
        public CompressorViewModel CompressorViewModel { get; }

        /// <summary>
        /// Gets the He7ViewModel.
        /// </summary>
        /// <value>
        /// The He7ViewModel.
        /// </value>
        public He7ViewModel He7ViewModel { get; }

        /// <summary>
        /// Gets the logging view model.
        /// </summary>
        /// <value>
        /// The logging view model.
        /// </value>
        public LoggingViewModel LoggingViewModel { get; }

        /// <summary>
        /// Gets the modus view model.
        /// </summary>
        /// <value>
        /// The modus view model.
        /// </value>
        public ModusViewModel ModusViewModel { get; }

        /// <summary>
        /// Gets the settings view model.
        /// </summary>
        public SettingsViewModel SettingsViewModel { get; private set; }
    }
}