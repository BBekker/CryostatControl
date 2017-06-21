﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingsViewModel.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   The settings view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlClient.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    
    using CryostatControlClient.Communication;
    using CryostatControlClient.Models;

    using CryostatControlServer.HostService.Enumerators;

    /// <summary>
    /// The settings view model.
    /// </summary>
    public class SettingsViewModel : AbstractViewModel
    {
        /// <summary>
        /// The is selected.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// The old settings retrieved from the server.
        /// </summary>
        private double[] oldSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
        /// </summary>
        public SettingsViewModel()
        {
            this.Settings = new ObservableCollection<SettingModel>(new SettingModel[] { });
            this.ConfirmSettingsClick = new RelayCommand((obj) => this.SendChanges());
        }

        /// <summary>
        /// Gets the confirm settings click.
        /// </summary>
        public ICommand ConfirmSettingsClick { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the settings tab is selected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                this.isSelected = value;
                if (value)
                {
                    this.UpdateSettingsFromServerAsync();
                }
            }
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        public ObservableCollection<SettingModel> Settings { get; }

        /// <summary>
        /// The get current values.
        /// </summary>
        /// <returns>
        /// The <see cref="double[]"/>.
        /// </returns>
        private double[] GetCurrentValues()
        {
            double[] res = new double[this.Settings.Count];
            for (int i = 0; i < this.Settings.Count; i++)
            {
                res[i] = this.Settings[i].Value;
            }

            return res;
        }

        /// <summary>
        /// Send changes in settings to the server
        /// </summary>
        private void SendChanges()
        {
            ServerCheck.SendMessage(new Task(() => { this.WriteSettings(); }));
        }

        /// <summary>
        /// Write the settings to the server.
        /// </summary>
        private void WriteSettings()
        {
            var newSettings = this.GetCurrentValues();
            for (int i = 0; i < newSettings.Length; i++)
            {
                if (Math.Abs(newSettings[i] - this.oldSettings[i]) > 0.01)
                {
                    ServerCheck.CommandClient.WriteSettingValue(i, newSettings[i]);
                }
            }
        }

        /// <summary>
        /// Update the displayed settings
        /// </summary>
        /// <param name="settingValues">
        /// The setting values.
        /// </param>
        private void UpdateSettings(double[] settingValues)
        {
            this.oldSettings = settingValues;
            this.Settings.Clear();
            for (int i = 0; i < settingValues.Length; i++)
            {
                this.Settings.Add(
                    new SettingModel(
                        i,
                        settingValues[i],
                        SettingEnumeratorDescription.DescriptionStrings[i],
                        SettingEnumeratorDescription.UnitStrings[i]));
            }
        }

        /// <summary>
        /// The update settings from server async.
        /// </summary>
        private void UpdateSettingsFromServerAsync()
        {
            ServerCheck.SendMessage(new Task(() => { ReadSettings(); }));
        }

        /// <summary>
        /// Read the settings from the server.
        /// </summary>
        private void ReadSettings()
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                double[] settings = ServerCheck.CommandClient.ReadSettings();
                this.UpdateSettings(settings);
            });
        }
    }
}