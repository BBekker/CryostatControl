// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerCheck.cs" company="SRON">
//      Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Communication
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.ServiceModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using CryostatControlClient.ServiceReference1;
    using CryostatControlClient.ViewModels;
    using CryostatControlClient.Views;

    /// <summary>
    /// Class which continuously checks the connection with the server
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
        /// The timer
        /// </summary>
        private System.Threading.Timer timer;

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
            this.timer = new System.Threading.Timer(this.CheckStatus, null, WaitTime, Timeout.Infinite);
        }

        /// <summary>
        /// Gets the command client.
        /// </summary>
        /// <value>
        /// The command client.
        /// </value>
        public static CommandServiceClient CommandClient
        {
            get; private set;
        }

        /// <summary>
        /// Sends the message to the server.
        /// </summary>
        /// <param name="task">The task.</param>
        public static void SendMessage(Task task)
        {
            try
            {
                if (CommandClient.State == CommunicationState.Opened)
                {
                    task.Start();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No connection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Something went wrong with the server, check connection and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Firstly it calls the server to see if it is alive. 
        /// If the server is alive nothing happens else an exception is thrown and the connections are aborted and a reconnect is started.
        /// If the client is for the first time connect to the client it updates some GUI elements.
        /// Further it checks if it subscribed for data and updates, if not it subscribes for data.
        /// Finally the timer is reactivated for a new execution.
        /// </summary>
        /// <param name="state">The state.</param>
        private void CheckStatus(object state)
        {
            try
            {
                CommandClient.IsAlive();
                this.SetConnected(true);
                if (this.firstTimeConnected)
                {
                    this.UpdateGUI();
                }

                if (!CommandClient.IsRegisteredForData(this.GetRegisterKey()))
                {
                    this.callbackClient.SubscribeForData(SubscribeInterval, this.GetRegisterKey());
                }

                if (!CommandClient.IsRegisteredForUpdates(this.GetRegisterKey()))
                {
                    this.callbackClient.SubscribeForUpdates(this.GetRegisterKey());
                }

                this.firstTimeConnected = false;
            }
            catch (CommunicationException)
            {
                this.SetConnected(false);
                CommandClient.Abort();
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
            CommandClient = new CommandServiceClient();
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
        /// Updates the GUI components
        /// </summary>
        private void UpdateGUI()
        {
            if (this.mainApp != null)
            {
                this.mainApp.Dispatcher.Invoke(() =>
                    {
                        if ((MainWindow)this.mainApp.MainWindow != null)
                        {
                            ViewModelContainer viewModelContainer = ((MainWindow)this.mainApp.MainWindow).Container;
                            try
                            {
                                CommandServiceClient commandClient = ServerCheck.CommandClient;
                                if (commandClient.State == CommunicationState.Opened && viewModelContainer != null)
                                {
                                    viewModelContainer.CompressorViewModel.TempScale =
                                        commandClient.ReadCompressorTemperatureScale();
                                    viewModelContainer.CompressorViewModel.PressureScale =
                                        commandClient.ReadCompressorPressureScale();
                                    viewModelContainer.LoggingViewModel.LoggingInProgress =
                                        commandClient.IsLogging();
                                }
                            }
                            catch (Exception)
                            {
                                //// Do nothing and continue
                            }
                        }
                    });
            }
        }
    }
}