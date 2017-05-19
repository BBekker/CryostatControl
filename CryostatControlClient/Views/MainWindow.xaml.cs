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
        /// The handler
        /// </summary>
        private PropertyChangedEventHandler modusHandler;

        /// <summary>
        /// The handler
        /// </summary>
        private PropertyChangedEventHandler heHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Loaded += this.MainWindowLoaded;
            this.dataReceiver = new DataReceiver();

            this.modusHandler = this.HandleModus;
            this.heHandler = this.HandleHe;
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

            this.viewModelContainer.ModusViewModel.PropertyChanged += this.modusHandler;
            this.viewModelContainer.He7ViewModel.PropertyChanged += this.heHandler;
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
                string radio = this.viewModelContainer.ModusViewModel.SelectedComboIndex + string.Empty;
                string time = this.viewModelContainer.ModusViewModel.Time;

                Console.WriteLine("Start           - {0} - {1}", radio, time);
            }
            else
            {
                Console.WriteLine("Unknown command - " + action);
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
                double he4PumpMax = this.viewModelContainer.He7ViewModel.He4PumpMax;
                double he4PumpNewVolt = this.viewModelContainer.He7ViewModel.He4PumpNewVolt;
                double he3PumpMax = this.viewModelContainer.He7ViewModel.He3PumpMax;
                double he3PumpNewVolt = this.viewModelContainer.He7ViewModel.He3PumpNewVolt;
                double he4SwitchMax1 = this.viewModelContainer.He7ViewModel.He4SwitchMax1;
                double he4SwitchMax2 = this.viewModelContainer.He7ViewModel.He4SwitchMax2;
                double he4SwitchNewVolt = this.viewModelContainer.He7ViewModel.He4SwitchNewVolt;
                double he3SwitchMax1 = this.viewModelContainer.He7ViewModel.He3SwitchMax1;
                double he3SwitchMax2 = this.viewModelContainer.He7ViewModel.He3SwitchMax2;
                double he3SwitchNewVolt = this.viewModelContainer.He7ViewModel.He3SwitchNewVolt;
                double fourKPlateMax1 = this.viewModelContainer.He7ViewModel.FourKPlateMax1;
                double fourKPlateMax2 = this.viewModelContainer.He7ViewModel.FourKPlateMax2;
                double he4HeadMax = this.viewModelContainer.He7ViewModel.He4HeadMax;
                double he3HeadMax = this.viewModelContainer.He7ViewModel.He3HeadMax;
                
                Console.WriteLine("Update He       - ");
                Console.WriteLine("    He4PumpMax        - {0}", he4PumpMax);
                Console.WriteLine("    He4PumpNewVolt    - {0}", he4PumpNewVolt);
                Console.WriteLine("    He3PumpMax        - {0}", he3PumpMax);
                Console.WriteLine("    He3PumpNewVolt    - {0}", he3PumpNewVolt);
                Console.WriteLine("    he4SwitchMax1     - {0}", he4SwitchMax1);
                Console.WriteLine("    he4SwitchMax2     - {0}", he4SwitchMax2);
                Console.WriteLine("    he4SwitchNewVolt  - {0}", he4SwitchNewVolt);
                Console.WriteLine("    he3SwitchMax1     - {0}", he3SwitchMax1);
                Console.WriteLine("    he3SwitchMax2     - {0}", he3SwitchMax2);
                Console.WriteLine("    he3SwitchNewVolt  - {0}", he3SwitchNewVolt);
                Console.WriteLine("    fourKPlateMax1    - {0}", fourKPlateMax1);
                Console.WriteLine("    fourKPlateMax2    - {0}", fourKPlateMax2);
                Console.WriteLine("    he4HeadMax        - {0}", he4HeadMax);
                Console.WriteLine("    he3HeadMax        - {0}", he3HeadMax);
            }
        }

        #endregion Methods
    }
}
