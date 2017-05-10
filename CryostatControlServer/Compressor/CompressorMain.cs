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
        private const String compressorAddress = "169.254.16.68";

        private static Compressor CompressorUnit;

        #endregion Fields

        #region Methods

        public static void TestTemperatures()
        {
            Console.WriteLine("---Reading Temperatures---");
            TemperatureEnum temp = CompressorUnit.ReadTemperatureScale();
            Console.WriteLine("Water in temp = {0} {1}", CompressorUnit.ReadCoolInTemp(), temp);
            Console.WriteLine("Water out temp = {0} {1}", CompressorUnit.ReadCoolOutTemp(), temp);
            Console.WriteLine("Oil temp = {0} {1}", CompressorUnit.ReadOilTemp(), temp);
            Console.WriteLine("Helium temp = {0} {1}", CompressorUnit.ReadHeliumTemp(), temp);
            Console.WriteLine("---Temperatures read---");
        }

        public static void TestPressure()
        {
            Console.WriteLine("---Reading Pressures---");
            PressureEnum pressure = CompressorUnit.ReadPressureScale();
            Console.WriteLine("Low pressure = {0} {1}", CompressorUnit.ReadLowPressure(), pressure);
            Console.WriteLine("Low pressure average = {0} {1}", CompressorUnit.ReadLowPressureAverage(), pressure);
            Console.WriteLine("High pressure = {0} {1}", CompressorUnit.ReadHighPressure(), pressure);
            Console.WriteLine("High pressure average = {0} {1}", CompressorUnit.ReadHighPressureAverage(), pressure);
            Console.WriteLine("Delta pressure average = {0} {1}", CompressorUnit.ReadDeltaPressureAverage(), pressure);
            Console.WriteLine("--- Pressueres read---");
        }

        public static void TestStatus()
        {
            Console.WriteLine("---Reading states---");
            Console.WriteLine("Operating state = {0}", CompressorUnit.ReadOperatingState());
            Console.WriteLine("Energy state = {0}", CompressorUnit.ReadEnergyState());
            Console.WriteLine("Warning state = {0}", CompressorUnit.ReadWarningState());
            Console.WriteLine("Error state = {0}", CompressorUnit.ReadErrorState());
            Console.WriteLine("States read");
        }

        public static void TestMisc()
        {
            Console.WriteLine("---Reading misc---");
            Console.WriteLine("Motor current = {0}", CompressorUnit.ReadMotorCurrent());
            Console.WriteLine("Hours of Operation = {0}", CompressorUnit.ReadHoursOfOperation());
            Console.WriteLine("Panel serial number = {0}", CompressorUnit.ReadPanelSerialNumber());
            Console.WriteLine("Model = {0} {1}", CompressorUnit.ReadModel()[0], CompressorUnit.ReadModel()[1]);
            Console.WriteLine("Misc read");
        }

        public static void Main(String[] args)
        {
            CompressorUnit = new Compressor(local);
            TestStatus();
            TestTemperatures();
            TestPressure();
            TestMisc();
            Console.Read();
        }

        #endregion Methods
    }
}