﻿//-----------------------------------------------------------------------
// <copyright file="CommandService.cs" company="SRON">
//     Copyright (c) SRON. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace CryostatControlServer.HostService
{
    using System;

    /// <summary>
    /// Service class which handles the incoming methods calls.
    /// </summary>
    /// <seealso cref="CryostatControlServer.HostService.ICommandService" />
    public class CommandService : ICommandService
    {
        #region Methods

        /// <inheritdoc cref="ICommandService.IsAlive"/>
        public bool IsAlive()
        {
            return true;
        }

        /// <inheritdoc cref="ICommandService.Cooldown"/>>
        public bool Cooldown()
        {
            return false;
        }

        /// <inheritdoc cref="ICommandService.Recycle"/>>
        public bool Recycle()
        {
            return false;
        }

        /// <inheritdoc cref="ICommandService.Warmup"/>>
        public bool Warmup()
        {
            return false;
        }

        /// <inheritdoc cref="ICommandService.ReadSensor"/>>
        public float ReadSensor(int id)
        {
            return 0;
        }

        #endregion Methods
    }
}