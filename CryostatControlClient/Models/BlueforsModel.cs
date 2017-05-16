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
    public class BlueforsModel
    {
        #region Fields

        /// <summary>
        /// The cold plate 3 K temperature
        /// </summary>
        private int coldPlate3KTemp;

        /// <summary>
        /// The cold plate 50 K temperature
        /// </summary>
        private int coldPlate50KTemp;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the cold plate 3 K temperature.
        /// </summary>
        /// <value>
        /// The cold plate3 k temperature.
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
            }
        }

        /// <summary>
        /// Gets or sets the cold plate 50 K temperature.
        /// </summary>
        /// <value>
        /// The cold plate 50 K temperature.
        /// </value>
        public int ColdPlate5KTemp
        {
            get
            {
                return this.coldPlate50KTemp;
            }

            set
            {
                this.coldPlate50KTemp = value;
            }
        }

        #endregion Properties
    }
}
