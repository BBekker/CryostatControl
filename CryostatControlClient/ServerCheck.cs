using CryostatControlClient.ServiceReference1;
using CryostatControlClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryostatControlClient
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

        private DataClientCallback callbackClient;

        public ServerCheck(App app, CommandServiceClient commandClient, DataClientCallback callbackClient)
        {
            this.mainApp = app;
            this.mainWindow = this.mainApp.MainWindow as MainWindow;
            this.commandClient = commandClient;
            this.callbackClient = callbackClient;
            this.timer = new Timer(this.CheckStatus, null, 100, 10000);
        }

        private void CheckStatus(object state)
        {
            try
            {
                if (commandClient.IsAlive())
                {
                    //commandClient.AmIRegisteredForData();
                    //commandClient.AmIRegisteredForUpdates();
                }
            }
            catch
            {

            }
        }

    }
}
