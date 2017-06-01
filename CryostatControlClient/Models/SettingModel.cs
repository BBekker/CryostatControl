// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingModel.cs" company="SRON">
//   bla
// </copyright>
// <summary>
//   Defines the SettingModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient.Models
{
    /// <summary>
    /// The setting model.
    /// </summary>
    public class SettingModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingModel"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="unit">
        /// The unit.
        /// </param>
        public SettingModel(int id, double value, string title, string unit)
        {
            this.Id = id;
            this.Value = value;
            this.Title = title;
            this.Unit = unit;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets the unit.
        /// </summary>
        public string Unit { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public double Value { get; set; }
    }
}