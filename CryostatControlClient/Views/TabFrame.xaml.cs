// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TabFrame.xaml.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Views
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TabFrame 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabFrame"/> class.
        /// </summary>
        public TabFrame()
        {
        }

        /// <summary>
        /// Frames the navigated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Navigation.NavigationEventArgs"/> instance containing the event data.</param>
        private void FrameNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            ((FrameworkElement)e.Content).DataContext = this.DataContext;
        }
    }
}
