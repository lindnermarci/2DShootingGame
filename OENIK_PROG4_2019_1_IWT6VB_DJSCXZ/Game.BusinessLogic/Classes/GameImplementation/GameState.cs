// <copyright file="GameState.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.GameImplementation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Game.BusinessLogic.Classes.Math;
    using global::Game.BusinessLogic.Classes.GameClasses;
    using global::Game.BusinessLogic.Interfaces;

    /// <summary>
    /// <see cref="IGameState"/> implementation.
    /// </summary>
    public class GameState : IGameState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameState"/> class.
        /// </summary>
        public GameState()
        {
            this.Inputs = new HashSet<GameMovementInputType>();
            this.Enemies = new HashSet<GameObject>();
            this.LastUpdateEvents = new HashSet<GameEvent>();
            this.KilledEnemies = new HashSet<GameObject>();
            this.Map = new GameMap();
        }

        /// <inheritdoc/>
        public GameMap Map { get; set; }

        /// <inheritdoc/>
        public HashSet<GameMovementInputType> Inputs { get; set; }

        /// <inheritdoc/>
        public HashSet<GameObject> Enemies { get; set; }

        /// <inheritdoc/>
        public HashSet<GameEvent> LastUpdateEvents { get; set; }

        /// <inheritdoc/>
        public HashSet<GameObject> KilledEnemies { get; set; }

        /// <inheritdoc/>
        public GameObject Player { get; set; }

        /// <inheritdoc/>
        public int Round { get; set; }

        /// <inheritdoc/>
        public double RoundTime { get; set; }

        /// <inheritdoc/>
        public double GameTime { get; set; }

        /// <inheritdoc/>
        public double DeltaTime { get; set; }

        /// <inheritdoc/>
        public Vector2 PlayerLookAt { get; set; }

        /// <inheritdoc/>
        public string Serialize()
        {
            using (var sw = new StringWriter())
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(sw, this);
                return sw.ToString();
            }
        }

        /// <inheritdoc/>
        public IGameState Deserialize(string xml)
        {
            StringReader sr = new StringReader(xml);
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            return (IGameState)serializer.Deserialize(sr);
        }
    }
}
