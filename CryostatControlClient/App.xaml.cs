// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// <summary>
//   Interaction logic for App.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CryostatControlClient
{
    using System;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using System.Windows;

    using CryostatControlClient.Communication;
    using CryostatControlClient.ServiceReference1;

    /// <summary>
    /// Interaction logic for <see cref="App.xaml" /></summary>
    /// <seealso cref="System.Windows.Application" />
    public partial class App
    {
        #region Fields

        /// <summary>
        /// The command client
        /// </summary>
        private CommandServiceClient commandServiceClient;

        /// <summary>
        /// The server check
        /// </summary>
        private ServerCheck serverCheck;

        #endregion Fields

        #region Propertis

        /// <summary>
        /// Gets or sets the command service client.
        /// </summary>
        /// <value>
        /// The command service client.
        /// </value>
        public CommandServiceClient CommandServiceClient
        {
            get
            {
                return this.commandServiceClient;
            }

            set
            {
                this.commandServiceClient = value;
            }
        }

        /// <summary>
        /// Gets the server check.
        /// </summary>
        /// <value>
        /// The server check.
        /// </value>
        public ServerCheck ServerCheck
        {
            get
            {
                return this.serverCheck;
            }
        }

        #endregion Propertis

        #region Methods

        /// <summary>
        /// Executes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="timeoutInMilliseconds">The timeout in milliseconds.</param>
        /// <param name="client">The client.</param>
        /// <returns>Returns the task</returns>
        public async Task Execute(Action<DataGetClient> action, int timeoutInMilliseconds, DataGetClient client)
        {
            await Task.Delay(timeoutInMilliseconds);
            action(client);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.serverCheck = new ServerCheck(this);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Exit" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.ExitEventArgs" /> that contains the event data.</param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Environment.Exit(0);
        }

        #endregion Methods
    }
}