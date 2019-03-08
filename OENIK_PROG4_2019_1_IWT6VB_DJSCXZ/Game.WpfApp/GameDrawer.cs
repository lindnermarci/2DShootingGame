// <copyright file="GameDrawer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.WpfApp
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Game.BusinessLogic.Classes.GameObject;
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// GameDrawer class.
    /// </summary>
    public class GameDrawer
    {
        private ImageSource player;
        private DrawingContext dc;
        private double offsetX = 0;
        private double offsetY = 0;

        /// <summary>
        /// Loads resources, images, etc.
        /// </summary>
        public void LoadResources()
        {
            this.player = new BitmapImage(new System.Uri("Textures/player.png", UriKind.Relative));
        }

        /// <summary>
        /// Draws the game state to the <see cref="DrawingContext"/>
        /// </summary>
        /// <param name="gameState">Game state parameter.</param>
        /// <param name="dc">Drawing context parameter.</param>
        /// <param name="screenWidth">Screen width.</param>
        /// <param name="screenHeight">Screen height.</param>
        public void Draw(IGameState gameState, DrawingContext dc, double screenWidth, double screenHeight)
        {
            this.dc = dc;
            this.DrawGameObject(dc, this.player, gameState.Player);
        }

        private void DrawGameObject(DrawingContext dc, ImageSource imageSource, GameObject gameObject)
        {
            if (gameObject == null || imageSource == null)
            {
                return;
            }

            dc.PushTransform(new RotateTransform(gameObject.Rotation, gameObject.Position.X, gameObject.Position.Y));
            dc.DrawImage(imageSource, new Rect(gameObject.Position.X - 50 + this.offsetX, gameObject.Position.Y - 50 + this.offsetY, 100, 100));
            dc.Pop();
        }
    }
}
