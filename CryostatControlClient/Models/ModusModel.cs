// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModusModel.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Models
{
    using System;

    /// <summary>
    /// The model for the modi
    /// </summary>
    public class ModusModel
    {
        #region Fields

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ModusModel"/> class.
        /// </summary>
        public ModusModel()
        {
            this.Time = "Now";
            this.SelectedDate = DateTime.Now;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the planned time.
        /// </summary>
        /// <value>
        /// The planned time.
        /// </value>
        public DateTime PlannedTime { get; set; }

        /// <summary>
        /// Gets or sets the show date time.
        /// </summary>
        /// <value>
        /// The show date time.
        /// </value>
        public string ShowDateTime { get; set; }

        /// <summary>
        /// Gets or sets the selected time.
        /// </summary>
        /// <value>
        /// The selected time.
        /// </value>
        public DateTime SelectedTime { get; set; }

        /// <summary>
        /// Gets or sets the selected date.
        /// </summary>
        /// <value>
        /// The selected date.
        /// </value>
        public DateTime SelectedDate { get; set; }

        /// <summary>
        /// Gets or sets the index of the selected combo index.
        /// </summary>
        /// <value>
        /// The index of the selected combo index.
        /// </value>
        public int SelectedComboIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the server is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if server is connected; otherwise, <c>false</c>.
        /// </value>
        public bool ServerConnection { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the modus.
        /// </summary>
        /// <value>
        /// The modus.
        /// </value>
        public int Modus { get; set; }

        #endregion Properties
    }
}
