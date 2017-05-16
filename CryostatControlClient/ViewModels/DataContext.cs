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
    /// DataContext class containing containing all view models
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="CryostatControlClient.ViewModels.AbstractViewModel" />
    public class DataContext : INotifyPropertyChanged
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

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        public DataContext()
        {
            this.bvm = new BlueforsViewModel();
            this.cvm = new CompressorViewModel();
        }

        #endregion Constructor

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        /// <summary>
        /// Gets the BVM.
        /// </summary>
        /// <value>
        /// The BVM.
        /// </value>
        public BlueforsViewModel BVM
        {
            get
            {
                return this.bvm;
            }
        }

        /// <summary>
        /// Gets the BVM.
        /// </summary>
        /// <value>
        /// The BVM.
        /// </value>
        public CompressorViewModel CVM
        {
            get
            {
                return this.cvm;
            }
        }

        #endregion Properties
    }
}
