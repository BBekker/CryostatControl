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

        public async Task Execute(Action<DataGetClient> action, int timeoutInMilliseconds, DataGetClient client)
        {
            await Task.Delay(timeoutInMilliseconds);
            action(client);
        }

        public void Unsubscribe(DataGetClient client)
        {
            client.UnsubscribeForData();
        }

        public void Test()
        {
            Console.WriteLine("I can say hello");
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
            }
            catch (System.ServiceModel.EndpointNotFoundException exception)
            {
                Console.WriteLine("Server is alive: {0}", false);
            }

            Console.WriteLine("Subscribed for data");
            dataClient.SubscribeForData(1000);

            //Execute(this.Unsubscribe, 1000, dataClient);
        }

        #endregion Methods
    }
}