// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Views
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using CryostatControlClient.ViewModels;

    using CryostatControlServer.Compressor;
    using CryostatControlServer.HostService.Enumerators;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        /// <summary>
        /// The DataContext
        /// </summary>
        private DataContext dc;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Loaded += this.MainWindowLoaded;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Updates the compressor viewmodel.
        /// </summary>
        /// <param name="data">The data.</param>
        public void UpdateCompressor(float[] data)
        {
            if (this.dc != null)
            {
                //update all compressor values
            }
        }

        /// <summary>
        /// Updates the he7 viewmodel.
        /// </summary>
        /// <param name="data">The data.</param>
        public void UpdateHe7(float[] data)
        {
            if (this.dc != null)
            {
                //update all he7 values
            }
        }

        /// <summary>
        /// Updates the bluefors viewmodel.
        /// </summary>
        /// <param name="data">The data.</param>
        public void UpdateBluefors(float[] data)
        {
            if (this.dc != null)
            {
                //update all bluefors values
            }
        }

        /// <summary>
        /// Handles the Loaded event of the MainWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            this.dc = new DataContext();

            this.DataContext = this.dc;
        }

        #endregion Methods
    }
}
