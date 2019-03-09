// <copyright file="GameObject.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.GameClasses
{
    using Game.BusinessLogic.Classes.Math;

    /// <summary>
    /// GameObject class.
    /// </summary>
    public class GameObject
    {
        private int mHealth = 100;
        private double mRotation = 0;

        /// <summary>
        /// Gets or sets <see cref="Type"/>
        /// </summary>
        public GameObjectType Type { get; set; }

        /// <summary>
        /// Gets or sets <see cref="DamageType"/>
        /// </summary>
        public GameObjectDamageType DamageType { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Position"/> of the <see cref="GameObject"/>
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Size"/> of the <see cref="GameObject"/>
        /// </summary>
        public Vector2 Size { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Velocity"/> of the <see cref="GameObject"/>
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Gets health of the <see cref="GameObject"/>
        /// </summary>
        public int Health { get; }

        /// <summary>
        /// Gets or sets rotation.
        /// </summary>
        public double Rotation
        {
            get => this.mRotation;

            set
            {
                this.mRotation = value % 360;
            }
        }

        /// <summary>
        /// Damages the <see cref="GameObject"/>
        /// </summary>
        /// <param name="value_">Damage value.</param>
        /// <returns>Is the GameObject health reached 0 or negative value.</returns>
        public bool Damage(int value_)
        {
            if (this.DamageType == GameObjectDamageType.Damagable)
            {
                this.mHealth -= value_;
            }

            return this.mHealth <= 0;
        }

        /// <summary>
        /// Looks at gameobject, degree = 0 is the up
        /// </summary>
        /// <param name="other">Other gameobject.</param>
        public void LookAt(GameObject other)
        {
            Vector2 diff = other.Position - this.Position;
            this.Rotation = diff.AngleDegree + 90;
        }

        /// <summary>
        /// Looks at position, degree = 0 is the up
        /// </summary>
        /// <param name="position">Pos to look at.</param>
        public void LookAt(Vector2 position)
        {
            Vector2 diff = position - this.Position;
            this.Rotation = diff.AngleDegree + 90;
        }
    }
}
