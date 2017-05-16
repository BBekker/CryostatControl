namespace CryostatControlClient
{
    using System;
    using System.Windows;

    using CryostatControlClient.ServiceReference1;

    public class DataClientCallback : IDataGetCallback
    {
        #region Fields

        private App MainApp;

        #endregion Fields

        #region Constructors

        public DataClientCallback(App app)
        {
            this.MainApp = app;
        }

        #endregion Constructors

        #region Methods

        public void SendBlueForsData(float[] data)
        {
            Console.WriteLine("Received BlueFors: {0}", data[0]);
        }

        public void SendCompressorData(float[] data)
        {
            Console.WriteLine("Received Compressor: {0}", data[0]);
        }

        public void SendHelium7Data(float[] data)
        {
            Console.WriteLine("Received Helium 7: {0}", data[0]);
        }

        #endregion Methods
    }
}