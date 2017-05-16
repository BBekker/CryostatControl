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
    using System.Windows;

    using CryostatControlClient.ServiceReference1;

    /// <summary>
    /// Interaction logic for <see cref="App.xaml"/>
    /// </summary>
    public partial class App
    {
        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CommandServiceClient commandClient = new CommandServiceClient();

            DataClientCallback callback = new DataClientCallback();
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
        }

        #endregion Methods
    }
}