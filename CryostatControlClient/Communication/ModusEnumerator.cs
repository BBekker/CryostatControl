//-----------------------------------------------------------------------
// <copyright file="ModusEnumerator.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlClient.Communication
{
    /// <summary>
    /// Enumerator for modi
    /// </summary>
    public enum ModusEnumerator
    {
        /// <summary>
        /// The cool down
        /// </summary>
        Cooldown = 0,

        /// <summary>
        /// The recycle
        /// </summary>
        Recycle = 1,

        /// <summary>
        /// The warm up
        /// </summary>
        Warmup = 2
    }
}
