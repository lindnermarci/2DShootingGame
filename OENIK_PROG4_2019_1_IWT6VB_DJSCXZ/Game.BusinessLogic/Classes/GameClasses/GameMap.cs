// <copyright file="GameMap.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.GameClasses
{
    using System.Collections.Generic;

    /// <summary>
    /// Map class
    /// </summary>
    public class GameMap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameMap"/> class.
        /// </summary>
        public GameMap()
        {
            this.Name = "Default map name";
            this.Backgrounds = new HashSet<GameObject>();
            this.Walls = new HashSet<GameObject>();
            this.Decorations = new HashSet<GameObject>();
        }

        /// <summary>
        /// Gets or sets name of the map
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets background, background is the walk area for graph
        /// </summary>
        public HashSet<GameObject> Backgrounds { get; set; }

        /// <summary>
        /// Gets or sets walls
        /// </summary>
        public HashSet<GameObject> Walls { get; set; }

        /// <summary>
        /// Gets or sets decorations
        /// </summary>
        public HashSet<GameObject> Decorations { get; set; }
    }
}
