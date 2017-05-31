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

    /// <summary>
    /// Class which checks continiously the connection with the server
    /// </summary>
    public class ServerCheck
    {
        /// <summary>
        /// The main application
        /// </summary>
        private App mainApp;

        /// <summary>
        /// The main window
        /// </summary>
        private MainWindow mainWindow;

        /// <summary>
        /// The timer
        /// </summary>
        private Timer timer;

        /// <summary>
        /// The command client
        /// </summary>
        private CommandServiceClient commandClient;

        /// <summary>
        /// The callback client
        /// </summary>
        private DataGetClient callbackClient;

        /// <summary>
        /// The sender
        /// </summary>
        private DataSender sender;

        /// <summary>
        /// The first time connected
        /// </summary>
        private bool firstTimeConnected = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerCheck" /> class.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="commandClient">The command client.</param>
        /// <param name="callbackClient">The callback client.</param>
        public ServerCheck(App app, CommandServiceClient commandClient, DataGetClient callbackClient)
        {
            this.mainApp = app;
            this.mainWindow = this.mainApp.MainWindow as MainWindow;
            this.commandClient = commandClient;
            this.callbackClient = callbackClient;
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
                    if (this.firstTimeConnected)
                    {                        
                        this.mainApp.Dispatcher.Invoke(() =>
                        {
                            this.sender.SetCompressorScales((this.mainApp.MainWindow as MainWindow).Container);
                        });                      
                        this.firstTimeConnected = false;                   
                        this.callbackClient.SubscribeForData(1000);
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
                this.firstTimeConnected = true;
                this.commandClient = new CommandServiceClient();
                this.mainApp.CommandServiceClient = this.commandClient;
                DataClientCallback callback = new DataClientCallback(this.mainApp);
                InstanceContext instanceContext = new InstanceContext(callback);
                this.callbackClient = new DataGetClient(instanceContext);
            }
        }

        /// <summary>
        /// Sets the connected property.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void SetConnected(bool state)
        {
            this.mainApp.Dispatcher.Invoke(() =>
            {
                (this.mainApp.MainWindow as MainWindow).Container.ModusViewModel.Server = state;
            });
        }
    }
}