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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.Loaded += this.MainWindowLoaded;
        }


        /// <summary>
        /// Handles the Loaded event of the MainWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            DataContext dc = new DataContext();

            this.DataContext = dc;

            dc.BlueforsViewModel.ColdPlate3KTemp = 3000;
            dc.CompressorViewModel.OperatingState = 1000;
            dc.He7ViewModel.FourKPlateTemp = 5000;

            Console.WriteLine(dc.BlueforsViewModel.ColdPlate3KTemp);
        }
    }
}
