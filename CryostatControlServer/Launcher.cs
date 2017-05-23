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
        private const string CompressorHost = "169.254.16.68";

        /// <summary>
        /// Host address of the helium 7 cooler
        /// </summary>
        private const string CoolerHost = "192.168.1.100";

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
        /// Initializes the components.
        /// </summary>
        private static void InitComponents()
        {
            var lakeShorePort = LakeShore.LakeShore.FindPort();
            if (lakeShorePort != null)
            {
                lakeShore = new LakeShore.LakeShore();
                lakeShore.Init(lakeShorePort);
            }
            else
            {
                Console.WriteLine("No connection with LakeShore");
            }

            try
            {
                he7Cooler = new He7Cooler.He7Cooler();
                he7Cooler.Connect(CoolerHost);
            }
            catch (Exception e)
            {
                Console.WriteLine("No connection with He7 cooler");

#if DEBUG
                Console.WriteLine("Exception thrown: {0}", e);
#endif
                ////todo handle exception
            }

            try
            {
                compressor = new Compressor.Compressor(CompressorHost);
            }
            catch (Exception e)
            {
                Console.WriteLine("No connection with Compressor");

#if DEBUG
                Console.WriteLine("Exception thrown: {0}", e);
#endif
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
            try
            {
                CommandService hostService = new CommandService(cryostatControl);
                Uri baseAddress = new Uri("http://localhost:18080/SRON");
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
            catch (Exception e)
            {
                Console.WriteLine("Error setting up server, did you run this in administrator mode?");
                Console.Write(e.Message);
                Console.ReadLine();
            }
        }
    }

    #endregion Methods
}