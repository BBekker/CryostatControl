﻿//-----------------------------------------------------------------------
// <copyright file="CommandService.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading;

    using CryostatControlServer.HostService.Enumerators;

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
        /// The callback list
        /// </summary>
        private readonly Dictionary<IDataGetCallback, Timer> callbacksListeners = new Dictionary<IDataGetCallback, Timer>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandService"/> class.
        /// </summary>
        /// <param name="compressor">The compressor.</param>
        /// <param name="lakeShore">The lake shore.</param>
        /// <param name="he7Cooler">The he7 cooler.</param>
        public CommandService(
            Compressor.Compressor compressor,
            LakeShore.LakeShore lakeShore,
            He7Cooler.He7Cooler he7Cooler)
        {
            this.cryostatControl = new CryostatControl(compressor, lakeShore, he7Cooler);
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
            return false;
        }

        /// <inheritdoc cref="ICommandService.Recycle"/>>
        public bool Recycle()
        {
            return false;
        }

        /// <inheritdoc cref="ICommandService.Warmup"/>>
        public bool Warmup()
        {
            return false;
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

        /// <inheritdoc cref="ICommandService.WriteSettingValues"/>>
        public bool WriteSettingValues(double[] values)
        {
            throw new NotImplementedException();
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
            Console.WriteLine("sending data to client");
            IDataGetCallback client = (IDataGetCallback)state;
            double[] data = this.cryostatControl.ReadData();
            try
            {
                client.SendData(data);
            }
            catch (TimeoutException)
            {
                this.callbacksListeners.Remove(client);
            }
        }

        #endregion Methods
    }
}