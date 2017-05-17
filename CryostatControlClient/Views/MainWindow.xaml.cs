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
        public void UpdateViewModels(float[] data)
        {
            Console.WriteLine("Received data: {0}" ,data[0]);
            this.UpdateHe7ViewModel(data);
            this.UpdateBlueforsViewModel(data);
            this.UpdateCompressorViewModel(data);
        }

        /// <summary>
        /// Updates the he7 view model.
        /// </summary>
        /// <param name="data">The data.</param>
        private void UpdateHe7ViewModel(float[] data)
        {
            if (this.dc != null)
            {
                //this.dc.He7ViewModel. = data[DataEnumerator.HeConnectionState];
                //this.dc.He7ViewModel. = data[DataEnumerator.He3Head];
                //this.dc.He7ViewModel. = data[DataEnumerator.He3HeadMax];
                //this.dc.He7ViewModel. = data[DataEnumerator.He3Pump];
                //this.dc.He7ViewModel. = data[DataEnumerator.He3PumpMax];
                //this.dc.He7ViewModel. = data[DataEnumerator.He4Head];
                //this.dc.He7ViewModel. = data[DataEnumerator.He4HeadMax];
                //this.dc.He7ViewModel. = data[DataEnumerator.He4Pump];
                //this.dc.He7ViewModel. = data[DataEnumerator.He4PumpMax];
                //this.dc.He7ViewModel. = data[DataEnumerator.He3Volt];
                //this.dc.He7ViewModel. = data[DataEnumerator.He4Volt];
                //this.dc.He7ViewModel. = data[DataEnumerator.He3SwitchTemp];
                //this.dc.He7ViewModel. = data[DataEnumerator.He3SwitchVolt];
                //this.dc.He7ViewModel. = data[DataEnumerator.He3SwitchMax1];
                //this.dc.He7ViewModel. = data[DataEnumerator.He3SwitchMax2];
                //this.dc.He7ViewModel. = data[DataEnumerator.He4SwitchTemp];
                //this.dc.He7ViewModel. = data[DataEnumerator.He4SwitchVolt];
                //this.dc.He7ViewModel. = data[DataEnumerator.He4SwitchMax1];
                //this.dc.He7ViewModel. = data[DataEnumerator.He4SwitchMax2];
                //this.dc.He7ViewModel. = data[DataEnumerator.HePlate2K];
                //this.dc.He7ViewModel. = data[DataEnumerator.HePlate4K];
                //this.dc.He7ViewModel. = data[DataEnumerator.HePlate4Kmax1];
                //this.dc.He7ViewModel. = data[DataEnumerator.HePlate4Kmax2];
            }
        }

        /// <summary>
        /// Updates the bluefors view model.
        /// </summary>
        /// <param name="data">The data.</param>
        private void UpdateBlueforsViewModel(float[] data)
        {
            if (this.dc != null)
            {
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComConnectionState];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComWaterIn];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComWaterOut];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComHelium];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComOil];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComLow];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComLowAvg];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComHigh];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComHighAvg];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComDeltaAvg];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComError];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComWarning];
                //this.dc.BlueforsViewModel. = data[DataEnumerator.ComHoursOfOperation];
            }
        }

        /// <summary>
        /// Updates the compressor view model.
        /// </summary>
        /// <param name="data">The data.</param>
        private void UpdateCompressorViewModel(float[] data)
        {
            if (this.dc != null)
            {
                //this.dc.CompressorViewModel. = data[DataEnumerator.LakeConnectionState];
                //this.dc.CompressorViewModel. = data[DataEnumerator.LakePlate50K];
                //this.dc.CompressorViewModel. = data[DataEnumerator.LakePlate3K];
                //this.dc.CompressorViewModel. = data[DataEnumerator.LakeHeater];
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
