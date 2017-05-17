//-----------------------------------------------------------------------
// <copyright file="CommandService.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading;

    using CryostatControlServer.Compressor;
    using CryostatControlServer.HostService.Enumerators;

    /// <summary>
    /// Service class which handles the incoming methods calls.
    /// </summary>
    /// <seealso cref="CryostatControlServer.HostService.ICommandService" />
    public class CommandService : ICommandService, IDataGet
    {
        #region Fields

        /// <summary>
        /// The callback list
        /// </summary>
        private ArrayList callbackList = new ArrayList();

        #endregion Fields

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
            if (!this.callbackList.Contains(client))
            {
                this.callbackList.Add(client);
                Timer ticker = new Timer(this.TimerMethod, client, 0, interval);
            }
        }

        /// <inheritdoc cref="IDataGet.UnsubscribeForData"/>>
        public void UnsubscribeForData()
        {
            IDataGetCallback client =
                OperationContext.Current.GetCallbackChannel<IDataGetCallback>();
            if (this.callbackList.Contains(client))
            {
                this.callbackList.Remove(client);
            }
        }

        /// <summary>
        /// Timer method to send mock data
        /// </summary>
        /// <param name="state">The state.</param>
        private void TimerMethod(object state)
        {
            IDataGetCallback client = (IDataGetCallback)state;
            int max = (int)Enum.GetValues(typeof(Helium7Enum)).Cast<Helium7Enum>().Max();
            float[] data = new float[max];
            Random r = new Random();
            data[(int)Helium7Enum.ConnectontionState] = r.Next(100);



            client.SendCompressorData(data);
        }

        #endregion Methods
    }
}