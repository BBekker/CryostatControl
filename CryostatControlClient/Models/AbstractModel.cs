//-----------------------------------------------------------------------
// <copyright file="AbstractModel.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;

    using LiveCharts.Defaults;
    using LiveCharts.Geared;
    using LiveCharts.Wpf;

    /// <summary>
    /// The abstract model
    /// </summary>
    public abstract class AbstractModel
    {
        /// <summary>
        /// The last update
        /// </summary>
        private DateTime lastUpdate;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractModel"/> class.
        /// </summary>
        public AbstractModel()
        {
            this.lastUpdate = DateTime.Now;
        }

        /// <summary>
        /// Adds to graph.
        /// </summary>
        /// <param name="lineSeries">The line series.</param>
        /// <param name="value">The value.</param>
        public void AddToGraph(GLineSeries lineSeries, double value)
        {
            lineSeries.Values.Add(new DateTimePoint(DateTime.Now, value));
            if (lineSeries.Values.Count > 500)
            {
                lineSeries.Values.RemoveAt(0);
            }
        }
    }
}
