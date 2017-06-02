// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZoomingViewModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The abstract view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System;
    using System.Windows.Input;

    using CryostatControlClient.Views.Tabs;

    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Wpf;

    /// <summary>
    /// The zooming view model.
    /// </summary>
    /// <seealso cref="CryostatControlClient.ViewModels.AbstractViewModel" />
    public class ZoomingViewModel : AbstractViewModel
    {
        #region Fields

        /// <summary>
        /// The zooming mode
        /// </summary>
        private ZoomingOptions zoomingMode;

        /// <summary>
        /// The switch command
        /// </summary>
        private ICommand zoomCommand;

        /// <summary>
        /// The reset command
        /// </summary>
        private ICommand resetCommand;

        /// <summary>
        /// The x axes collection
        /// </summary>
        private AxesCollection xAxesCollection;

        /// <summary>
        /// The y axes collection
        /// </summary>
        private AxesCollection yAxesCollection;

        /// <summary>
        /// The x axis
        /// </summary>
        private Axis xAxis;

        /// <summary>
        /// The y axis
        /// </summary>
        private Axis yAxis;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomingViewModel"/> class.
        /// </summary>
        public ZoomingViewModel()
        {
            this.ZoomingMode = ZoomingOptions.X;

            this.zoomCommand = new RelayCommand(this.ToggleZoomingMode, param => true);
            this.resetCommand = new RelayCommand(this.ResetZooming, param => true);

            this.xAxis = new Axis();
            this.xAxis.Title = "Time";
            this.xAxesCollection = new AxesCollection();
            this.xAxesCollection.Add(this.xAxis);

            this.yAxis = new Axis();
            this.yAxis.Title = "Kelvin";
            this.yAxesCollection = new AxesCollection();
            this.yAxesCollection.Add(this.yAxis);

            this.xAxis.LabelFormatter = val => this.GetDateTime(val).ToString("HH:mm");
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the x maximum.
        /// </summary>
        /// <value>
        /// The x maximum.
        /// </value>
        public DateTime XMax
        {
            get
            {
                return DateTime.Now;
            }

            set
            {
                this.xAxis.MaxValue = value.Ticks;
                this.RaisePropertyChanged("XAxisCollection");
            }
        }

        /// <summary>
        /// Gets or sets the x minimum.
        /// </summary>
        /// <value>
        /// The x minimum.
        /// </value>
        public DateTime XMin
        {
            get
            {
                return DateTime.Now;
            }

            set
            {
                this.xAxis.MinValue = value.Ticks;
                this.RaisePropertyChanged("XAxisCollection");
            }
        }

        /// <summary>
        /// Gets or sets the y maximum.
        /// </summary>
        /// <value>
        /// The y maximum.
        /// </value>
        public double YMax
        {
            get
            {
                return 300;
            }

            set
            {
                this.yAxis.MaxValue = value;
                this.RaisePropertyChanged("YAxisCollection");
            }
        }

        /// <summary>
        /// Gets or sets the y maximum.
        /// </summary>
        /// <value>
        /// The y maximum.
        /// </value>
        public double YMin
        {
            get
            {
                return 0;
            }

            set
            {
                this.yAxis.MinValue = value;
                this.RaisePropertyChanged("YAxisCollection");
            }
        }

        /// <summary>
        /// Gets the x axis collection.
        /// </summary>
        /// <value>
        /// The x axis collection.
        /// </value>
        public AxesCollection XAxisCollection
        {
            get
            {
                return this.xAxesCollection;
            }
        }

        /// <summary>
        /// Gets the y axis collection.
        /// </summary>
        /// <value>
        /// The y axis collection.
        /// </value>
        public AxesCollection YAxisCollection
        {
            get
            {
                return this.yAxesCollection;
            }
        }

        /// <summary>
        /// Gets the reset command.
        /// </summary>
        /// <value>
        /// The reset command.
        /// </value>
        public ICommand ResetCommand
        {
            get
            {
                return this.resetCommand;
            }
        }

        /// <summary>
        /// Gets the zoom command.
        /// </summary>
        /// <value>
        /// The zoom command.
        /// </value>
        public ICommand ZoomCommand
        {
            get
            {
                return this.zoomCommand;
            }
        }

        /// <summary>
        /// Gets or sets the zooming mode.
        /// </summary>
        /// <value>
        /// The zooming mode.
        /// </value>
        public ZoomingOptions ZoomingMode
        {
            get
            {
                return this.zoomingMode;
            }

            set
            {
                this.zoomingMode = value;
                this.RaisePropertyChanged("ZoomingMode");
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Toggles the zooming mode.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void ToggleZoomingMode(object sender)
        {
            switch (this.ZoomingMode)
            {
                case ZoomingOptions.None:
                    this.ZoomingMode = ZoomingOptions.X;
                    break;
                case ZoomingOptions.X:
                    this.ZoomingMode = ZoomingOptions.Y;
                    break;
                case ZoomingOptions.Y:
                    this.ZoomingMode = ZoomingOptions.Xy;
                    break;
                case ZoomingOptions.Xy:
                    this.ZoomingMode = ZoomingOptions.None;
                    break;
                default:
                    this.ZoomingMode = ZoomingOptions.None;
                    break;
            }
        }

        /// <summary>
        /// Resets the zooming.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void ResetZooming(object sender)
        {
            this.xAxis.MinValue = double.NaN;
            this.xAxis.MaxValue = double.NaN;
            this.yAxis.MaxValue = double.NaN;
            this.yAxis.MinValue = 0;

            this.RaisePropertyChanged("XAxisCollection");
            this.RaisePropertyChanged("YAxisCollection");
        }

        /// <summary>
        /// Gets the date time.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>Time in hours and minutes.</returns>
        private DateTime GetDateTime(double val)
        {
            //this.RaisePropertyChanged("YMin");
            //this.RaisePropertyChanged("YMax");
            //this.RaisePropertyChanged("XMin");
            //this.RaisePropertyChanged("XMax");

            try
            {
                return new DateTime((long)val);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.ToString());
                return new DateTime();
            }
        }

        #endregion Methods
    }
}
