using CryostatControlServer.Streams;
using System;
using System.Threading;

namespace CryostatControlServer
{
    /// <summary>
    /// Connection and comunication to the LakeShore 355 temperature controller.
    /// </summary>
    internal class LakeShore
    {
        #region const values

        private const string COLDPLATE_3K = "A";
        private const string COLDPLATE_5K = "B";

        #endregion const values

        private DateTime _lastCommand;

        private readonly ManagedStream _ms = new ManagedStream();

        /// <summary>
        /// Initializes by connecting to the specified portname.
        /// </summary>
        /// <param name="portname">The portname.</param>
        public void init(string portname)
        {
            _ms.ConnectCOM(portname, 57600);

            _lastCommand = DateTime.Now;

            _ms.WriteString("MODE 1\n");
            OPC();
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void close()
        {
            _ms.Close();
        }

        /// <summary>
        /// Reads the sensor temperature in Kelvin.
        /// </summary>
        /// <param name="sensor">The sensor.</param>
        /// <returns>sensor temperature in K</returns>
        public double readTemperature(string sensor)
        {
            WaitCommandInterval();
            _ms.WriteString($"KRDG? {sensor}\n");
            string response = _ms.ReadString();
            return double.Parse(response);
        }

        /// <summary>
        /// Sends OPC command to device and waits for response.
        /// Used to confirm connection and synchronisation of state of the device.
        /// </summary>
        public void OPC()
        {
            WaitCommandInterval();
            _ms.WriteString("OPC?\n");
            _ms.ReadString();
        }

        /// <summary>
        /// Wait until the specified minimum time between commands is passed.
        /// The lakeshore355 manual specifies a minimum time of 50ms between commands.
        /// </summary>
        private void WaitCommandInterval()
        {
            while (DateTime.Now - _lastCommand < TimeSpan.FromMilliseconds(50))
            {
                Thread.Sleep(DateTime.Now - _lastCommand);
            }
        }
    }
}