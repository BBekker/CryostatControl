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
    using System.Windows.Input;

    using LiveCharts;
    using LiveCharts.Defaults;

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

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomingViewModel"/> class.
        /// </summary>
        public ZoomingViewModel()
        {
            this.ZoomingMode = ZoomingOptions.X;

            this.zoomCommand = new RelayCommand(this.ToggleZoomingMode, param => true);
        }

        #endregion Constructor

        #region Properties

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

        #endregion Methods
    }
}
