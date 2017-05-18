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

    using CryostatControlClient.Communication;
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
        /// The viewmodel container
        /// </summary>
        private ViewModelContainer viewModelContainer;

        /// <summary>
        /// The data receiver
        /// </summary>
        private DataReceiver dataReceiver;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Loaded += this.MainWindowLoaded;
            this.dataReceiver = new DataReceiver();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Updates the view models.
        /// </summary>
        /// <param name="data">The data.</param>
        public void UpdateViewModels(double[] data)
        {
            this.dataReceiver.UpdateViewModels(data, this.viewModelContainer);
        }


        /// <summary>
        /// Handles the Loaded event of the MainWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            this.viewModelContainer = new ViewModelContainer();

            this.DataContext = this.viewModelContainer;
        }

        #endregion Methods
    }
}
