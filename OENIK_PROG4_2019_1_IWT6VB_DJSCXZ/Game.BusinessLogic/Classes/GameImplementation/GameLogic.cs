// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.GameImplementation
{
    using Game.BusinessLogic.Classes.Math;
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// <see cref="IGameLogic"/> implementation.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        private double mDir = -50;

        /// <summary>
        /// Implementation of <see cref="IGameLogic"/>
        /// </summary>
        /// <param name="gameState">IGameState parameter.</param>
        /// <param name="deltaTime">Elpased time in seconds since last Update."/></param>
        void IGameLogic.Update(IGameState gameState, double deltaTime)
        {
            gameState.DeltaTime = deltaTime;

            gameState.Player.Rotation += deltaTime * 90.0;

            gameState.Player.Position += new Vector2(this.mDir * deltaTime * 2.0, 0);

            if (gameState.Player.Position.X < -100)
            {
                this.mDir = 50;
            }

            if (gameState.Player.Position.X > 100)
            {
                this.mDir = -50;
            }

        }
    }
}
