//-----------------------------------------------------------------------
// <copyright file="BlueforsModel.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;

    /// <summary>
    /// The Bluefors model
    /// </summary>
    /// <seealso cref="CryostatControlClient.Models.AbstractModel" />
    public class BlueforsModel : AbstractModel
    {
        #region Fields

        /// <summary>
        /// The cold plate 3 K temperature
        /// </summary>
        private int coldPlate3KTemp;

        /// <summary>
        /// The cold plate 5 K temperature
        /// </summary>
        private int coldPlate5KTemp;

        #endregion Fields

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
                return this.coldPlate3KTemp;
            }

            set
            {
                this.coldPlate3KTemp = value;
                this.OnPropertyChanged("ColdPlate3KTemp");
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
                return this.coldPlate5KTemp;
            }

            set
            {
                this.coldPlate5KTemp = value;
                this.OnPropertyChanged("ColdPlate5KTemp");
            }
        }

        #endregion Properties
    }
}
