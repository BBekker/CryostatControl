// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Launcher.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer
{
    using System;
    using System.IO.Ports;
    using System.ServiceModel;
    using CryostatControlServer.HostService;

    /// <summary>
    /// Launcher for the server application
    /// </summary>
    public class Launcher
    {
        #region Fields

        /// <summary>
        /// The host address for the compressor
        /// </summary>
        private const string CompressorHost = "127.0.0.1";

        /// <summary>
        /// The host address
        /// </summary>
        private const string HostAddress = "http://localhost:8080/SRON";

        /// <summary>
        /// The compressor
        /// </summary>
        private static Compressor.Compressor compressor;

        /// <summary>
        /// The lake shore
        /// </summary>
        private static LakeShore.LakeShore lakeShore;

        /// <summary>
        /// The he7 cooler
        /// </summary>
        private static He7Cooler.He7Cooler he7Cooler;

        /// <summary>
        /// The cryostat control.
        /// </summary>
        private static CryostatControl cryostatControl;

        /// <summary>
        /// The controller.
        /// </summary>
        private static Controller controller;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            InitComponents();
            StartHost();
        }

        /// <summary>
        /// Find the lakeshore com port and connect
        /// </summary>
        /// <returns>
        /// The <see cref="LakeShore"/>.
        /// </returns>
        private static LakeShore.LakeShore FindLakeshore()
        {
            string[] names = SerialPort.GetPortNames();
            LakeShore.LakeShore newLakeShore = new LakeShore.LakeShore();
            foreach (string name in names)
            {
                try
                {
                    newLakeShore.Init(name);
                    return newLakeShore;
                }
                catch (Exception)
                {
                    //ignore this exception and try new port
                }
            }
            return null;
        }


        /// <summary>
        /// Initializes the components.
        /// </summary>
        private static void InitComponents()
        {
            
            lakeShore = FindLakeshore();

            if (lakeShore == null)
            {
                Console.WriteLine("No connection with LakeShore");
            }
                
            try
            {
                he7Cooler = new He7Cooler.He7Cooler();
                he7Cooler.Connect(CompressorHost);
            }
            catch (Exception)
            {
                Console.WriteLine("No connection with He7");

                ////todo handle exception
            }

            try
            {
                compressor = new Compressor.Compressor(CompressorHost);
            }
            catch (Exception)
            {
                Console.WriteLine("No connection with Compressor");

                ////todo handle exception
            }

            controller = new Controller(he7Cooler, lakeShore, compressor);

            cryostatControl = new CryostatControl(compressor, lakeShore, he7Cooler, controller);
        }

        /// <summary>
        /// Starts the web service.
        /// </summary>
        private static void StartHost()
        {
            CommandService hostService = new CommandService(cryostatControl);
            Uri baseAddress = new Uri("http://localhost:8080/SRON");
            using (ServiceHost host = new ServiceHost(hostService, baseAddress))
            {
                // Enable metadata publishing.
                ////ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                ////smb.HttpGetEnabled = true;
                ////smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                ////host.Description.Behaviors.Add(smb);
                ((ServiceBehaviorAttribute)host.Description.Behaviors[typeof(ServiceBehaviorAttribute)])
                    .InstanceContextMode = InstanceContextMode.Single;
                host.Open();
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
                host.Close();
            }
        }
    }

    #endregion Methods
}