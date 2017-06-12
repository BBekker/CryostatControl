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
        public SolidColorBrush DisplayColor(ColorState state)
        {
            switch (state)
            {
                case ColorState.Green: return (SolidColorBrush)new BrushConverter().ConvertFrom("#4CAF50");
                case ColorState.Red: return (SolidColorBrush)new BrushConverter().ConvertFrom("#F44336");
                default: return new SolidColorBrush(Colors.Black);
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