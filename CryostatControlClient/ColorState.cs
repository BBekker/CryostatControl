// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorState.cs" company="SRON">
//   Copyright (c) 2017 SRON
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CryostatControlClient
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The color state.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum ColorState
    {       
        Red = 0,
        Green = 1
    }
}