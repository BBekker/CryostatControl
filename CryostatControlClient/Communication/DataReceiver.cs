// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataReceiver.cs" company="SRON">
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
            viewModelContainer.He7ViewModel.He3HeadMax = data[(int)DataEnumerator.He3HeadMax];
            viewModelContainer.He7ViewModel.He3PumpTemp = data[(int)DataEnumerator.He3Pump];
            viewModelContainer.He7ViewModel.He3PumpMax = data[(int)DataEnumerator.He3PumpMax];
            viewModelContainer.He7ViewModel.He4HeadTemp = data[(int)DataEnumerator.He4Head];
            viewModelContainer.He7ViewModel.He4HeadMax = data[(int)DataEnumerator.He4HeadMax];
            viewModelContainer.He7ViewModel.He4PumpTemp = data[(int)DataEnumerator.He4Pump];
            viewModelContainer.He7ViewModel.He4PumpMax = data[(int)DataEnumerator.He4PumpMax];
            viewModelContainer.He7ViewModel.He3PumpActualVolt = data[(int)DataEnumerator.He3VoltActual];
            viewModelContainer.He7ViewModel.He4PumpActualVolt = data[(int)DataEnumerator.He4VoltActual];
            viewModelContainer.He7ViewModel.He3SwitchTemp = data[(int)DataEnumerator.He3SwitchTemp];
            viewModelContainer.He7ViewModel.He3SwitchActualVolt = data[(int)DataEnumerator.He3SwitchVoltActual];
            viewModelContainer.He7ViewModel.He3SwitchMax1 = data[(int)DataEnumerator.He3SwitchMax1];
            viewModelContainer.He7ViewModel.He3SwitchMax2 = data[(int)DataEnumerator.He3SwitchMax2];
            viewModelContainer.He7ViewModel.He4SwitchTemp = data[(int)DataEnumerator.He4SwitchTemp];
            viewModelContainer.He7ViewModel.He4SwitchActualVolt = data[(int)DataEnumerator.He4SwitchVoltActual];
            viewModelContainer.He7ViewModel.He4SwitchMax1 = data[(int)DataEnumerator.He4SwitchMax1];
            viewModelContainer.He7ViewModel.He4SwitchMax2 = data[(int)DataEnumerator.He4SwitchMax2];
            viewModelContainer.He7ViewModel.TwoKPlateTemp = data[(int)DataEnumerator.HePlate2K];
            viewModelContainer.He7ViewModel.FourKPlateTemp = data[(int)DataEnumerator.HePlate4K];
            viewModelContainer.He7ViewModel.FourKPlateMax1 = data[(int)DataEnumerator.HePlate4Kmax1];
            viewModelContainer.He7ViewModel.FourKPlateMax2 = data[(int)DataEnumerator.HePlate4Kmax2];
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
            viewModelContainer.BlueforsViewModel.HeaterPower = data[(int)DataEnumerator.LakeHeater];
        }

        #endregion Methods
    }
}