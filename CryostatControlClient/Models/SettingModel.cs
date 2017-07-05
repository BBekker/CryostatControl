// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingModel.cs" company="SRON">
//  Copyright (c) 2017 SRON
// </copyright>
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
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public string Unit { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value { get; set; }
    }
}