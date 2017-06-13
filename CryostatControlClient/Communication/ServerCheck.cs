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
    using System.ServiceModel;
    using System.Threading;

    using CryostatControlClient.ServiceReference1;
    using CryostatControlClient.Views;
    using System.Net.Sockets;
    using System.Net;

    /// <summary>
    /// Class which checks continuously the connection with the server
    /// </summary>
    public class ServerCheck
    {
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


        private string ipAddress = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerCheck" /> class.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="commandClient">The command client.</param>
        /// <param name="callbackClient">The callback client.</param>
        public ServerCheck(App app)
        {
            this.mainApp = app;
            this.mainWindow = this.mainApp.MainWindow as MainWindow;
            this.Connect();
            this.sender = new DataSender(this);
            this.timer = new Timer(this.CheckStatus, null, 5000, 2000);
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
        /// <returns></returns>
        private string GetLocalIPAddress()
        {
            if (this.ipAddress != string.Empty)
            {
                return this.ipAddress;
            }
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        this.ipAddress = ip.ToString();
                        return ip.ToString();
                    }
                }
            }
            return "127.0.0.1";
        }


        /// <summary>
        /// Checks the status with the server.
        /// </summary>
        /// <param name="state">The state.</param>
        private void CheckStatus(object state)
        {
            try
            {
                if (this.commandClient.IsAlive())
                {
                    this.SetConnected(true);                  
                        this.mainApp.Dispatcher.Invoke(
                            () =>
                                {
                                    this.sender.SetCompressorScales((this.mainApp.MainWindow as MainWindow).Container);
                                });
                        this.firstTimeConnected = false;
                    if (!commandClient.IsRegisteredForData(this.GetLocalIPAddress()))
                    {
                        this.callbackClient.SubscribeForData(1000, this.GetLocalIPAddress());
                    }
                    if (!commandClient.IsRegisteredForUpdates(this.GetLocalIPAddress()))
                    {
                        this.callbackClient.SubscribeForUpdates(this.GetLocalIPAddress());
                    }
                }
                else
                {
                    this.SetConnected(false);
                }
            }
            catch (CommunicationException)
            {
                this.SetConnected(false);
                this.commandClient.Abort();
                this.callbackClient.Abort();
                this.firstTimeConnected = true;
                Connect();
            }
        }

        private void Connect()
        {
            this.commandClient = new CommandServiceClient();
            this.mainApp.CommandServiceClient = this.commandClient;
            DataClientCallback callback = new DataClientCallback(this.mainApp);
            InstanceContext instanceContext = new InstanceContext(callback);
            this.callbackClient = new DataGetClient(instanceContext);
        }

        /// <summary>
        /// Sets the connected property.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void SetConnected(bool state)
        {
            this.mainApp.Dispatcher.Invoke(
                () => { ((MainWindow)this.mainApp?.MainWindow).Container.ModusViewModel.ServerConnection = state; });
        }
    }
}