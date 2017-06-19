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

    using CryostatControlClient.Communication;
    using CryostatControlClient.ViewModels;

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

        /// <summary>
        /// Gets the view model container.
        /// </summary>
        /// <value>
        /// The view model container.
        /// </value>
        public ViewModelContainer Container
        {
            get
            {
                return this.viewModelContainer;
            }
        }

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
        /// Sets the state.
        /// </summary>
        /// <param name="modus">The modus.</param>
        public void SetState(int modus)
        {
            this.dataReceiver.SetState(modus, this.viewModelContainer);
        }

        /// <summary>
        /// Sets the is logging.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        public void SetIsLogging(bool state)
        {
            this.dataReceiver.SetIsLogging(state, this.viewModelContainer);
        }

        /// <summary>
        /// Updates the countdown.
        /// </summary>
        /// <param name="time">The time.</param>
        public void UpdateCountdown(DateTime time)
        {
            this.dataReceiver.UpdateCountdown(time, this.viewModelContainer);
        }

        /// <summary>
        /// The update notification.
        /// </summary>
        /// <param name="notification">
        /// The notification.
        /// </param>
        public void UpdateNotification(string[] notification)
        {
            this.dataReceiver.UpdateNotification(notification, this.viewModelContainer);
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