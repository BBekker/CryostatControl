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
    using System.ComponentModel;
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

        /// <summary>
        /// The data sender
        /// </summary>
        private DataSender dataSender;

        /// <summary>
        /// The handler
        /// </summary>
        private PropertyChangedEventHandler modusHandler;

        /// <summary>
        /// The handler
        /// </summary>
        private PropertyChangedEventHandler heliumHandler;

        /// <summary>
        /// The logger handler.
        /// </summary>
        private PropertyChangedEventHandler loggerHandler;

        /// <summary>
        /// The comp handler
        /// </summary>
        private PropertyChangedEventHandler compHandler;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Loaded += this.MainWindowLoaded;

            ServerCheck serverCheck = (Application.Current as App).ServerCheck;

            this.dataReceiver = new DataReceiver();
            this.dataSender = new DataSender(serverCheck);

            this.modusHandler = this.HandleModus;
            this.compHandler = this.HandleComp;
            this.loggerHandler = this.HandleLogger;
            this.heliumHandler = this.HandleHe;
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
        /// <param name="mode">The mode.</param>
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

            this.viewModelContainer.ModusViewModel.PropertyChanged += this.modusHandler;
            this.viewModelContainer.CompressorViewModel.PropertyChanged += this.compHandler;
            this.viewModelContainer.LoggingViewModel.PropertyChanged += this.loggerHandler;
            this.viewModelContainer.He7ViewModel.PropertyChanged += this.heliumHandler;

            //this.dataSender.SetCompressorScales(this.viewModelContainer);
            //this.dataSender.SetLoggerState(this.viewModelContainer);
        }

        /// <summary>
        /// Handles the changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void HandleModus(object sender, PropertyChangedEventArgs e)
        {
            string action = e.PropertyName;

            if (action == "StartPressed")
            {
                this.dataSender.UpdateModus(this.viewModelContainer);
            }
            else if (action == "CancelPressed")
            {
                this.dataSender.CancelModus();
            }
            else if (action == "ManualPressed")
            {
                this.dataSender.ManualModus();
            }
            else
            {
                // todo: unknow action, throw exception or something?
            }
        }

        /// <summary>
        /// Handles the comp.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void HandleComp(object sender, PropertyChangedEventArgs e)
        {
            string action = e.PropertyName;

            if (action == "TurnOn")
            {
                this.dataSender.SwitchCompressor(true);
            }
            else if (action == "TurnOff")
            {
                this.dataSender.SwitchCompressor(false);
            }
        }

        /// <summary>
        /// Handles the changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void HandleHe(object sender, PropertyChangedEventArgs e)
        {
            string action = e.PropertyName;

            if (action == "UpdateHe7Pressed")
            {
                this.dataSender.UpdateHelium(this.viewModelContainer);
            }
        }

        /// <summary>
        /// Handles the logger.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void HandleLogger(object sender, PropertyChangedEventArgs e)
        {
            string action = e.PropertyName;

            if (action == "StartPressed")
            {
                this.dataSender.SendDataToBeLogged(this.viewModelContainer);
            }
            else if (action == "CancelPressed")
            {
                this.dataSender.CancelLogging();
            }
            else
            {
                // todo: unknow action, throw exception or something?
            }
        }
        #endregion Methods
    }
}