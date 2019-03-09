// <copyright file="GameEvent.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.GameClasses
{
    using Game.BusinessLogic.Classes.Math;

    /// <summary>
    /// GameEvent class
    /// </summary>
    public class GameEvent
    {
        /// <summary>
        /// Gets or sets event's position
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets event's name
        /// </summary>
        public string EventName { get; set; }
    }
}
