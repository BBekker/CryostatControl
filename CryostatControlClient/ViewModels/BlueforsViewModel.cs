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

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueforsViewModel"/> class.
        /// </summary>
        public BlueforsViewModel()
        {
            this.blueforsModel = new BlueforsModel();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the cold plate3 k line series.
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
    }
}
