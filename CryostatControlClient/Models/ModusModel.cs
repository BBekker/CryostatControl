// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModusModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The abstract view model.
// </summary>
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

        /// <summary>
        /// The selected tab index
        /// </summary>
        private int selectedComboIndex;

        /// <summary>
        /// The modus
        /// </summary>
        private int modus;

        /// <summary>
        /// The command
        /// </summary>
        private string time;

        /// <summary>
        /// The server
        /// </summary>
        private bool serverConnection;

        /// <summary>
        /// The show date time
        /// </summary>
        private string showDateTime;

        /// <summary>
        /// The selected date
        /// </summary>
        private DateTime selectedDate;

        /// <summary>
        /// The selected time
        /// </summary>
        private DateTime selectedTime;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ModusModel"/> class.
        /// </summary>
        public ModusModel()
        {
            this.time = "Now";
            this.selectedDate = DateTime.Now;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets the show date time.
        /// </summary>
        /// <value>
        /// The show date time.
        /// </value>
        public string ShowDateTime
        {
            get
            {
                return this.showDateTime;
            }

            set
            {
                this.showDateTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the selected time.
        /// </summary>
        /// <value>
        /// The selected date.
        /// </value>
        public DateTime SelectedTime
        {
            get
            {
                return this.selectedTime;
            }

            set
            {
                this.selectedTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the selected date.
        /// </summary>
        /// <value>
        /// The selected date.
        /// </value>
        public DateTime SelectedDate
        {
            get
            {
                return this.selectedDate;
            }

            set
            {
                this.selectedDate = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the selected combo.
        /// </summary>
        /// <value>
        /// The index of the selected combo.
        /// </value>
        public int SelectedComboIndex
        {
            get
            {
                return this.selectedComboIndex;
            }

            set
            {
                this.selectedComboIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the server is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if server connected; otherwise, <c>false</c>.
        /// </value>
        public bool ServerConnection
        {
            get
            {
                return this.serverConnection;
            }

            set
            {
                this.serverConnection = value;
            }
        }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public string Time
        {
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
            }
        }

        /// <summary>
        /// Gets or sets the modus.
        /// </summary>
        /// <value>
        /// The modus.
        /// </value>
        public int Modus
        {
            get
            {
                return this.modus;
            }

            set
            {
                this.modus = value;
            }
        }

        #endregion Properties
    }
}
