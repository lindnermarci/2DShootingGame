﻿// <copyright file="Vector2.cs" company="PlaceholderCompany">
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
        /// Initializes a new instance of the <see cref="Vector2"/> struct.
        /// </summary>
        /// <param name="x">X component.</param>
        /// <param name="y">Y component.</param>
        public Vector2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

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

        /// <summary>
        /// Gets normalized vector
        /// </summary>
        public Vector2 Normalized
        {
            get
            {
                double magnitude = this.Magnitude;

                if (magnitude == 0)
                {
                    return new Vector2(0, 0);
                }

                return new Vector2(this.X / magnitude, this.Y / magnitude);
            }
        }

        /// <summary>
        /// Gets angle in radian
        /// </summary>
        public double AngleRadian
        {
            get
            {
                return Math.Atan2(this.Y, this.X);
            }
        }

        /// <summary>
        /// Gets angle in degree
        /// </summary>
        public double AngleDegree
        {
            get
            {
                return (Math.Atan2(this.Y, this.X) / Math.PI) * 180.0;
            }
        }

        /// <summary>
        /// Operator override
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="b">Vector B</param>
        /// <returns>Result of the operation.</returns>
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        /// <summary>
        /// Operator override
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="b">Vector B</param>
        /// <returns>Result of the operation.</returns>
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        /// <summary>
        /// Operator override
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="b">Vector B</param>
        /// <returns>Result of the operation.</returns>
        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X * b.X, a.Y * b.Y);
        }

        /// <summary>
        /// Operator override
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="b">Vector B</param>
        /// <returns>Result of the operation.</returns>
        public static Vector2 operator *(Vector2 a, double b)
        {
            return new Vector2(a.X * b, a.Y * b);
        }

        /// <summary>
        /// Operator override
        /// </summary>
        /// <param name="a">Vector A</param>
        /// <param name="b">Vector B</param>
        /// <returns>Result of the operation.</returns>
        public static Vector2 operator *(double b, Vector2 a)
        {
            return new Vector2(a.X * b, a.Y * b);
        }



        /// <summary>
        /// Override of ToString
        /// </summary>
        /// <returns>Vector2 as string.</returns>
        public override string ToString()
        {
            return ((float)this.X).ToString("0.00") + "; " + ((float)this.Y).ToString("0.00");
        }
    }
}
