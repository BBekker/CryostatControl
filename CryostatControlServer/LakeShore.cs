using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CryostatControlServer.Streams;

namespace CryostatControlServer
{
    class LakeShore
    {

        #region const values

        private const string INPUT_A = "A";
        private const string INPUT_B = "B";

        #endregion

        private DateTime _lastCommand;

        private ManagedStream ms = new ManagedStream();

        public void init(string portname)
        {
            ms.ConnectCOM(portname, 57600);

            _lastCommand = DateTime.Now;

            ms.WriteString("MODE 1\n");
            OPC();
        }

        public void close()
        {
            ms.close();
        }

        public double readTemperature(string sensor)
        {
            WaitCommandInterval();
            ms.WriteString($"KRDG? {sensor}\n");
            string response = ms.ReadString();
            return double.Parse(response);
        }

        public void OPC()
        {
            WaitCommandInterval();
            ms.WriteString("OPC?\n");
            ms.ReadString();
        }

        private void WaitCommandInterval()
        {
            while (DateTime.Now - _lastCommand < TimeSpan.FromMilliseconds(50))
            {
                Thread.Sleep(DateTime.Now - _lastCommand);
            }
        }

    }
}
