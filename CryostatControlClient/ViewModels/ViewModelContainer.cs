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
    public class ViewModelContainer 
    {
        #region Fields

        /// <summary>
        /// The BVM
        /// </summary>
        private BlueforsViewModel blueforsViewModel;

        /// <summary>
        /// The CVM
        /// </summary>
        private CompressorViewModel compressorViewModel;

        /// <summary>
        /// The HVM
        /// </summary>
        private He7ViewModel he7ViewModel;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelContainer" /> class.
        /// </summary>
        public ViewModelContainer()
        {
            this.blueforsViewModel = new BlueforsViewModel();
            this.compressorViewModel = new CompressorViewModel();
            this.he7ViewModel = new He7ViewModel();
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
                return this.blueforsViewModel;
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
                return this.compressorViewModel;
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
                return this.he7ViewModel;
            }
        }

        #endregion Properties
    }
}
