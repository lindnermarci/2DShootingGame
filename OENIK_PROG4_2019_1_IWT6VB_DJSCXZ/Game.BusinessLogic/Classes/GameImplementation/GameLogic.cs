// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.GameImplementation
{
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// <see cref="IGameLogic"/> implementation.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <summary>
        /// Implementation of <see cref="IGameLogic"/>
        /// </summary>
        /// <param name="gameState">IGameState parameter.</param>
        /// <param name="deltaTime">Elpased time in seconds since last Update."/></param>
        void IGameLogic.Update(IGameState gameState, double deltaTime)
        {
        }
    }
}
