// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbstractViewModel.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   The abstract view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Media;

    /// <summary>
    /// The abstract view model.
    /// </summary>
    public abstract class AbstractViewModel : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Methods

        /// <summary>
        /// Convert connection state number to string.
        /// </summary>
        /// <param name="connectionState">
        /// The connection state.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ConvertConnectionStateNumberToString(double connectionState)
        {
            switch ((int)connectionState)
            {
                case 0: return "Disconnected";
                case 1: return "Connected";
                default: return "No information";
            }
        }

        /// <summary>
        /// Connections the color.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>Color of connections state.</returns>
        public SolidColorBrush ConnectionColor(int state)
        {
            if (state == 1)
            {
                return (SolidColorBrush) new BrushConverter().ConvertFrom("#4CAF50");
            }
            else if (state == 0)
            {
                return (SolidColorBrush) new BrushConverter().ConvertFrom("#F44336");
            }
            else
            {
                return new SolidColorBrush(Colors.Black);
            }
        }

        /// <summary>
        /// The raise property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion Methods
    }
}