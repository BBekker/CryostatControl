//-----------------------------------------------------------------------
// <copyright file="CommandService.cs" company="SRON">
//     Copyright (c) 2017 SRON
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

    using CryostatControlServer.HostService.DataContracts;
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

        /// <summary>
        /// The logger
        /// </summary>
        private readonly LogThreader logger;

        /// <summary>
        /// The callback list
        /// </summary>
        private readonly Dictionary<string, Timer> dataListeners = new Dictionary<string, Timer>();

        /// <summary>
        /// The update listeners
        /// </summary>
        private readonly Dictionary<string, IDataGetCallback> updateListeners = new Dictionary<string, IDataGetCallback>();

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
        public bool CooldownTime(DateTime time)
        {
            return this.cryostatControl.StartCooldown(time);
        }

        /// <inheritdoc cref="ICommandService.Recycle"/>>
        public bool Recycle()
        {
            return this.cryostatControl.StartRecycle();
        }

        /// <inheritdoc cref="ICommandService.Recycle"/>>
        public bool RecycleTime(DateTime time)
        {
            return this.cryostatControl.StartRecycle(time);
        }

        /// <inheritdoc cref="ICommandService.Warmup"/>>
        public bool Warmup()
        {
            return this.cryostatControl.StartHeatup();
        }

        /// <inheritdoc cref="ICommandService.Warmup"/>>
        public bool WarmupTime(DateTime time)
        {
            return this.cryostatControl.StartHeatup(time);
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

        /// <inheritdoc cref="ICommandService.Stop"/>
        public bool Stop()
        {
            this.cryostatControl.StopCommand();
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

        /// <inheritdoc cref="ICommandService.GetStartTime"/>
        public DateTime GetStartTime()
        {
            return this.cryostatControl.StartTime;
        }

        /// <inheritdoc cref="ICommandService.GetValue"/>
        public double GetValue(string sensor)
        {
            try
            {
                int sensorId = int.Parse(sensor);
                return this.cryostatControl.ReadSingleSensor(sensorId);
            }
            catch (Exception e)
            {
                throw new FaultException(e.GetType().ToString());
            }
        }

        /// <inheritdoc cref="ICommandService.SetCompressorState"/>
        public bool SetCompressorState(bool status)
        {
            return this.cryostatControl.SetCompressorState(status);
        }

        /// <inheritdoc cref="ICommandService.WriteHelium7"/>
        public bool WriteHelium7(int heater, double value)
        {
            try
            {
                if (this.cryostatControl.WriteHelium7Heater((HeaterEnumerator)heater, value))
                {
                    return true;
                }
                else
                {
                    throw new FaultException<CouldNotPerformActionFault>(
                        new CouldNotPerformActionFault(ActionFaultReason.NotInManualMode, "Not in manual mode"));
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new FaultException<CouldNotPerformActionFault>(
                    new CouldNotPerformActionFault(ActionFaultReason.InvalidValue, ex.Message));
            }
            catch (Exception e)
            {
                throw new FaultException<CouldNotPerformActionFault>(
                    new CouldNotPerformActionFault(ActionFaultReason.Unknown, e.GetType().ToString()));
            }  
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

        /// <inheritdoc cref="ICommandService.ReadSingleSensor"/>>
        public double ReadSingleSensor(int sensorId)
        {
            return this.cryostatControl.ReadSingleSensor(sensorId);
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
            this.SetLoggingState(true);
        }

        /// <inheritdoc cref="ICommandService.CancelLogging"/>
        public void CancelLogging()
        {
            this.logger.StopSpecificDataLogging();
            this.SetLoggingState(false);
        }

        /// <inheritdoc cref="IDataGet.SubscribeForData"/>>
        public void SubscribeForData(int interval, string key)
        {
            if (!this.dataListeners.ContainsKey(key))
            {
                IDataGetCallback client =
                    OperationContext.Current.GetCallbackChannel<IDataGetCallback>();
                TimerPackage package = new TimerPackage(key, client, interval);
                this.dataListeners.Add(key, new Timer(this.TimerMethod, package, 0, Timeout.Infinite));
            }
        }

        /// <inheritdoc cref="IDataGet.UnsubscribeForData"/>>
        public void UnsubscribeForData(string key)
        {
            if (this.dataListeners.ContainsKey(key))
            {
                Timer timer = this.dataListeners[key];
                timer.Dispose();
                this.dataListeners.Remove(key);
            }
        }

        /// <inheritdoc cref="IDataGet.SubscribeForUpdates"/>>
        public void SubscribeForUpdates(string key)
        {
            IDataGetCallback client =
                OperationContext.Current.GetCallbackChannel<IDataGetCallback>();
            if (!this.updateListeners.ContainsKey(key))
            {
                this.updateListeners.Add(key, client);
            }
        }

        /// <inheritdoc cref="IDataGet.UnsubscribeForUpdates"/>>
        public void UnsubscribeForUpdates(string key)
        {
            this.updateListeners.Remove(key);
        }

        /// <inheritdoc cref="ICommandService.IsLogging"/>>
        public bool IsLogging()
        {
            return this.logger.GetSpecificLoggingInProgress();
        }

        /// <summary>
        /// The send log notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void UpdateNotification(string[] message)
        {
            foreach (KeyValuePair<string, IDataGetCallback> callback in this.updateListeners)
            {
                Thread thread = new Thread(() => this.UpdateNotification(callback.Key, callback.Value, message));
                thread.Start();
            }
        }

        /// <summary>
        /// Determines whether [is registered for data] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if [is registered for data] [the specified key]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsRegisteredForData(string key)
        {
            return this.dataListeners.ContainsKey(key);
        }

        /// <summary>
        /// Determines whether [is registered for updates] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if [is registered for updates] [the specified key]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsRegisteredForUpdates(string key)
        {
            return this.updateListeners.ContainsKey(key);
        }

        /// <summary>
        /// Sets the state of the logging to all clients.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [status].</param>
        private void SetLoggingState(bool status)
        {
            foreach (KeyValuePair<string, IDataGetCallback> callback in this.updateListeners)
            {
                Thread thread = new Thread(() => this.SendLoggingState(callback.Key, callback.Value, status));
                thread.Start();
            }
        }

        /// <summary>
        /// Sends the state of the logging.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="status">if set to <c>true</c> [status].</param>
        private void SendLoggingState(string key, IDataGetCallback callback, bool status)
        {
            try
            {
                callback.SetLoggingState(status);
            }
            catch
            {
                this.updateListeners.Remove(key);
            }
        }

        /// <summary>
        /// The send log notification.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="message">The message.</param>
        private void UpdateNotification(string key, IDataGetCallback callback, string[] message)
        {
            try
            {
                callback.UpdateNotification(message);
            }
            catch
            {
                this.updateListeners.Remove(key);
            }
        }

        /// <summary>
        /// Timer method to sent update data to the clients
        /// </summary>
        /// <param name="state">State should contain TimerPackage</param>
        private void TimerMethod(object state)
        {
            TimerPackage package = (TimerPackage)state;
            IDataGetCallback client = package.Callback;
            double[] data = this.cryostatControl.ReadData();
            try
            {
                Timer timer = this.dataListeners[package.Key];
                client.SendData(data);
                client.SendModus(this.GetState());
                client.UpdateCountdown(this.cryostatControl.StartTime);
                timer.Change(package.WaitTime, Timeout.Infinite);
            }
            catch
            {
                if (this.dataListeners.ContainsKey(package.Key))
                {
                    Timer timer = this.dataListeners[package.Key];
                    this.dataListeners.Remove(package.Key);
                    timer.Dispose();
                }
            }
        }

        #endregion Methods
    }
}