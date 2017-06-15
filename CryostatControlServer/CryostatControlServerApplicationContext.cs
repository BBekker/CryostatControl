// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CryostatControlServerApplicationContext.cs" company="SRON">
//      Copyright (c) SRON. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlServer
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    using CryostatControlServer.Properties;

    /// <summary>
    /// The cryostat control server application context.
    /// </summary>
    public class CryostatControlServerApplicationContext : ApplicationContext
    {
        /// <summary>
        /// The debugform.
        /// </summary>
        private static DebugForm dbform = new DebugForm();

        /// <summary>
        /// The tray icon.
        /// </summary>
        private readonly NotifyIcon trayIcon;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryostatControlServerApplicationContext"/> class.
        /// </summary>
        public CryostatControlServerApplicationContext()
        {
            // Initialize Tray Icon
            this.trayIcon = new NotifyIcon()
                                {
                                    Icon = Resources.trayicon,
                                    ContextMenu =
                                        new ContextMenu(
                                            new[]
                                                {
                                                    new MenuItem("Show console", this.ShowConsole),
                                                    new MenuItem("Open log folder", ShowLogs),
                                                    new MenuItem("Exit", this.Exit)
                                                }),
                                    Visible = true
                                };
            Launcher.Launch();
        }

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Application.Run(new CryostatControlServerApplicationContext());
        }

        /// <summary>
        /// The show logs.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void ShowLogs(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"explorer.exe", Settings.Default.LoggingAddress);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// The exit.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            this.trayIcon.Visible = false;
            Launcher.Exit();
            Environment.Exit(0);
        }

        /// <summary>
        /// The show console.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ShowConsole(object sender, EventArgs e)
        {
            dbform.Show();
        }
    }
}