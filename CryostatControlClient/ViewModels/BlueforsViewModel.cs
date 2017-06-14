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
    using System.Windows.Media;
    using System;
    using System.Windows;
    using System.Windows.Input;

    using CryostatControlClient.Models;

    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Geared;
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
        /// The cold plate3 k visibility command
        /// </summary>
        private ICommand coldPlate3KVisibilityCommand;

        /// <summary>
        /// The cold plate50 k visibility command
        /// </summary>
        private ICommand coldPlate50KVisibilityCommand;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueforsViewModel"/> class.
        /// </summary>
        public BlueforsViewModel()
        {
            this.blueforsModel = new BlueforsModel();

            this.coldPlate3KVisibilityCommand = new RelayCommand(this.OnColdPlate3KVisibility, param => true);
            this.coldPlate50KVisibilityCommand = new RelayCommand(this.OnColdPlate50KVisibility, param => true);
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the color of the connection state.
        /// </summary>
        /// <value>
        /// The color of the connection state.
        /// </value>
        public SolidColorBrush ConnectionStateColor
        {
            get
            {
                return this.DisplayColor((ColorState)this.ConnectionState);
            }
        }

        /// <summary>
        /// Gets the cold plate3 k visibility command.
        /// </summary>
        /// <value>
        /// The cold plate3 k visibility command.
        /// </value>
        public ICommand ColdPlate3KVisibilityCommand
        {
            get
            {
                return this.coldPlate3KVisibilityCommand;
            }
        }

        /// <summary>
        /// Gets the cold plate50 k visibility command.
        /// </summary>
        /// <value>
        /// The cold plate50 k visibility command.
        /// </value>
        public ICommand ColdPlate50KVisibilityCommand
        {
            get
            {
                return this.coldPlate50KVisibilityCommand;
            }
        }

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
                return this.blueforsModel.ColdPlate3KVisibility;
            }

            set
            {
                this.blueforsModel.ColdPlate3KVisibility = value;
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
                return this.blueforsModel.ColdPlate50KVisibility;
            }

            set
            {
                this.blueforsModel.ColdPlate50KVisibility = value;
            }
        }

        /// <summary>
        /// Gets the cold plate3 k line series.
        /// </summary>
        /// <value>
        /// The cold plate3 k line series.
        /// </value>
        public GLineSeries ColdPlate3KLineSeriesBottom
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
        public GLineSeries ColdPlate50KLineSeriesBottom
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
        public GLineSeries ColdPlate3KLineSeries
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
        public GLineSeries ColdPlate50KLineSeries
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
                this.RaisePropertyChanged("ConnectionStateColor");
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

        #region Methods

        /// <summary>
        /// Called when [cold plate50 k visibility].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void OnColdPlate50KVisibility(object sender)
        {
            if (this.ColdPlate50KVisibility == Visibility.Hidden)
            {
                this.ColdPlate50KVisibility = Visibility.Visible;
            }
            else
            {
                this.ColdPlate50KVisibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Called when [cold plate3 k visibility].
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void OnColdPlate3KVisibility(object sender)
        {
            if (this.ColdPlate3KVisibility == Visibility.Hidden)
            {
                this.ColdPlate3KVisibility = Visibility.Visible;
            }
            else
            {
                this.ColdPlate3KVisibility = Visibility.Hidden;
            }
        }

        #endregion Methods
    }
}
