//-----------------------------------------------------------------------
// <copyright file="BlueforsModel.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;

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
            this.coldPlate3KLineSeries = new LineSeries { Title = "Bluefors - 3K Plate", Values = new ChartValues<DateTimePoint>() };
            this.coldPlate50KLineSeries = new LineSeries { Title = "Bluefors - 50K Plate", Values = new ChartValues<DateTimePoint>() };
        }

        #endregion Constructor

        #region Properties


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
                this.AddToGraph(this.coldPlate3KLineSeries, value);
                
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
                this.AddToGraph(this.coldPlate50KLineSeries, value);
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
