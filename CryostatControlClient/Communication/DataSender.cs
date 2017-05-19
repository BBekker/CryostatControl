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

    using CryostatControlClient.ServiceReference1;
    using CryostatControlClient.ViewModels;

    using CryostatControlServer.HostService.Enumerators;

    /// <summary>
    /// Sends data to the server
    /// </summary>
    public class DataSender
    {
        #region Fields

        /// <summary>
        /// The command service client
        /// </summary>
        private CommandServiceClient commandServiceClient;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSender"/> class.
        /// </summary>
        /// <param name="csc">The command service client.</param>
        public DataSender(CommandServiceClient csc)
        {
            this.commandServiceClient = csc;
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
                    this.commandServiceClient.Cooldown();
                    break;
                case (int)ModusEnumerator.Recycle:
                    this.commandServiceClient.Recycle();
                    break;
                case (int)ModusEnumerator.Warmup:
                    this.commandServiceClient.Warmup();
                    break;
                default:
                    // todo : some error for unknown modus?
                    break;
            }
        }

        /// <summary>
        /// Updates the helium.
        /// </summary>
        /// <param name="viewModelContainer">The view model container.</param>
        public void UpdateHelium(ViewModelContainer viewModelContainer)
        {
            //double[] writeSettingValues = new double[(int)SomeEnumerator.Amount];
            double[] writeHelium7 = new double[(int)HeaterEnumerator.HeaterAmount];

            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.He4PumpMax;
            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.He3PumpMax;
            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.He4SwitchMax1;
            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.He4SwitchMax2;
            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.He3SwitchMax1;
            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.He3SwitchMax2;
            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.FourKPlateMax1;
            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.FourKPlateMax2;
            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.He4HeadMax;
            //writeSettingValues[(int)SomeEnumerator.Something] = viewModelContainer.He7ViewModel.He3HeadMax;

            writeHelium7[(int)HeaterEnumerator.He4Pump] = viewModelContainer.He7ViewModel.He4PumpNewVolt;
            writeHelium7[(int)HeaterEnumerator.He3Pump] = viewModelContainer.He7ViewModel.He3PumpNewVolt;
            writeHelium7[(int)HeaterEnumerator.He3Switch] = viewModelContainer.He7ViewModel.He3SwitchNewVolt;
            writeHelium7[(int)HeaterEnumerator.He4Switch] = viewModelContainer.He7ViewModel.He4SwitchNewVolt;

            //this.commandServiceClient.WriteSettingValues(writeSettingValues);
            this.commandServiceClient.WriteHelium7(writeHelium7);
        }

        #endregion Methods
    }
}
