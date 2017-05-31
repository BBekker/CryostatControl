// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlueforsViewModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The abstract view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    using CryostatControlClient.Models;

    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Wpf;

    /// <summary>
    /// Bluefors ViewModel
    /// </summary>
    public class BlueforsViewModel : AbstractViewModel
    {
        #region Fields

        /// <summary>
        /// The bluefors model
        /// </summary>
        private BlueforsModel blueforsModel;

        /// <summary>
        /// The zooming mode
        /// </summary>
        private ZoomingOptions zoomingMode;

        /// <summary>
        /// The switch command
        /// </summary>
        private ICommand zoomCommand;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueforsViewModel"/> class.
        /// </summary>
        public BlueforsViewModel()
        {
            this.blueforsModel = new BlueforsModel();

            this.ZoomingMode = ZoomingOptions.X;

            this.zoomCommand = new RelayCommand(this.ToogleZoomingMode, param => true);
        }

        #endregion Constructor

        #region Properties

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

        /// <summary>
        /// Gets the cold plate3 k line series.
        /// </summary>
        /// <value>
        /// The cold plate3 k line series.
        /// </value>
        public LineSeries ColdPlate3KLineSeriesBottom
        {
            get
            {
                return this.blueforsModel.ColdPlate3KLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the cold plate3 k line series.
        /// </summary>
        /// <value>
        /// The cold plate3 k line series.
        /// </value>
        public LineSeries ColdPlate50KLineSeriesBottom
        {
            get
            {
                return this.blueforsModel.ColdPlate50KLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the cold plate3 k line series.
        /// </summary>
        /// <value>
        /// The cold plate3 k line series.
        /// </value>
        public LineSeries ColdPlate3KLineSeries
        {
            get
            {
                return this.blueforsModel.ColdPlate3KLineSeries;
            }
        }

        /// <summary>
        /// Gets the cold plate3 k line series.
        /// </summary>
        /// <value>
        /// The cold plate3 k line series.
        /// </value>
        public LineSeries ColdPlate50KLineSeries
        {
            get
            {
                return this.blueforsModel.ColdPlate50KLineSeries;
            }
        }

        /// <summary>
        /// Gets or sets the cold plate 3 K temperature.
        /// </summary>
        /// <value>
        /// The cold plate 3 K temperature.
        /// </value>
        public double ColdPlate3KTemp
        {
            get
            {
                return this.blueforsModel.ColdPlate3KTemp;
            }

            set
            {
                this.blueforsModel.ColdPlate3KTemp = value;
                this.RaisePropertyChanged("ColdPlate3KTemp");
            }
        }

        /// <summary>
        /// Gets or sets the cold plate 50 K temperature.
        /// </summary>
        /// <value>
        /// The cold plate 50 K temperature.
        /// </value>
        public double ColdPlate50KTemp
        {
            get
            {
                return this.blueforsModel.ColdPlate50KTemp;
            }

            set
            {
                this.blueforsModel.ColdPlate50KTemp = value;
                this.RaisePropertyChanged("ColdPlate50KTemp");
            }
        }

        /// <summary>
        /// Gets or sets the connection state.
        /// </summary>
        public double ConnectionState
        {
            get
            {
                return this.blueforsModel.ConnectionState;
            }

            set
            {
                this.blueforsModel.ConnectionState = value;
                this.RaisePropertyChanged("ConnectionState");
                this.RaisePropertyChanged("ConnectionStateConverted");
            }
        }

        /// <summary>
        /// Gets the connection state converted.
        /// </summary>
        public string ConnectionStateConverted
        {
            get
            {
                return this.ConvertConnectionStateNumberToString(this.blueforsModel.ConnectionState);
            }
        }

        /// <summary>
        /// Gets or sets the heater power.
        /// </summary>
        public double HeaterPower
        {
            get
            {
                return this.blueforsModel.HeaterPower;
            }

            set
            {
                this.blueforsModel.HeaterPower = value;
                this.RaisePropertyChanged("HeaterPower");
            }
        }

        #endregion Properties

        private void ToogleZoomingMode(object sender)
        {
            switch (ZoomingMode)
            {
                case ZoomingOptions.None:
                    ZoomingMode = ZoomingOptions.X;
                    break;
                case ZoomingOptions.X:
                    ZoomingMode = ZoomingOptions.Y;
                    break;
                case ZoomingOptions.Y:
                    ZoomingMode = ZoomingOptions.Xy;
                    break;
                case ZoomingOptions.Xy:
                    ZoomingMode = ZoomingOptions.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine("Toggled zooming mode");
        }

        private ChartValues<DateTimePoint> GetData()
        {
            var r = new Random();
            var trend = 100;
            var values = new ChartValues<DateTimePoint>();

            for (var i = 0; i < 100; i++)
            {
                var seed = r.NextDouble();
                if (seed > .8) trend += seed > .9 ? 50 : -50;
                values.Add(new DateTimePoint(DateTime.Now.AddDays(i), trend + r.Next(0, 10)));
            }

            return values;
        }
    }
}
