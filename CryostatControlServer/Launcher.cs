// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Launcher.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlServer
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    using CryostatControlServer.Compressor;
    using CryostatControlServer.HostService;

    /// <summary>
    /// Launcher for the server application
    /// </summary>
    public class Launcher
    {
        #region Fields

        private const string localhost = "127.0.0.1";
        private static Compressor.Compressor compressor;

        private static LakeShore.LakeShore lakeShore;

        private static He7Cooler.He7Cooler he7Cooler;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            //this.lakeShore = new LakeShore.LakeShore();
            //this.he7Cooler = new He7Cooler.He7Cooler();

            //try
            //{
            //    this.lakeShore.Init("COM1");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("No connection with LakeShore");

            //    //todo handle exception
            //}

            //try
            //{
            //    this.he7Cooler.Connect(localhost);
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("No connection with He7");

            //    //todo handle exception
            //}

            try
            {
                compressor = new Compressor.Compressor(localhost);
            }
            catch (Exception)
            {
                Console.WriteLine("No connection with Compressor");

                //todo handle exception
            }

            StartHost();
        }

        private static void StartHost()
        {
            CommandService hostService = new CommandService(compressor, lakeShore, he7Cooler);

            Uri baseAddress = new Uri("http://localhost:8080/SRON");

            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(hostService, baseAddress))
            {
                // Enable metadata publishing.
                ////ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                ////smb.HttpGetEnabled = true;
                ////smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                ////host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.

                ((ServiceBehaviorAttribute)host.Description.Behaviors[typeof(ServiceBehaviorAttribute)])
                    .InstanceContextMode = InstanceContextMode.Single;

                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }

    #endregion Methods
}