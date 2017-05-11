﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryostatControlServer
{
    using System.Runtime.InteropServices;
    using System.Xml;

    using CryostatControlServer.He7Cooler;

    class Program
    {

        private const string RUOXFile = "..\\..\\RUOX.CAL";

        private const int H3Col = 2;

        private const int H4Col = 3;

        private const string DIODEFile = "..\\..\\DIODE.CAL";

        private He7Cooler.He7Cooler.Sensor.Calibration He3Calibration = new He7Cooler.He7Cooler.Sensor.Calibration(RUOXFile, H3Col, 0);
        private He7Cooler.He7Cooler.Sensor.Calibration He4Calibration = new He7Cooler.He7Cooler.Sensor.Calibration(RUOXFile, H4Col, 0);
        private He7Cooler.He7Cooler.Sensor.Calibration DiodeCalibration = new He7Cooler.He7Cooler.Sensor.Calibration(DIODEFile, 1, 0);
        private He7Cooler.He7Cooler.Sensor.Calibration EmptyCalibration = new He7Cooler.He7Cooler.Sensor.Calibration();


        private bool run = true;

        static void Main(string[] args)
        {
            new Program();
        }

        Program()
        {
            
            Console.Out.WriteLine("Press enter to start...");
            Console.In.ReadLine();


//            H7 cooler test thread
            Thread H7CoolerThread = new Thread(new ThreadStart(() =>
            {
                

                He7Cooler.He7Cooler cooler = new He7Cooler.He7Cooler();
                
                var He3PumpT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3PumpT, cooler, this.DiodeCalibration);

                var He4PumpT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4PumpT, cooler, this.DiodeCalibration);

                var He4SwitchT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4SwitchT, cooler, this.DiodeCalibration);

                var He3SwitchT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3SwitchT, cooler, this.DiodeCalibration);

                var Plate4KT = new He7Cooler.He7Cooler.Sensor(Channels.Sens4KplateT, cooler, this.DiodeCalibration);

                var Plate2KT = new He7Cooler.He7Cooler.Sensor(Channels.Sens2KplateT, cooler, this.DiodeCalibration);

                var He4HeadT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4HeadT, cooler, this.He4Calibration);

                var He3HeadT = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3HeadT, cooler, this.He3Calibration);

                var He3PumpV = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3Pump, cooler, this.EmptyCalibration);

                var He4PumpV = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4Pump, cooler, this.EmptyCalibration);

                var He4SwitchV = new He7Cooler.He7Cooler.Sensor(Channels.SensHe4Switch, cooler, this.EmptyCalibration);

                var He3SwitchV = new He7Cooler.He7Cooler.Sensor(Channels.SensHe3Switch, cooler, this.EmptyCalibration);
                cooler.Connect("192.168.1.100");

                while (1)
                {
                    Console.WriteLine("HE3plate {0}K, He4Plate: {1}K", He3HeadT.Value, He4HeadT.Value);
                }
               


            }));
            H7CoolerThread.Start();

            Thread LakeShoreThread = new Thread(new ThreadStart(() =>
            {
                LakeShore ls = new LakeShore();
                ls.Init("COM6");
                while (run)
                {
                    double t1 = ls.ReadTemperature("A");
                    double t2 = ls.ReadTemperature("B");
                    Console.WriteLine("Temp 1: {0}K, Temp 2: {1}K",t1, t2);
                    Thread.Sleep(1000);
                    
                }
                ls.Close();
            }));
            LakeShoreThread.Start();


            Console.In.ReadLine();
            run = false;
            H7CoolerThread.Abort();

        }

            

    }
}
