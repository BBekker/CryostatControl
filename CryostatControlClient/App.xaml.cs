// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Interaction logic for App.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient
{
    using System;
    using System.Windows;

    using CryostatControlClient.ServiceReference1;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region Methods

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CommandServiceClient client = new CommandServiceClient();

            Console.WriteLine("{0}", client.SayHello("Maiko"));
        }

        #endregion Methods
    }
}