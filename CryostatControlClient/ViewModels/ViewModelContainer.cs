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
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Wpf;

    /// <summary>
    /// The data context.
    /// </summary>
    public class ViewModelContainer 
    {
        #region Fields

        /// <summary>
        /// The BVM
        /// </summary>
        private BlueforsViewModel blueforsViewModel;

        /// <summary>
        /// The CVM
        /// </summary>
        private CompressorViewModel compressorViewModel;

        /// <summary>
        /// The HVM
        /// </summary>
        private He7ViewModel he7ViewModel;

        /// <summary>
        /// The test view model
        /// </summary>
        private ModusViewModel modusViewModel;

        /// <summary>
        /// The series collection1
        /// </summary>
        private SeriesCollection seriesCollection;

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
            this.modusViewModel = new ModusViewModel();

            this.InitSeriesCollection();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the series collection.
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
        /// Gets the TestViewModel.
        /// </summary>
        /// <value>
        /// The TestViewModel.
        /// </value>
        public ModusViewModel ModusViewModel
        {
            get
            {
                return this.modusViewModel;
            }
        }

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

            this.xFormatter = val => new DateTime((long)val).ToString("HH:mm:ss");
        }

        #endregion Properties
    }
}
