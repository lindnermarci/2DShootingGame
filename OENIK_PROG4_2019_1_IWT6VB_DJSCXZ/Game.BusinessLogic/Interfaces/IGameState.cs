// <copyright file="IGameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;
    using Game.BusinessLogic.Classes.GameClasses;
    using Game.BusinessLogic.Classes.Math;

    /// <summary>
    /// IGameState interface.
    /// </summary>
    public interface IGameState
    {
        /// <summary>
        /// Gets or sets map
        /// </summary>
        GameMap Map { get; set; }

        /// <summary>
        /// Gets or sets walls
        /// </summary>
        HashSet<GameObject> Enemies { get; set; }

        /// <summary>
        /// Gets or sets inputs for the game
        /// </summary>
        HashSet<GameMovementInputType> Inputs { get; set; }

        /// <summary>
        /// Gets or sets events occured in last update
        /// </summary>
        HashSet<GameEvent> LastUpdateEvents { get; set; }

        /// <summary>
        /// Gets or sets enemies who are killed in last tick
        /// </summary>
        HashSet<GameObject> KilledEnemies { get; set; }

        /// <summary>
        /// Gets or sets player look at position
        /// </summary>
        Vector2 PlayerLookAt { get; set; }

        /// <summary>
        /// Gets or sets Player
        /// </summary>
        GameObject Player { get; set; }

        /// <summary>
        /// Gets or sets round
        /// </summary>
        int Round { get; set; }

        /// <summary>
        /// Gets or sets round time
        /// </summary>
        double RoundTime { get; set; }

        /// <summary>
        /// Gets or sets game time
        /// </summary>
        double GameTime { get; set; }

        /// <summary>
        /// Gets or sets the time since last update in seconds
        /// </summary>
        double DeltaTime { get; set; }

        /// <summary>
        /// Serializes state to string
        /// </summary>
        /// <returns>Serialized state.</returns>
        string Serialize();

        /// <summary>
        /// Deserialize xml string
        /// </summary>
        /// <param name="xml">Xml string.</param>
        /// <returns>Result.</returns>
        IGameState Deserialize(string xml);
    }
}
