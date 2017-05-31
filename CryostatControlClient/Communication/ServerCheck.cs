using CryostatControlClient;
using CryostatControlClient.Communication;
using CryostatControlClient.ServiceReference1;
using CryostatControlClient.Views;
using System;
using System.ServiceModel;
using System.Threading;
using System.Windows;

namespace CryostatControlClient.Communication
{
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

        private Timer timer;

        private CommandServiceClient commandClient;

        private DataGetClient callbackClient;

        private DataSender sender;

        private bool firstTimeConnected = false;

        public CommandServiceClient CommandClient
        {
            get
            {
                return this.commandClient;
            }
        }

        public ServerCheck(App app, CommandServiceClient commandClient, DataGetClient callbackClient)
        {
            this.mainApp = app;
            this.mainWindow = this.mainApp.MainWindow as MainWindow;
            this.commandClient = commandClient;
            this.callbackClient = callbackClient;
            this.sender = new DataSender(this);
            this.timer = new Timer(this.CheckStatus, null, 10000, 2000);
        }

        private void CheckStatus(object state)
        {
            try
            {
                if (commandClient.IsAlive())
                {
                    if (firstTimeConnected)
                    {
                        this.mainApp.Dispatcher.Invoke(() =>
                        {
                            this.sender.SetCompressorScales((this.mainApp.MainWindow as MainWindow).Container);
                        });                      
                        this.firstTimeConnected = false;                   
                        callbackClient.SubscribeForData(1000);
                    }
                }
            }
            catch (CommunicationException e)
            {
                commandClient.Abort();
                firstTimeConnected = true;
                commandClient = new CommandServiceClient();
                this.mainApp.CommandServiceClient = commandClient;
                DataClientCallback callback = new DataClientCallback(this.mainApp);
                InstanceContext instanceContext = new InstanceContext(callback);
                this.callbackClient = new DataGetClient(instanceContext);
            }
        }
    }
}