// <copyright file="Vector2.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.Math
{
    using System;

    /// <summary>
    /// Two dimensional vector.
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// Gets or sets <see cref="X"/> (horizontal) component of the vector.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Y"/> (vertical) component of the vector.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets magnitude of the <see cref="Vector2"/>.
        /// </summary>
        public double Magnitude
        {
            get
            {
                return Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
            }
        }
    }
}
