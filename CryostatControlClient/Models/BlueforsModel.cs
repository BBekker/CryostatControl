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
        private double coldPlate30KTemp;

        /// <summary>
        /// The cold plate 5 K temperature
        /// </summary>
        private double coldPlate50KTemp;

        /// <summary>
        /// The connection state.
        /// </summary>
        private double connectionState;

        /// <summary>
        /// The heater power.
        /// </summary>
        private double heaterPower;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the cold plate 30 K temperature.
        /// </summary>
        /// <value>
        /// The cold plate 30k temperature.
        /// </value>
        public double ColdPlate30KTemp
        {
            get
            {
                return this.coldPlate30KTemp;
            }

            set
            {
                this.coldPlate30KTemp = value;
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
