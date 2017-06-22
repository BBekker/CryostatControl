//-----------------------------------------------------------------------
// <copyright file="PressureEnum.cs" company="SRON">
//     Copyright (c) 2017 SRON
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.Compressor
{
    /// <summary>
    /// Enumerator for pressure scale
    /// </summary>
    public enum PressureEnum
    {
        /// <summary>
        /// PSI scale
        /// </summary>
        PSI = 0,

        /// <summary>
        /// Bar scale
        /// </summary>
        Bar = 1,

        /// <summary>
        /// KPA scale
        /// </summary>
        KPA = 2
    }
}