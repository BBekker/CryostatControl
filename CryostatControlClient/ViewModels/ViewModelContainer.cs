// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelContainer.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The abstract view model.
// </summary>

namespace CryostatControlClient.ViewModels
{
    using System;
    using CryostatControlClient.ViewModels;
    using LiveCharts;

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
            this.ZoomingViewModel = new ZoomingViewModel();

            this.InitSeriesCollection();
            this.InitSeriesCollection2();
        }

        #region Properties

        /// <summary>
        /// Gets or sets the series collection.
        /// </summary>
        /// <value>
        /// The series collection.
        /// </value>
        public SeriesCollection SeriesCollection { get; set; }

        /// <summary>
        /// Gets or sets the series collection.
        /// </summary>
        /// <value>
        /// The series collection.
        /// </value>
        public SeriesCollection SeriesCollection2 { get; set; }

        /// <summary>
        /// Gets or sets the x formatter.
        /// </summary>
        /// <value>
        /// The x formatter.
        /// </value>
        public Func<double, string> XFormatter { get; set; }
        
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
        /// Gets or sets the message box view model.
        /// </summary>
        public MessageBoxViewModel MessageBoxViewModel { get; set; }
        
        /// <summary>
        /// Gets the settings view model.
        /// </summary>
        public SettingsViewModel SettingsViewModel { get; private set; }

        /// <summary>
        /// Gets the zooming view model.
        /// </summary>
        /// <value>
        /// The zooming view model.
        /// </value>
        public ZoomingViewModel ZoomingViewModel { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initializes the series collection.
        /// </summary>
        private void InitSeriesCollection()
        {
            this.SeriesCollection = new SeriesCollection
                                    {
                                            this.BlueforsViewModel.ColdPlate3KLineSeries,
                                            this.BlueforsViewModel.ColdPlate50KLineSeries,
                                            this.He7ViewModel.FourKPlateLineSeries,
                                            this.He7ViewModel.TwoKPlatLineSeries,
                                            this.He7ViewModel.He3HeadLineSeries,
                                            this.He7ViewModel.He3PumpLineSeries,
                                            this.He7ViewModel.He3SwitchLineSeries,
                                            this.He7ViewModel.He4HeadLineSeries,
                                            this.He7ViewModel.He4PumpLineSeries,
                                            this.He7ViewModel.He4SwitchLineSeries,
                                     };

            this.XFormatter = val => this.GetDateTime(val);
        }

        /// <summary>
        /// Initializes the series collection.
        /// </summary>
        private void InitSeriesCollection2()
        {
            this.SeriesCollection2 = new SeriesCollection
                                         {
                                             this.BlueforsViewModel.ColdPlate3KLineSeriesBottom,
                                             this.BlueforsViewModel.ColdPlate50KLineSeriesBottom,
                                             this.He7ViewModel.He3HeadLineSeriesBottom,
                                             this.He7ViewModel.He4HeadLineSeriesBottom,
                                         };
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>Time in hours and minutes.</returns>
        private string GetDateTime(double val)
        {
            try
            {
                return new DateTime((long)val).ToString("HH:mm");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
                return string.Empty;
            }
        }

        #endregion Methods
    }
}
