// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerCheck.cs" company="SRON">
// k
// </copyright>
// <summary>
//   Has the hearthbeat to check the server connection
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Communication
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.ServiceModel;
    using System.Threading;

    using CryostatControlClient.ServiceReference1;
    using CryostatControlClient.ViewModels;
    using CryostatControlClient.Views;

    /// <summary>
    /// Class which checks continuously the connection with the server
    /// </summary>
    public class ServerCheck
    {
        /// <summary>
        /// The wait time
        /// </summary>
        private const int WaitTime = 500;

        /// <summary>
        /// The check interval
        /// </summary>
        private const int CheckInterval = 1000;

        /// <summary>
        /// The subscribe interval
        /// </summary>
        private const int SubscribeInterval = 1000;

        /// <summary>
        /// The callback client
        /// </summary>
        private DataGetClient callbackClient;

        /// <summary>
        /// The command client
        /// </summary>
        private CommandServiceClient commandClient;

        /// <summary>
        /// The first time connected
        /// </summary>
        private bool firstTimeConnected = false;

        /// <summary>
        /// The main application
        /// </summary>
        private App mainApp;

        /// <summary>
        /// The main window
        /// </summary>
        private MainWindow mainWindow;

        /// <summary>
        /// The sender
        /// </summary>
        private DataSender sender;

        /// <summary>
        /// The timer
        /// </summary>
        private Timer timer;

        /// <summary>
        /// The ip address
        /// </summary>
        private string ipAddress = string.Empty;

        /// <summary>
        /// The key
        /// </summary>
        private string key;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerCheck" /> class.
        /// </summary>
        /// <param name="app">The application.</param>
        public ServerCheck(App app)
        {
            this.mainApp = app;
            this.mainWindow = this.mainApp.MainWindow as MainWindow;
            this.Connect();
            this.sender = new DataSender(this);
            this.timer = new Timer(this.CheckStatus, null, WaitTime, Timeout.Infinite);
        }

        /// <summary>
        /// Gets the command client.
        /// </summary>
        /// <value>
        /// The command client.
        /// </value>
        public CommandServiceClient CommandClient
        {
            get
            {
                return this.commandClient;
            }
        }

        /// <summary>
        /// Gets the local ip address.
        /// </summary>
        /// <returns>Combination of the clients internet address and current time</returns>
        private string GetRegisterKey()
        {
            if (this.ipAddress != string.Empty)
            {
                return this.ipAddress + this.key;
            }

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        this.ipAddress = ip.ToString();
                        return ip.ToString() + this.key;
                    }
                }
            }

            return this.key;
        }

        /// <summary>
        /// Checks the status with the server.
        /// </summary>
        /// <param name="state">The state.</param>
        private void CheckStatus(object state)
        {
            try
            {
                this.commandClient.IsAlive();
                this.SetConnected(true);
                if (this.firstTimeConnected)
                {
                    this.SetCompressorScales();
                    this.SetLoggingState();
                }

                if (!this.commandClient.IsRegisteredForData(this.GetRegisterKey()))
                {
                    this.callbackClient.SubscribeForData(SubscribeInterval, this.GetRegisterKey());
                }

                if (!this.commandClient.IsRegisteredForUpdates(this.GetRegisterKey()))
                {
                    this.callbackClient.SubscribeForUpdates(this.GetRegisterKey());
                }

                this.firstTimeConnected = false;
            }
            catch (CommunicationException)
            {
                this.SetConnected(false);
                this.commandClient.Abort();
                this.callbackClient.Abort();
                this.Connect();
            }
            finally
            {
                this.timer.Change(CheckInterval, Timeout.Infinite);
            }
        }

        /// <summary>
        /// Connects the client to the server.
        /// </summary>
        private void Connect()
        {
            this.key = DateTime.Now.ToString();
            this.commandClient = new CommandServiceClient();
            this.mainApp.CommandServiceClient = this.commandClient;
            DataClientCallback callback = new DataClientCallback(this.mainApp);
            InstanceContext instanceContext = new InstanceContext(callback);
            this.callbackClient = new DataGetClient(instanceContext);
            this.firstTimeConnected = true;
        }

        /// <summary>
        /// Sets the connected property.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void SetConnected(bool state)
        {
            if (this.mainApp != null)
            {
                this.mainApp.Dispatcher.Invoke(
                    () =>
                    {
                        if ((MainWindow)this.mainApp.MainWindow != null)
                        {
                            ViewModelContainer container = ((MainWindow)this.mainApp.MainWindow).Container;
                            if (container != null)
                            {
                                container.ModusViewModel.ServerConnection = state;
                            }
                        }
                    });
            }
        }

        /// <summary>
        /// Sets the compressor scales.
        /// </summary>
        private void SetCompressorScales()
        {
            if (this.mainApp != null)
            {
                this.mainApp.Dispatcher.Invoke(
                    () =>
                    {
                        this.sender.SetCompressorScales((this.mainApp.MainWindow as MainWindow).Container);
                    });
            }
        }

        /// <summary>
        /// Sets the state of the logging.
        /// </summary>
        private void SetLoggingState()
        {
            if (this.mainApp != null)
            {
                this.mainApp.Dispatcher.Invoke(
                    () =>
                    {
                        this.sender.SetLoggerState((this.mainApp.MainWindow as MainWindow).Container);
                    });
            }
        }
    }
}