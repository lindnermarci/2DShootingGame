// <copyright file="GameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.GameImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Game.BusinessLogic.Classes.GameObject;
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// <see cref="IGameState"/> implementation.
    /// </summary>
    public class GameState : IGameState
    {
        /// <summary>
        /// Gets or sets <see cref="IGameState.Player"/>
        /// </summary>
        public GameObject Player { get; set; }

        /// <summary>
        /// Gets or sets the time since last update in seconds
        /// </summary>
        public double DeltaTime { get; set; }


    }
}
