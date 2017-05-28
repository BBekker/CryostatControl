//-----------------------------------------------------------------------
// <copyright file="CommandService.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading;

    using CryostatControlServer.HostService.Enumerators;
    using CryostatControlServer.Logging;

    /// <summary>
    /// Service class which handles the incoming methods calls.
    /// </summary>
    /// <seealso cref="CryostatControlServer.HostService.ICommandService" />
    public class CommandService : ICommandService, IDataGet
    {
        #region Fields

        /// <summary>
        /// The cryostat control
        /// </summary>
        private readonly CryostatControl cryostatControl;

        private readonly LogThreader logger;

        /// <summary>
        /// The callback list
        /// </summary>
        private readonly Dictionary<IDataGetCallback, Timer> callbacksListeners = new Dictionary<IDataGetCallback, Timer>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandService" /> class.
        /// </summary>
        /// <param name="cryostatControl">The cryostat Control.</param>
        /// <param name="logger">The logger.</param>
        public CommandService(CryostatControl cryostatControl, LogThreader logger)
        {
            this.cryostatControl = cryostatControl;
            this.logger = logger;
        }

        #endregion Constructors

        #region Methods

        /// <inheritdoc cref="ICommandService.IsAlive"/>
        public bool IsAlive()
        {
            return true;
        }

        /// <inheritdoc cref="ICommandService.Cooldown"/>>
        public bool Cooldown()
        {
            return this.cryostatControl.StartCooldown();
        }

        /// <inheritdoc cref="ICommandService.Cooldown"/>>
        public bool CooldownTime(string time)
        {
            return this.cryostatControl.StartCooldown(time);
        }

        /// <inheritdoc cref="ICommandService.Recycle"/>>
        public bool Recycle()
        {
            return this.cryostatControl.StartRecycle();
        }

        /// <inheritdoc cref="ICommandService.Warmup"/>>
        public bool Warmup()
        {
            return this.cryostatControl.StartHeatup();
        }

        /// <inheritdoc cref="ICommandService.Manual"/>
        public bool Manual()
        {
            return this.cryostatControl.StartManualControl();
        }

        /// <summary>
        /// Cancel the controller action
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Cancel()
        {
            this.cryostatControl.CancelCommand();
            return true;
        }

        /// <summary>
        /// Get the controller state
        /// </summary>
        /// <returns>
        /// The controller state <see cref="int"/>.
        /// </returns>
        public int GetState()
        {
            return (int)this.cryostatControl.ControllerState;
        }

        /// <inheritdoc cref="ICommandService.SetCompressorState"/>
        public bool SetCompressorState(bool status)
        {
            return this.cryostatControl.SetCompressorState(status);
        }

        /// <inheritdoc cref="ICommandService.WriteHelium7"/>
        public bool WriteHelium7(double[] data)
        {
            return data.Length == (int)HeaterEnumerator.HeaterAmount && this.cryostatControl.WriteHelium7Heaters(data);
        }

        /// <inheritdoc cref="ICommandService.ReadCompressorTemperatureScale"/>>
        public double ReadCompressorTemperatureScale()
        {
            return this.cryostatControl.ReadCompressorTemperatureScale();
        }

        /// <inheritdoc cref="ICommandService.ReadCompressorPressureScale"/>>
        public double ReadCompressorPressureScale()
        {
            return this.cryostatControl.ReadCompressorPressureScale();
        }

        /// <inheritdoc cref="ICommandService.SetBlueforsHeater"/>>
        public bool SetBlueforsHeater(bool status)
        {
            return this.cryostatControl.SetBlueforsHeater(status);
        }

        /// <inheritdoc cref="ICommandService.WriteSettingValues"/>>
        public bool WriteSettingValue(int setting, double value)
        {
            SettingEnumerator settingEnum = (SettingEnumerator)setting;

            foreach (SettingsProperty prop in Properties.Settings.Default.Properties)
            {
                if (prop.Name == settingEnum.ToString())
                {
                    Properties.Settings.Default[prop.Name] = value;
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc cref="ICommandService.ReadSettings"/>
        public double[] ReadSettings()
        {
            var settings = Enum.GetValues(typeof(SettingEnumerator)).Cast<SettingEnumerator>();

            var values = new double[settings.ToArray().Length];
            foreach (SettingEnumerator setting in settings)
            {
                foreach (SettingsProperty prop in Properties.Settings.Default.Properties)
                {
                    if (prop.Name == setting.ToString())
                    {
                        values[(int)setting] = (double)Properties.Settings.Default[setting.ToString()];
                    }
                }
            }

            return values;
        }

        /// <inheritdoc cref="ICommandService.StartLogging"/>
        public void StartLogging(int interval, bool[] logData)
        {
            this.logger.StartSpecificDataLogging(interval, logData);
        }

        /// <inheritdoc cref="ICommandService.StopLogging"/>
        public void StopLogging()
        {
            this.logger.StopSpecificDataLogging();
        }

        /// <inheritdoc cref="IDataGet.SubscribeForData"/>>
        public void SubscribeForData(int interval)
        {
            IDataGetCallback client =
                OperationContext.Current.GetCallbackChannel<IDataGetCallback>();
            if (!this.callbacksListeners.ContainsKey(client))
            {
                this.callbacksListeners.Add(client, new Timer(this.TimerMethod, client, 0, interval));
            }
        }

        /// <inheritdoc cref="IDataGet.UnsubscribeForData"/>>
        public void UnsubscribeForData()
        {
            IDataGetCallback client =
                OperationContext.Current.GetCallbackChannel<IDataGetCallback>();
            if (this.callbacksListeners.ContainsKey(client))
            {
                Timer timer = this.callbacksListeners[client];
                timer.Dispose();
                this.callbacksListeners.Remove(client);
            }
        }

        /// <summary>
        /// Timer method to send mock data
        /// </summary>
        /// <param name="state">The state.</param>
        private void TimerMethod(object state)
        {
#if DEBUG
            Console.WriteLine("sending data to client");
#endif
            IDataGetCallback client = (IDataGetCallback)state;
            double[] data = this.cryostatControl.ReadData();
            try
            {
                client.SendData(data);
                client.SendModus(this.GetState());
            }
            catch (TimeoutException)
            {
                this.callbacksListeners.Remove(client);
            }
        }

        #endregion Methods
    }
}