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
    using System.Collections.Specialized;
    using System.ComponentModel;

    /// <summary>
    /// The abstract view model.
    /// </summary>
    public abstract class AbstractViewModel : INotifyCollectionChanged
    {

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The collection changed.
        /// </summary>
        public abstract event NotifyCollectionChangedEventHandler CollectionChanged;

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
    }
}
