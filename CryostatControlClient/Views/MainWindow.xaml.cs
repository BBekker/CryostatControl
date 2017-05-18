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

    using CryostatControlClient.ViewModels;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The handler
        /// </summary>
        private PropertyChangedEventHandler modusHandler;

        /// <summary>
        /// The dc
        /// </summary>
        private DataContext dc;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Loaded += this.MainWindowLoaded;
            this.modusHandler = this.HandleModus;
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

            this.dc.TestViewModel.PropertyChanged += this.modusHandler;
            //this.dc.He7ViewModel.PropertyChanged += this.handler;
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
                string radio = this.dc.TestViewModel.SelectedComboIndex + string.Empty;
                string time = this.dc.TestViewModel.Time;

                Console.WriteLine("Start           - {0} - {1}", radio, time);
            }
            else
            {
                Console.WriteLine("Unknown command -" + action);
            }
        }
    }
}
