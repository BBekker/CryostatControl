namespace CryostatControlClient
{
    using System;

    using CryostatControlClient.ServiceReference1;

    internal class DataClientCallback : IDataGetCallback
    {
        #region Methods

        public void SendData(float[] data)
        {
            Console.WriteLine("Received: {0}", data[0]);
        }

        #endregion Methods
    }
}