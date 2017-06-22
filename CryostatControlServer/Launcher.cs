// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Launcher.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer
{
    using System;
    using System.ServiceModel;
    using System.Threading.Tasks;

    using CryostatControlServer.Data;
    using CryostatControlServer.HostService;
    using CryostatControlServer.Logging;

    /// <summary>
    /// Launcher for the server application
    /// </summary>
    public class Launcher
    {
        /// <summary>
        /// The host address for the compressor
        /// </summary>
        private const string CompressorHost = "169.254.16.68";

        /// <summary>
        /// Host address of the helium 7 cooler
        /// </summary>
        private const string CoolerHost = "192.168.1.100";

        /// <summary>
        /// The logger
        /// </summary>
        private static LogThreader logger;

        /// <summary>
        /// The compressor
        /// </summary>
        private static Compressor.Compressor compressor = new Compressor.Compressor();

        /// <summary>
        /// The controller.
        /// </summary>
        private static Controller controller;

        /// <summary>
        /// The cryostat control.
        /// </summary>
        private static CryostatControl cryostatControl;

        /// <summary>
        /// The he7 cooler
        /// </summary>
        private static He7Cooler.He7Cooler he7Cooler = new He7Cooler.He7Cooler();

        /// <summary>
        /// The host.
        /// </summary>
        private static ServiceHost host;

        /// <summary>
        /// The lake shore
        /// </summary>
        private static LakeShore.LakeShore lakeShore = new LakeShore.LakeShore();

        /// <summary>
        /// Initializes the components.
        /// </summary>
        public static void InitComponents()
        {
            var lakeShorePort = LakeShore.LakeShore.FindPort();
            if (lakeShorePort != null)
            {
                new Task(() => { lakeShore.Init(lakeShorePort); }).Start();
            }
            else
            {
                DebugLogger.Error("Launcher", "No connection with LakeShore");
            }

            new Task(
                () =>
                    {
                        try
                        {
                            he7Cooler.Connect(CoolerHost);
                        }
                        catch (Exception)
                        {
                            DebugLogger.Error("Launcher", "No connection with He7 cooler");
                        }
                    }).Start();

            new Task(
                () =>
                    {
                        try
                        {
                            compressor.Connect(CompressorHost);
                        }
                        catch (Exception)
                        {
                            DebugLogger.Error("Launcher", "No connection with Compressor");
                        }
                    }).Start();

            controller = new Controller(he7Cooler, lakeShore, compressor);

            cryostatControl = new CryostatControl(compressor, lakeShore, he7Cooler, controller);
        }

        /// <summary>
        /// Close the server and all connections.
        /// </summary>
        public static void Exit()
        {
            try
            {
                host.Close();
                lakeShore.Close();
                compressor.Disconnect();
                he7Cooler.Disconnect();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Launch the server
        /// </summary>
        public static void Launch()
        {
            InitComponents();
            logger = new LogThreader(new DataReader(compressor, he7Cooler, lakeShore), cryostatControl);
            logger.StartGeneralDataLogging();
            StartHost();
        }

        /// <summary>
        /// Starts the web service.
        /// </summary>
        public static void StartHost()
        {
            CommandService hostService = new CommandService(cryostatControl, logger);
            NotificationSender.Init(hostService);
            host = new ServiceHost(hostService);

            ((ServiceBehaviorAttribute)host.Description.Behaviors[typeof(ServiceBehaviorAttribute)])
                .InstanceContextMode = InstanceContextMode.Single;
            host.Open();
            DebugLogger.Info("Launcher", "The service is ready");
        }
    }
}