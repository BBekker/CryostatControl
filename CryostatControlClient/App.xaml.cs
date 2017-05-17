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

    using CryostatControlClient.ServiceReference1;

    /// <summary>
    /// Interaction logic for <see cref="App.xaml"/>
    /// </summary>
    public partial class App
    {
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
        /// Unsubscribes the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        public void Unsubscribe(DataGetClient client)
        {
            client.UnsubscribeForData();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CommandServiceClient commandClient = new CommandServiceClient();

            DataClientCallback callback = new DataClientCallback(this);
            InstanceContext instanceContext = new InstanceContext(callback);
            DataGetClient dataClient = new DataGetClient(instanceContext);

            try
            {
                Console.WriteLine("Server is alive: {0}", commandClient.IsAlive());
                Console.WriteLine("Subscribed for data");
                dataClient.SubscribeForData(1000);
                ////Execute(this.Unsubscribe, 5000, dataClient);
            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {
                Console.WriteLine("Server is alive: {0}", false);
            }
        }

        #endregion Methods
    }
}