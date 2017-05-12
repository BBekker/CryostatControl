// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbstractModel.cs" company="SRON">
//  Ok 
// </copyright>
// <summary>
//   Defines the AbstractModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Models
{
    using System.ComponentModel;

    /// <summary>
    /// The abstract model.
    /// </summary>
    public abstract class AbstractModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The on property changed.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
