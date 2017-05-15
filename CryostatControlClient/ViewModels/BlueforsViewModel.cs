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
    using CryostatControlClient.Models;

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
        /// Gets or sets the cold plate 3 K temperature.
        /// </summary>
        /// <value>
        /// The cold plate3 k temporary.
        /// </value>
        public int ColdPlate3KTemp
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
        /// Gets or sets the cold plate 5 K temperature.
        /// </summary>
        /// <value>
        /// The cold plate 5 K temporary.
        /// </value>
        public int ColdPlate5KTemp
        {
            get
            {
                return this.blueforsModel.ColdPlate5KTemp;
            }

            set
            {
                this.blueforsModel.ColdPlate5KTemp = value;
                this.RaisePropertyChanged("ColdPlate5KTemp");
            }
        }

        #endregion Properties
    }
}
