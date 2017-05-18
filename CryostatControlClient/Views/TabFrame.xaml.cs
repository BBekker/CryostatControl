// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TabFrame.xaml.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Interaction logic for Window1.xaml
// </summary>
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

        private void FrameNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            ((FrameworkElement)e.Content).DataContext = this.DataContext;
        }
    }
}
