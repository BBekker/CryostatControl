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

    using CryostatControlServer.Data;
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
        private readonly Dictionary<IDataGetCallback, Timer> dataListeners = new Dictionary<IDataGetCallback, Timer>();

        /// <summary>
        /// The update listeners
        /// </summary>
        private readonly List<IDataGetCallback> updateListeners = new List<IDataGetCallback>();

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

        /// <summary>
        /// The read heater power.
        /// </summary>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public double ReadBlueforsHeaterPower()
        {
            return this.cryostatControl.ReadBlueforsHeaterPower();
        }

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

        /// <inheritdoc cref="ICommandService.SetBlueforsHeater"/>>
        public bool SetBlueforsHeater(bool status)
        {
            return this.cryostatControl.SetBlueforsHeater(status);
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
        public void SubscribeForData(int interval)
        {
            IDataGetCallback client =
                OperationContext.Current.GetCallbackChannel<IDataGetCallback>();
            if (!this.dataListeners.ContainsKey(client))
            {
                this.dataListeners.Add(client, new Timer(this.TimerMethod, client, 0, interval));
            }
        }

        /// <inheritdoc cref="IDataGet.UnsubscribeForData"/>>
        public void UnsubscribeForData()
        {
            IDataGetCallback client =
                OperationContext.Current.GetCallbackChannel<IDataGetCallback>();
            if (this.dataListeners.ContainsKey(client))
            {
                Timer timer = this.dataListeners[client];
                timer.Dispose();
                this.dataListeners.Remove(client);
            }
        }

        /// <inheritdoc cref="IDataGet.SubscribeForUpdates"/>>
        public void SubscribeForUpdates()
        {
            IDataGetCallback client =
                OperationContext.Current.GetCallbackChannel<IDataGetCallback>();
            if (!this.updateListeners.Contains(client))
            {
                this.updateListeners.Add(client);
            }
        }

        /// <inheritdoc cref="IDataGet.UnsubscribeForUpdates"/>>
        public void UnsubscribeForUpdates()
        {
            IDataGetCallback client =
                OperationContext.Current.GetCallbackChannel<IDataGetCallback>();
            this.updateListeners.Remove(client);
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
            foreach (IDataGetCallback callback in this.updateListeners.Reverse<IDataGetCallback>())
            {
                Thread thread = new Thread(() => this.UpdateNotification(callback, message));
                thread.Start();
            }
        }

        /// <summary>
        /// Sets the state of the logging to all clients.
        /// </summary>
        /// <param name="status">if set to <c>true</c> [status].</param>
        private void SetLoggingState(bool status)
        {
            foreach (IDataGetCallback callback in this.updateListeners.Reverse<IDataGetCallback>())
            {
                Thread thread = new Thread(() => this.SendLoggingState(callback, status));
                thread.Start();
            }
        }

        /// <summary>
        /// Sends the state of the logging.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="status">if set to <c>true</c> [status].</param>
        private void SendLoggingState(IDataGetCallback callback, bool status)
        {
            try
            {
                callback.SetLoggingState(status);
            }
            catch
            {
                this.updateListeners.Remove(callback);
            }
        }

        /// <summary>
        /// The send log notification.
        /// </summary>
        /// <param name="callback">
        /// The callback.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        private void UpdateNotification(IDataGetCallback callback, string[] message)
        {
            try
            {
                callback.UpdateNotification(message);
            }
            catch
            {
                this.updateListeners.Remove(callback);
            }
        }

        /// <summary>
        /// Timer method to send mock data
        /// </summary>
        /// <param name="state">The state.</param>
        private void TimerMethod(object state)
        {
#if DEBUG
//            Console.WriteLine("sending data to client");
#endif
            IDataGetCallback client = (IDataGetCallback)state;
            double[] data = this.cryostatControl.ReadData();
            try
            {
                client.SendData(data);
                client.SendModus(this.GetState());
            }
            catch
            {
                this.dataListeners.Remove(client);
            }
        }

        #endregion Methods
    }
}