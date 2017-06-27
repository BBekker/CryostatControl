// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChartViewModel.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System;
    using System.Windows.Input;

    using CryostatControlClient.Models;

    using LiveCharts;
    using LiveCharts.Wpf;

    /// <summary>
    /// The zooming view model.
    /// </summary>
    /// <seealso cref="CryostatControlClient.ViewModels.AbstractViewModel" />
    public class ChartViewModel : AbstractViewModel
    {
        #region Fields

        /// <summary>
        /// The zoom command
        /// </summary>
        private ICommand zoomCommand;

        /// <summary>
        /// The reset zooming command
        /// </summary>
        private ICommand resetCommand;

        /// <summary>
        /// The chart model
        /// </summary>
        private ChartModel chartModel;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartViewModel"/> class.
        /// </summary>
        public ChartViewModel()
        {
            this.chartModel = new ChartModel();

            this.zoomCommand = new RelayCommand(this.ToggleZoomingMode, param => true);
            this.resetCommand = new RelayCommand(this.ResetZooming, param => true);
        }

        #endregion Constructor

        #region Properties

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
        /// Gets or sets the x maximum.
        /// </summary>
        /// <value>
        /// The x maximum.
        /// </value>
        public DateTime XMax
        {
            get
            {
                return this.chartModel.XMax;
            }

            set
            {
                this.chartModel.XMax = value;
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
                return this.chartModel.XMin;
            }

            set
            {
                this.chartModel.XMin = value;
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
                return this.chartModel.YMax;
            }

            set
            {
                this.chartModel.YMax = value;
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
                return this.chartModel.YMin;
            }

            set
            {
                this.chartModel.YMin = value;
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
                return this.chartModel.XAxisCollection;
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
                return this.chartModel.YAxisCollection;
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
                return this.chartModel.ZoomingMode;
            }

            set
            {
                this.chartModel.ZoomingMode = value;
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
            this.XMin = this.chartModel.GetDateTime(double.NaN);
            this.XMax = this.chartModel.GetDateTime(double.NaN);
            this.YMax = double.NaN;
            this.YMin = 0;

            this.RaisePropertyChanged("XAxisCollection");
            this.RaisePropertyChanged("YAxisCollection");
        }

        #endregion Methods
    }
}
