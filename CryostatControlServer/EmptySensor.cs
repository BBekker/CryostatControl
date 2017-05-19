// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmptySensor.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer
{
    /// <summary>
    /// Empty sensor class, as placeholder when a sensor cannot be initialized.
    /// </summary>
    /// <seealso cref="CryostatControlServer.ISensor" />
    public class EmptySensor : ISensor
    {
        #region Properties

        /// <summary>
        /// Gets or sets the interval data is read at.
        /// This should not change anything
        /// </summary>
        public int Interval
        {
            get
            {
                return int.MinValue;
            }

            set
            {
                ////do nothing
            }
        }

        /// <summary>
        /// Gets the value, min value is returned as error value.
        /// </summary>
        public double Value
        {
            get
            {
                return double.MinValue;
            }
        }

        #endregion Properties
    }
}