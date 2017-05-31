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

    using LiveCharts;

    /// <summary>
    /// The data context.
    /// </summary>
    public class ViewModelContainer 
    {
        #region Fields

        /// <summary>
        /// The bluefors view model
        /// </summary>
        private BlueforsViewModel blueforsViewModel;

        /// <summary>
        /// The compressor view model
        /// </summary>
        private CompressorViewModel compressorViewModel;

        /// <summary>
        /// The he7 view model
        /// </summary>
        private He7ViewModel he7ViewModel;

        /// <summary>
        /// The logging view model
        /// </summary>
        private LoggingViewModel loggingViewModel;

        /// <summary>
        /// The modus view model
        /// </summary>
        private ModusViewModel modusViewModel;

        /// <summary>
        /// The zooming view model
        /// </summary>
        private ZoomingViewModel zoomingViewModel;

        /// <summary>
        /// The series collection1
        /// </summary>
        private SeriesCollection seriesCollection;

        /// <summary>
        /// The series collection1
        /// </summary>
        private SeriesCollection seriesCollection2;

        /// <summary>
        /// The x formatter
        /// </summary>
        private Func<double, string> xFormatter;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelContainer" /> class.
        /// </summary>
        public ViewModelContainer()
        {
            this.blueforsViewModel = new BlueforsViewModel();
            this.compressorViewModel = new CompressorViewModel();
            this.he7ViewModel = new He7ViewModel();
            this.loggingViewModel = new LoggingViewModel();
            this.modusViewModel = new ModusViewModel();
            this.zoomingViewModel = new ZoomingViewModel();

            this.InitSeriesCollection();
            this.InitSeriesCollection2();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the series collection.
        /// </summary>
        /// <value>
        /// The series collection.
        /// </value>
        public SeriesCollection SeriesCollection
        {
            get
            {
                return this.seriesCollection;
            }
        }

        /// <summary>
        /// Gets the series collection.
        /// </summary>
        /// <value>
        /// The series collection.
        /// </value>
        public SeriesCollection SeriesCollection2
        {
            get
            {
                return this.seriesCollection2;
            }
        }

        /// <summary>
        /// Gets or sets the x formatter.
        /// </summary>
        /// <value>
        /// The x formatter.
        /// </value>
        public Func<double, string> XFormatter
        {
            get
            {
                return this.xFormatter;
            }

            set
            {
                this.xFormatter = value;
            }
        }

        /// <summary>
        /// Gets the BlueforsViewModel.
        /// </summary>
        /// <value>
        /// The BlueforsViewModel.
        /// </value>
        public BlueforsViewModel BlueforsViewModel
        {
            get
            {
                return this.blueforsViewModel;
            }
        }

        /// <summary>
        /// Gets the CompressorViewModel.
        /// </summary>
        /// <value>
        /// The CompressorViewModel.
        /// </value>
        public CompressorViewModel CompressorViewModel
        {
            get
            {
                return this.compressorViewModel;
            }
        }

        /// <summary>
        /// Gets the He7ViewModel.
        /// </summary>
        /// <value>
        /// The He7ViewModel.
        /// </value>
        public He7ViewModel He7ViewModel
        {
            get
            {
                return this.he7ViewModel;
            }
        }

        /// <summary>
        /// Gets the logging view model.
        /// </summary>
        /// <value>
        /// The logging view model.
        /// </value>
        public LoggingViewModel LoggingViewModel
        {
            get
            {
                return this.loggingViewModel;
            }
        }

        /// <summary>
        /// Gets the modus view model.
        /// </summary>
        /// <value>
        /// The modus view model.
        /// </value>
        public ModusViewModel ModusViewModel
        {
            get
            {
                return this.modusViewModel;
            }
        }

        /// <summary>
        /// Gets the zooming view model.
        /// </summary>
        /// <value>
        /// The zooming view model.
        /// </value>
        public ZoomingViewModel ZoomingViewModel
        {
            get
            {
                return this.zoomingViewModel;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initializes the series collection.
        /// </summary>
        private void InitSeriesCollection()
        {
            this.seriesCollection = new SeriesCollection
                                    {
                                            this.blueforsViewModel.ColdPlate3KLineSeries,
                                            this.blueforsViewModel.ColdPlate50KLineSeries,
                                            this.he7ViewModel.FourKPlateLineSeries,
                                            this.he7ViewModel.TwoKPlatLineSeries,
                                            this.he7ViewModel.He3HeadLineSeries,
                                            this.he7ViewModel.He3PumpLineSeries,
                                            this.he7ViewModel.He3SwitchLineSeries,
                                            this.he7ViewModel.He4HeadLineSeries,
                                            this.he7ViewModel.He4PumpLineSeries,
                                            this.he7ViewModel.He4SwitchLineSeries,
                                     };

            this.xFormatter = val => new DateTime((long)val).ToString("HH:mm");
        }

        /// <summary>
        /// Initializes the series collection.
        /// </summary>
        private void InitSeriesCollection2()
        {
            this.seriesCollection2 = new SeriesCollection
                                         {
                                             this.blueforsViewModel.ColdPlate3KLineSeriesBottom,
                                             this.blueforsViewModel.ColdPlate50KLineSeriesBottom,
                                             this.he7ViewModel.He3HeadLineSeriesBottom,
                                             this.he7ViewModel.He4HeadLineSeriesBottom,
                                         };

            this.xFormatter = val => new DateTime((long)val).ToString("HH:mm");
        }

        #endregion Methods
    }
}
