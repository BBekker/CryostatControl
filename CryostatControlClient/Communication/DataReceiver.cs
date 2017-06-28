// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataReceiver.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Communication
{
    using System;

    using CryostatControlClient.ViewModels;

    using CryostatControlServer.Data;

    /// <summary>
    /// Handles the received data
    /// </summary>
    public class DataReceiver
    {
        #region Methods

        /// <summary>
        /// Sets the state.
        /// </summary>
        /// <param name="modus">The modus.</param>
        /// <param name="dataContext">The data context.</param>
        public void SetState(int modus, ViewModelContainer dataContext)
        {
            if (dataContext != null)
            {
                dataContext.ModusViewModel.Modus = modus;
            }
        }

        /// <summary>
        /// Sets the is logging.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        /// <param name="dataContext">The data context.</param>
        public void SetIsLogging(bool state, ViewModelContainer dataContext)
        {
            if (dataContext != null)
            {
                dataContext.LoggingViewModel.LoggingInProgress = state;
            }
        }

        /// <summary>
        /// Updates the compressor viewmodel.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <param name="dataContext">The data context.</param>
        public void UpdateCountdown(DateTime time, ViewModelContainer dataContext)
        {
            if (dataContext != null)
            {
                dataContext.ModusViewModel.PlannedTime = time;
            }
        }

        /// <summary>
        /// Updates the notification.
        /// </summary>
        /// <param name="notification">
        /// The notification.
        /// </param>
        /// <param name="dataContext">
        /// The viewmodels.
        /// </param>
        public void UpdateNotification(string[] notification, ViewModelContainer dataContext)
        {
            if (dataContext != null)
            {
                dataContext.MessageBoxViewModel.Message = notification;
            }
        }

        /// <summary>
        /// Updates the compressor viewmodel.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="dataContext">The data context.</param>
        public void UpdateViewModels(double[] data, ViewModelContainer dataContext)
        {
            if (dataContext != null)
            {
                this.UpdateHe7ViewModel(data, dataContext);
                this.UpdateBlueforsViewModel(data, dataContext);
                this.UpdateCompressorViewModel(data, dataContext);
            }
        }

        /// <summary>
        /// Updates the he7 view model.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="viewModelContainer">The view model container.</param>
        private void UpdateHe7ViewModel(double[] data, ViewModelContainer viewModelContainer)
        {
            viewModelContainer.He7ViewModel.ConnectionState = data[(int)DataEnumerator.HeConnectionState];
            viewModelContainer.He7ViewModel.He3HeadTemp = data[(int)DataEnumerator.He3Head];
            viewModelContainer.He7ViewModel.He3PumpTemp = data[(int)DataEnumerator.He3Pump];
            viewModelContainer.He7ViewModel.He4HeadTemp = data[(int)DataEnumerator.He4Head];
            viewModelContainer.He7ViewModel.He4PumpTemp = data[(int)DataEnumerator.He4Pump];
            viewModelContainer.He7ViewModel.He3PumpActualVolt = data[(int)DataEnumerator.He3VoltActual];
            viewModelContainer.He7ViewModel.He4PumpActualVolt = data[(int)DataEnumerator.He4VoltActual];
            viewModelContainer.He7ViewModel.He3SwitchTemp = data[(int)DataEnumerator.He3SwitchTemp];
            viewModelContainer.He7ViewModel.He3SwitchActualVolt = data[(int)DataEnumerator.He3SwitchVoltActual];
            viewModelContainer.He7ViewModel.He4SwitchTemp = data[(int)DataEnumerator.He4SwitchTemp];
            viewModelContainer.He7ViewModel.He4SwitchActualVolt = data[(int)DataEnumerator.He4SwitchVoltActual];
            viewModelContainer.He7ViewModel.TwoKPlateTemp = data[(int)DataEnumerator.HePlate2K];
            viewModelContainer.He7ViewModel.FourKPlateTemp = data[(int)DataEnumerator.HePlate4K];
        }

        /// <summary>
        /// Updates the bluefors view model.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="viewModelContainer">The view model container.</param>
        private void UpdateCompressorViewModel(double[] data, ViewModelContainer viewModelContainer)
        {
            viewModelContainer.CompressorViewModel.ConnectionState = data[(int)DataEnumerator.ComConnectionState];
            viewModelContainer.CompressorViewModel.WaterInTemp = data[(int)DataEnumerator.ComWaterIn];
            viewModelContainer.CompressorViewModel.WaterOutTemp = data[(int)DataEnumerator.ComWaterOut];
            viewModelContainer.CompressorViewModel.HeliumTemp = data[(int)DataEnumerator.ComHelium];
            viewModelContainer.CompressorViewModel.OilTemp = data[(int)DataEnumerator.ComOil];
            viewModelContainer.CompressorViewModel.LowPressure = data[(int)DataEnumerator.ComLow];
            viewModelContainer.CompressorViewModel.LowPressureAverage = data[(int)DataEnumerator.ComLowAvg];
            viewModelContainer.CompressorViewModel.HighPressure = data[(int)DataEnumerator.ComHigh];
            viewModelContainer.CompressorViewModel.HighPressureAverage = data[(int)DataEnumerator.ComHighAvg];
            viewModelContainer.CompressorViewModel.DeltaPressureAverage = data[(int)DataEnumerator.ComDeltaAvg];
            viewModelContainer.CompressorViewModel.ErrorState = data[(int)DataEnumerator.ComError];
            viewModelContainer.CompressorViewModel.WarningState = data[(int)DataEnumerator.ComWarning];
            viewModelContainer.CompressorViewModel.HoursOfOperation = data[(int)DataEnumerator.ComHoursOfOperation];
            viewModelContainer.CompressorViewModel.OperatingState = data[(int)DataEnumerator.ComOperationState];
        }

        /// <summary>
        /// Updates the compressor view model.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="viewModelContainer">The view model container.</param>
        private void UpdateBlueforsViewModel(double[] data, ViewModelContainer viewModelContainer)
        {
            viewModelContainer.BlueforsViewModel.ConnectionState = data[(int)DataEnumerator.LakeConnectionState];
            viewModelContainer.BlueforsViewModel.ColdPlate50KTemp = data[(int)DataEnumerator.LakePlate50K];
            viewModelContainer.BlueforsViewModel.ColdPlate3KTemp = data[(int)DataEnumerator.LakePlate3K];
        }

        #endregion Methods
    }
}