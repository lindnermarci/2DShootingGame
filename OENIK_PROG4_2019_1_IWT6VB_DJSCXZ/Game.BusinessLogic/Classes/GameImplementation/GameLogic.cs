// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.GameImplementation
{
    using System.Collections.Generic;
    using System.Linq;
    using Game.BusinessLogic.Classes.GameClasses;
    using Game.BusinessLogic.Classes.Math;
    using Game.BusinessLogic.Classes.Physics;
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// <see cref="IGameLogic"/> implementation.
    /// </summary>
    public class GameLogic : IGameLogic
    {
        /// <inheritdoc/>
        IEnumerable<string> IGameLogic.MapNames
        {
            get
            {
                return new string[0];
            }
        }

        /// <inheritdoc/>
        void IGameLogic.Update(IGameState gameState, double deltaTime)
        {
            gameState.DeltaTime = deltaTime;
            gameState.GameTime += deltaTime;
            gameState.RoundTime += deltaTime;

            List<GameObject> physicsObjects = new List<GameObject>(500);
            physicsObjects.Add(gameState.Player);
            physicsObjects.AddRange(gameState.Enemies);
            physicsObjects.AddRange(gameState.Map.Walls);

            this.HandleInput(gameState);
            Physics2D.Calculate(physicsObjects.ToArray(), deltaTime);
        }

        private void HandleInput(IGameState gameState)
        {
            GameMovementInputType input;

            gameState.Player.LookAt(gameState.PlayerLookAt);

            if (gameState.Inputs.Count == 0)
            {
                gameState.Player.Velocity = new Vector2(0, 0);
                return;
            }

            foreach (var enemy in gameState.Enemies)
            {
                enemy.LookAt(gameState.Player);
            }

            while (gameState.Inputs.Count > 0)
            {
                input = gameState.Inputs.First();
                gameState.Inputs.Remove(input);

                switch (input)
                {
                    case GameMovementInputType.MoveDown:
                        gameState.Player.Velocity += new Vector2(0, 1);
                        break;

                    case GameMovementInputType.MoveUp:
                        gameState.Player.Velocity += new Vector2(0, -1);
                        break;

                    case GameMovementInputType.MoveLeft:
                        gameState.Player.Velocity += new Vector2(-1, 0);
                        break;

                    case GameMovementInputType.MoveRight:
                        gameState.Player.Velocity += new Vector2(1, 0);
                        break;
                }
            }

            gameState.Player.Velocity = gameState.Player.Velocity.Normalized;
            gameState.Inputs.Clear();
        }

        private void MovePlayer(GameObject player, double deltaTime)
        {
            player.Position += player.Velocity * deltaTime;
        }
    }
}