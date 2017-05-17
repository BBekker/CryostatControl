//-----------------------------------------------------------------------
// <copyright file="CommandService.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Threading;

    /// <summary>
    /// Service class which handles the incoming methods calls.
    /// </summary>
    /// <seealso cref="CryostatControlServer.HostService.ICommandService" />
    public class CommandService : ICommandService, IDataGet
    {
        #region Fields

        private CryostatControl cryostatControl;

        /// <summary>
        /// The callback list
        /// </summary>
        private Dictionary<IDataGetCallback, Timer> callbacksListeners = new Dictionary<IDataGetCallback, Timer>();

        #endregion Fields

        #region Constructors

        public CommandService()
        {
            this.cryostatControl = new CryostatControl();
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

        /// <inheritdoc cref="ICommandService.ReadSensor"/>>
        public float ReadSensor(int id)
        {
            return 0;
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
            double[] data = this.cryostatControl.fillData();
            client.SendData(data);
        }

        #endregion Methods
    }
}