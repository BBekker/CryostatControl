using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryostatControlServer
{
    
    class Program
    {


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
                Agilent34972A H7Cooler = new Agilent34972A();
                H7Cooler.Init("192.168.1.100");
                double[] voltages = H7Cooler.GetVoltages(new int[]
                {
                    Agilent34972A.SENS_HE3PUMP_T,
                    Agilent34972A.SENS_HE4PUMP_T,
                });
                Console.WriteLine($"Voltage H3: {voltages[0]}, voltage H4: {voltages[1]}");
                for(int i = 0; i < 100000; i++)
                {
                    H7Cooler.SetHeaterVoltage(Agilent34972A.PUMP_HE3, Math.Sin((double)i/100.0)+1);
                    H7Cooler.SetDigitalOutput(Agilent34972A.SENS_HE3HEAD_T, true);
                    Thread.Sleep(1000);
                    H7Cooler.SetDigitalOutput(Agilent34972A.SENS_HE3HEAD_T, false);
                    Thread.Sleep(1000);
                }
                
                
            }));
            H7CoolerThread.Start();

            Thread LakeShoreThread = new Thread(new ThreadStart(() =>
            {
                LakeShore ls = new LakeShore();
                ls.init("COM6");
                while (run)
                {
                    double t1 = ls.readTemperature("A");
                    double t2 = ls.readTemperature("B");
                    Console.WriteLine("Temp 1: {0}K, Temp 2: {1}K",t1, t2);
                    Thread.Sleep(1000);
                    
                }
                ls.close();
            }));
            LakeShoreThread.Start();


            Console.In.ReadLine();
            run = false;
            H7CoolerThread.Abort();

        }

            

    }
}
