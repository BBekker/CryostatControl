// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataContext.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The abstract view model.
// </summary>

namespace CryostatControlClient.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The data context.
    /// </summary>
    public class DataContext 
    {
        #region Fields

        /// <summary>
        /// The BVM
        /// </summary>
        private BlueforsViewModel bvm;

        /// <summary>
        /// The CVM
        /// </summary>
        private CompressorViewModel cvm;

        /// <summary>
        /// The HVM
        /// </summary>
        private He7ViewModel hvm;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        public DataContext()
        {
            this.bvm = new BlueforsViewModel();
            this.cvm = new CompressorViewModel();
            this.hvm = new He7ViewModel();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the BlueforsViewModel.
        /// </summary>
        /// <value>
        /// The BlueforsViewModel.
        /// </value>
        public BlueforsViewModel BlueforsViewModel
        {
            get
            {
                return this.bvm;
            }
        }

        /// <summary>
        /// Gets the CompressorViewModel.
        /// </summary>
        /// <value>
        /// The CompressorViewModel.
        /// </value>
        public CompressorViewModel CompressorViewModel
        {
            get
            {
                return this.cvm;
            }
        }

        /// <summary>
        /// Gets the He7ViewModel.
        /// </summary>
        /// <value>
        /// The He7ViewModel.
        /// </value>
        public He7ViewModel He7ViewModel
        {
            get
            {
                return this.hvm;
            }
        }

        #endregion Properties
    }
}
