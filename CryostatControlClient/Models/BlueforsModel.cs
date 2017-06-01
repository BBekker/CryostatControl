//-----------------------------------------------------------------------
// <copyright file="BlueforsModel.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Wpf;

    /// <summary>
    /// The Bluefors model
    /// </summary>
    public class BlueforsModel : AbstractModel
    {
        #region Fields

        /// <summary>
        /// The cold plate 3 K temperature
        /// </summary>
        private double coldPlate3KTemp;

        /// <summary>
        /// The cold plate 50 K temperature
        /// </summary>
        private double coldPlate50KTemp;

        /// <summary>
        /// The cold plate3 k line series
        /// </summary>
        private LineSeries coldPlate3KLineSeries;

        /// <summary>
        /// The cold plate50 k line series
        /// </summary>
        private LineSeries coldPlate50KLineSeries;

        /// <summary>
        /// The cold plate3 k temporary list
        /// </summary>
        private double[] coldPlate3KTemporaryList;

        /// <summary>
        /// The cold plate50 k temporary list
        /// </summary>
        private double[] coldPlate50KTemporaryList;

        /// <summary>
        /// The cold plate3 k temporary list
        /// </summary>
        private double[] coldPlate3KTemporaryListBottom;

        /// <summary>
        /// The cold plate50 k temporary list
        /// </summary>
        private double[] coldPlate50KTemporaryListBottom;

        /// <summary>
        /// The cold plate3 k line series
        /// </summary>
        private LineSeries coldPlate3KLineSeriesBottom;

        /// <summary>
        /// The cold plate50 k line series
        /// </summary>
        private LineSeries coldPlate50KLineSeriesBottom;

        /// <summary>
        /// The connection state.
        /// </summary>
        private double connectionState;

        /// <summary>
        /// The heater power.
        /// </summary>
        private double heaterPower;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueforsModel"/> class.
        /// </summary>
        public BlueforsModel()
        {
            this.coldPlate3KTemporaryList = new double[this.TemporaryListSize];
            this.coldPlate50KTemporaryList = new double[this.TemporaryListSize];

            this.coldPlate3KTemporaryListBottom = new double[this.TemporaryListSize];
            this.coldPlate50KTemporaryListBottom = new double[this.TemporaryListSize];

            this.coldPlate3KLineSeries = new LineSeries { Title = "Bluefors - 3K Plate", Values = new ChartValues<DateTimePoint>() };
            this.coldPlate50KLineSeries = new LineSeries { Title = "Bluefors - 50K Plate", Values = new ChartValues<DateTimePoint>() };
            this.coldPlate3KLineSeriesBottom = new LineSeries { Title = "Bluefors - 3K Plate", Values = new ChartValues<DateTimePoint>() };
            this.coldPlate50KLineSeriesBottom = new LineSeries { Title = "Bluefors - 50K Plate", Values = new ChartValues<DateTimePoint>() };
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the cold plate3 k visibility.
        /// </summary>
        /// <value>
        /// The cold plate3 k visibility.
        /// </value>
        public Visibility ColdPlate3KVisibility
        {
            get
            {
                return this.coldPlate3KLineSeries.Visibility;
            }

            set
            {
                this.coldPlate3KLineSeries.Visibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the cold plate50 k visibility.
        /// </summary>
        /// <value>
        /// The cold plate50 k visibility.
        /// </value>
        public Visibility ColdPlate50KVisibility
        {
            get
            {
                return this.coldPlate50KLineSeries.Visibility;
            }

            set
            {
                this.coldPlate50KLineSeries.Visibility = value;
            }
        }

        /// <summary>
        /// Gets the cold plate 3 k line series.
        /// </summary>
        /// <value>
        /// The cold plate 3 k line series.
        /// </value>
        public LineSeries ColdPlate3KLineSeriesBottom
        {
            get
            {
                return this.coldPlate3KLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the cold plate 50 k line series.
        /// </summary>
        /// <value>
        /// The cold plate 50 k line series.
        /// </value>
        public LineSeries ColdPlate50KLineSeriesBottom
        {
            get
            {
                return this.coldPlate50KLineSeriesBottom;
            }
        }

        /// <summary>
        /// Gets the cold plate 3 k line series.
        /// </summary>
        /// <value>
        /// The cold plate 3 k line series.
        /// </value>
        public LineSeries ColdPlate3KLineSeries
        {
            get
            {
                return this.coldPlate3KLineSeries;
            }
        }

        /// <summary>
        /// Gets the cold plate 50 k line series.
        /// </summary>
        /// <value>
        /// The cold plate 50 k line series.
        /// </value>
        public LineSeries ColdPlate50KLineSeries
        {
            get
            {
                return this.coldPlate50KLineSeries;
            }
        }

        /// <summary>
        /// Gets or sets the cold plate 3 K temperature.
        /// </summary>
        /// <value>
        /// The cold plate 3K temperature.
        /// </value>
        public double ColdPlate3KTemp
        {
            get
            {
                return this.coldPlate3KTemp;
            }

            set
            {
                this.coldPlate3KTemp = value;
                this.coldPlate3KTemporaryList = this.AddToGraph(this.coldPlate3KTemporaryList, this.coldPlate3KLineSeries, value);
                this.coldPlate3KTemporaryListBottom = this.AddToGraph(this.coldPlate3KTemporaryListBottom, this.coldPlate3KLineSeriesBottom, value);
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
                return this.coldPlate50KTemp;
            }

            set
            {
                this.coldPlate50KTemp = value;
                this.coldPlate50KTemporaryList = this.AddToGraph(this.coldPlate50KTemporaryList, this.coldPlate50KLineSeries, value);
                this.coldPlate50KTemporaryListBottom = this.AddToGraph(this.coldPlate50KTemporaryListBottom, this.coldPlate50KLineSeriesBottom, value);
            }
        }

        /// <summary>
        /// Gets or sets the connection state.
        /// </summary>
        public double ConnectionState
        {
            get
            {
                return this.connectionState;
            }

            set
            {
                this.connectionState = value;
            }
        }

        /// <summary>
        /// Gets or sets the heater power.
        /// </summary>
        public double HeaterPower
        {
            get
            {
                return this.heaterPower;
            }

            set
            {
                this.heaterPower = value;
            }
        }

        #endregion Properties
    }
}
