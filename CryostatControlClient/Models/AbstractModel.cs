//-----------------------------------------------------------------------
// <copyright file="AbstractModel.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Models
{
    using System;

    using LiveCharts.Defaults;
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

        public AbstractModel()
        {
            this.lastUpdate = DateTime.Now;
        }

        /// <summary>
        /// Adds to graph.
        /// </summary>
        /// <param name="lineSeries">The line series.</param>
        /// <param name="value">The value.</param>
        public void AddToGraph(LineSeries lineSeries, double value)
        {
            TimeSpan changed = DateTime.Now.Subtract(this.lastUpdate);
            
            if (changed > TimeSpan.FromSeconds(1)) 
            {
                Console.WriteLine("Changed - " + changed);
                this.lastUpdate = DateTime.Now;
            }
            lineSeries.Values.Add(new DateTimePoint(DateTime.Now, value));
            if (lineSeries.Values.Count > 50)
            {
                lineSeries.Values.RemoveAt(0);
            }
        }
    }
}
