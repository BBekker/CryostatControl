﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataSender.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the He7ViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Communication
{
    using System;

    using CryostatControlClient.ViewModels;

    using CryostatControlServer.HostService.Enumerators;
    using Communication;
    using System.Windows;

    /// <summary>
    /// Sends data to the server
    /// </summary>
    public class DataSender
    {
        #region Fields

        /// <summary>
        /// The command service client
        /// </summary>
        private ServerCheck server;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSender"/> class.
        /// </summary>
        /// <param name="csc">The command service client.</param>
        public DataSender(ServerCheck server)
        {
            this.server = server;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Updates the modus.
        /// </summary>
        /// <param name="viewModelContainer">The view model container.</param>
        public void UpdateModus(ViewModelContainer viewModelContainer)
        {
            int radio = viewModelContainer.ModusViewModel.SelectedComboIndex;
            string time = viewModelContainer.ModusViewModel.Time;
            
            switch (radio)
            {
                case (int)ModusEnumerator.Cooldown:
                    this.server.CommandClient.Cooldown();
                    break;

                case (int)ModusEnumerator.Recycle:
                    this.server.CommandClient.Recycle();
                    break;

                case (int)ModusEnumerator.Warmup:
                    this.server.CommandClient.Warmup();
                    break;

                default:

                    // todo : some error for unknown modus?
                    break;
            }
        }

        /// <summary>
        /// Switches the compressor.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        public void SwitchCompressor(bool state)
        {
            this.server.CommandClient.SetCompressorState(state);
        }

        /// <summary>
        /// Sets the compressor scales.
        /// </summary>
        /// <param name="viewModelContainer">The view model container.</param>
        public void SetCompressorScales(ViewModelContainer viewModelContainer)
        {
            try
            {
                viewModelContainer.CompressorViewModel.TempScale =
                    this.server.CommandClient.ReadCompressorTemperatureScale();
                viewModelContainer.CompressorViewModel.PressureScale =
                    this.server.CommandClient.ReadCompressorPressureScale();
                Console.WriteLine("Dingen");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong with the server");
            }
        }

        /// <summary>
        /// Cancels the modus.
        /// </summary>
        public void CancelModus()
        {
            this.server.CommandClient.Cancel();
        }

        /// <summary>
        /// Updates the helium.
        /// </summary>
        /// <param name="viewModelContainer">The view model container.</param>
        public void UpdateHelium(ViewModelContainer viewModelContainer)
        {
            double[] writeHelium7 = new double[(int)HeaterEnumerator.HeaterAmount];

            writeHelium7[(int)HeaterEnumerator.He4Pump] = viewModelContainer.He7ViewModel.He4PumpNewVolt;
            writeHelium7[(int)HeaterEnumerator.He3Pump] = viewModelContainer.He7ViewModel.He3PumpNewVolt;
            writeHelium7[(int)HeaterEnumerator.He3Switch] = viewModelContainer.He7ViewModel.He3SwitchNewVolt;
            writeHelium7[(int)HeaterEnumerator.He4Switch] = viewModelContainer.He7ViewModel.He4SwitchNewVolt;

            this.server.CommandClient.WriteHelium7(writeHelium7);

            // These are the max settings, since it is not yet clear what to do with these they are commented out.

            // Console.WriteLine(viewModelContainer.He7ViewModel.He4PumpMax);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He4PumpNewVolt);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He4SwitchMax1);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He4SwitchMax2);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He4SwitchNewVolt);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He3PumpMax);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He3PumpNewVolt);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He3SwitchMax1);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He3SwitchMax2);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He3SwitchNewVolt);
            // Console.WriteLine(viewModelContainer.He7ViewModel.FourKPlateMax1);
            // Console.WriteLine(viewModelContainer.He7ViewModel.FourKPlateMax2);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He4HeadMax);
            // Console.WriteLine(viewModelContainer.He7ViewModel.He3HeadMax);
        }

        /// <summary>
        /// Sends the data to be logged.
        /// </summary>
        /// <param name="viewModelContainer">The view model container.</param>
        public void SendDataToBeLogged(ViewModelContainer viewModelContainer)
        {
            bool[] dataToBeLogged = viewModelContainer.LoggingViewModel.GetLoggingArray();
            int interval = (int)viewModelContainer.LoggingViewModel.LoggingInterval;

            this.server.CommandClient.StartLogging(interval, dataToBeLogged);
        }

        /// <summary>
        /// Cancels the logging.
        /// </summary>
        public void CancelLogging()
        {
            this.server.CommandClient.StopLogging();
        }

        #endregion Methods
    }
}