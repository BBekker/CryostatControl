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

        Agilent34972A H7Cooler = new Agilent34972A();

        static void Main(string[] args)
        {
            new Program();
        }

        Program()
        {
            Console.Out.WriteLine("Press enter to start...");
            Console.In.ReadLine();


            //H7 cooler test thread
            Thread H7CoolerThread = new Thread(new ThreadStart(() =>
            {
                    H7Cooler.init("192.168.1.100");
                double[] voltages = H7Cooler.GetVoltages(new int[]
                {
                    Agilent34972A.SENS_HE3PUMP_T,
                    Agilent34972A.SENS_HE4PUMP_T,
                }, 2);
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
            Console.In.ReadLine();
            H7CoolerThread.Abort();
        }

            

    }
}
