// --------------------------------------------------------------------------------------------------------------------
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
    using System.ServiceModel;

    using CryostatControlClient.ServiceReference1;
    using CryostatControlClient.ViewModels;

    using CryostatControlServer.HostService.DataContracts;
    using CryostatControlServer.HostService.Enumerators;

    /// <summary>
    /// Sends data to the server
    /// </summary>
    public class DataSender
    {
        #region Methods

        /// <summary>
        /// Updates the modus.
        /// </summary>
        /// <param name="viewModelContainer">The view model container.</param>
        public void UpdateModus(ViewModelContainer viewModelContainer)
        {
            int radio = viewModelContainer.ModusViewModel.SelectedComboIndex;
            string postpone = viewModelContainer.ModusViewModel.Time;
            DateTime startTime = DateTime.Now;

            if (postpone == "Scheduled")
            {
                startTime = viewModelContainer.ModusViewModel.SelectedDate;
                TimeSpan time = viewModelContainer.ModusViewModel.SelectedTime.TimeOfDay;
                startTime = startTime.Date.Add(time);

                switch (radio)
                {
                    case (int)ModusEnumerator.Cooldown:
                        ServerCheck.CommandClient.CooldownTime(startTime);
                        break;

                    case (int)ModusEnumerator.Recycle:
                        ServerCheck.CommandClient.RecycleTime(startTime);
                        break;

                    case (int)ModusEnumerator.Warmup:
                        ServerCheck.CommandClient.WarmupTime(startTime);
                        break;
                }
            }
            else
            {
                switch (radio)
                {
                    case (int)ModusEnumerator.Cooldown:
                        ServerCheck.CommandClient.Cooldown();
                        break;

                    case (int)ModusEnumerator.Recycle:
                        ServerCheck.CommandClient.Recycle();
                        break;

                    case (int)ModusEnumerator.Warmup:
                        ServerCheck.CommandClient.Warmup();
                        break;
                }
            }
        }

        /// <summary>
        /// Switches the compressor.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        public void SwitchCompressor(bool state)
        {
            ServerCheck.CommandClient.SetCompressorState(state);
        }

        /// <summary>
        /// Activate Manual mode.
        /// </summary>
        public void ManualModus()
        {
            ServerCheck.CommandClient.Manual();
        }

        /// <summary>
        /// Sets the compressor scales.
        /// </summary>
        /// <param name="viewModelContainer">The view model container.</param>
        public void SetCompressorScales(ViewModelContainer viewModelContainer)
        {
            try
            {
                CommandServiceClient commandClient = ServerCheck.CommandClient;
                if (commandClient.State == CommunicationState.Opened && viewModelContainer != null)
                {
                    viewModelContainer.CompressorViewModel.TempScale =
                        commandClient.ReadCompressorTemperatureScale();
                    viewModelContainer.CompressorViewModel.PressureScale =
                        commandClient.ReadCompressorPressureScale();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong with the server");
            }                      
        }

        /// <summary>
        /// Sets the state of the logger.
        /// </summary>
        /// <param name="viewModelContainer">The view model container.</param>
        public void SetLoggerState(ViewModelContainer viewModelContainer)
        {
            try
            {
                CommandServiceClient commandClient = ServerCheck.CommandClient;
                if (commandClient.State == CommunicationState.Opened && viewModelContainer != null)
                {
                    viewModelContainer.LoggingViewModel.LoggingInProgress = ServerCheck.CommandClient.IsLogging();
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong with the server");
            }
        }

        /// <summary>
        /// Cancels the modus.
        /// </summary>
        public void CancelModus()
        {
            ServerCheck.CommandClient.Cancel();
        }

        /// <summary>
        /// Updates the helium.
        /// </summary>
        /// <param name="viewModelContainer">The view model container.</param>
        public void UpdateHelium(ViewModelContainer viewModelContainer)
        {
            try
            {
                ServerCheck.CommandClient.WriteHelium7(
                    (int)HeaterEnumerator.He4Pump,
                    viewModelContainer.He7ViewModel.He4PumpNewVolt);
            }
            catch (FaultException<CouldNotPerformActionFault> e)
            {
                Console.WriteLine("Could not set He4 Pump voltage because " + e.Detail.Message);
            }

            try
            {
                ServerCheck.CommandClient.WriteHelium7(
                    (int)HeaterEnumerator.He3Pump,
                    viewModelContainer.He7ViewModel.He3PumpNewVolt);
            }
            catch (FaultException<CouldNotPerformActionFault> e)
            {
                Console.WriteLine("Could not set He3 Pump voltage because " + e.Detail.Message);
            }

            try
            {
                ServerCheck.CommandClient.WriteHelium7(
                    (int)HeaterEnumerator.He3Switch,
                    viewModelContainer.He7ViewModel.He3SwitchNewVolt);
            }
            catch (FaultException<CouldNotPerformActionFault> e)
            {
                Console.WriteLine("Could not set He3 Switch voltage because " + e.Detail.Message);
            }

            try
            {
                ServerCheck.CommandClient.WriteHelium7(
                    (int)HeaterEnumerator.He4Switch,
                    viewModelContainer.He7ViewModel.He4SwitchNewVolt);
            }
            catch (FaultException<CouldNotPerformActionFault> e)
            {
                Console.WriteLine("Could not set He4 Switch voltage because " + e.Detail.Message);
            }
        }

        #endregion Methods
    }
}