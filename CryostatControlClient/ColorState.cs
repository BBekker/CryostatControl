// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorState.cs" company="SRON">
//   k
// </copyright>
// <summary>
//   Defines the ColorState type.
// </summary>
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