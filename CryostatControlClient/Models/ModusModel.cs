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
        /// The command
        /// </summary>
        private string time;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ModusModel"/> class.
        /// </summary>
        public ModusModel()
        {
            this.time = "Now";
        }

        #endregion Constructor

        #region Properties

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

        #endregion Properties
    }
}
