// <copyright file="Physics2D.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.BusinessLogic.Classes.Physics
{
    using System.Collections.Generic;
    using System.Linq;
    using Game.BusinessLogic.Classes.GameClasses;
    using Game.BusinessLogic.Classes.Math;

    /// <summary>
    /// Physics 2D class
    /// </summary>
    public class Physics2D
    {
        /// <summary>
        /// Calculates physics.
        /// </summary>
        /// <param name="objects">Game object list.</param>
        /// <param name="deltaTime">Elpased time in seconds since last update.</param>
        public static void Calculate(IEnumerable<GameObject> objects, double deltaTime)
        {
            foreach (GameObject a in objects)
            {
                if (a.Velocity.Magnitude == 0 || a.Type == GameObjectType.Background)
                {
                    continue;
                }

                if (TryMove(a, a.Velocity * deltaTime, objects) == false)
                {
                    if (TryMove(a, new Vector2(a.Velocity.X, 0) * deltaTime, objects) == false)
                    {
                        TryMove(a, new Vector2(0, a.Velocity.Y) * deltaTime, objects);
                    }
                }
            }
        }

        private static bool TryMove(GameObject target, Vector2 value, IEnumerable<GameObject> otherObjects)
        {
            target.Position += value;

            foreach (GameObject other in otherObjects)
            {
                if (other == target)
                {
                    continue;
                }

                if (AreCollides(target, other))
                {
                    target.Position -= value;
                    return false;
                }
            }

            return true;
        }

        private static double Min(double a, double b)
        {
            return a < b ? a : b;
        }

        private static double Max(double a, double b)
        {
            return a > b ? a : b;
        }

        private static bool IsRectContainsPoint(Vector2 point, Vector2 rectCenter, Vector2 rectSize)
        {
            return point.X > rectCenter.X - (rectSize.X / 2.0) && point.X < rectCenter.X + (rectSize.X / 2.0) && point.Y > rectCenter.Y - (rectSize.Y / 2.0) && point.Y < rectCenter.Y + (rectSize.Y / 2.0);
        }

        private static bool AreCollides(GameObject a, GameObject b)
        {
            if (a.Type == GameObjectType.Character && b.Type == GameObjectType.Character)
            {
                return (a.Position - b.Position).Magnitude < a.Size.X * 0.75;
            }

            if (a.Type == GameObjectType.Character && b.Type == GameObjectType.Wall)
            {
                return IsRectContainsPoint(a.Position, b.Position, new Vector2(b.Size.X + a.Size.X, b.Size.Y + a.Size.Y));
            }

            return false;
        }
    }
}