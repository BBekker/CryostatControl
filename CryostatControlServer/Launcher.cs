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

    using CryostatControlServer.HostService;

    /// <summary>
    /// Launcher for the server application
    /// </summary>
    public class Launcher
    {
        #region Methods

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8080/SRON");

            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(CommandService), baseAddress))
            {
                // Enable metadata publishing.
                //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                //smb.HttpGetEnabled = true;
                //smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                //host.Description.Behaviors.Add(smb);

                // Open the ServiceHost to start listening for messages. Since
                // no endpoints are explicitly configured, the runtime will create
                // one endpoint per base address for each service contract implemented
                // by the service.
                host.Open();

                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }

        #endregion Methods
    }
}