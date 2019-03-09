// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Interfaces
{
    using Game.BusinessLogic.Classes.GameImplementation;
    using System.Collections.Generic;

    /// <summary>
    /// IGameLogic interface.
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// Gets map list
        /// </summary>
        IEnumerable<string> MapNames { get; }

        /// <summary>
        /// Updates <see cref="IGameLogic"/>
        /// </summary>
        /// <param name="gameState">IGameState parameter.</param>
        /// <param name="deltaTime">Elpased time in seconds since last Update."/></param>
        void Update(IGameState gameState, double deltaTime);
    }
}
