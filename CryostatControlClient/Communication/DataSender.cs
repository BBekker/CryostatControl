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

    /// <summary>
    /// Sends data to the server
    /// </summary>
    public class DataSender
    {
        #region Methods

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
        #endregion Methods
    }
}