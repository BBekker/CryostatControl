using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CryostatControlServer.Compressor
{
    internal class CompressorMain
    {
        #region Fields

        private const String local = "127.0.0.1";
        private const String compressor_address = "169.254.16.68";

        #endregion Fields

        #region Methods

        public static void Main(String[] args)
        {
            Compressor compressor = new Compressor(local);
            Console.WriteLine("dingen1 " + compressor.ReadPressureScale());

            //Console.WriteLine("dingen2 " + compressor.ReadCoolOutTemp());
            //Console.WriteLine("dingen3 " + compressor.ReadOilTemp());
            //Console.WriteLine("dingen4 " + compressor.ReadHeliumTemp());
            Console.Read();
        }

        #endregion Methods
    }
}