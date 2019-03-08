// <copyright file="IGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;
    using Game.BusinessLogic.Classes.GameObject;

    /// <summary>
    /// IGameState interface.
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// Gets or sets Player
        /// </summary>
        GameObject Player { get; set; }

        /// <summary>
        /// Gets or sets the time since last update in seconds
        /// </summary>
        double DeltaTime { get; set; }
    }
}
