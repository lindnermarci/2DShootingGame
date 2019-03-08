// <copyright file="GameFrameworkElement.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.WpfApp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Game.BusinessLogic.Classes.GameObject;
    using Game.BusinessLogic.Classes.Math;
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// GameDrawer class.
    /// </summary>
    public class GameFrameworkElement : FrameworkElement
    {
        private ImageSource player;
        private DrawingContext dc;
        private double offsetX;
        private double offsetY;

        private List<GameObject> todrawsTest = new List<GameObject>();

        /// <summary>
        /// Gets or sets game state.
        /// </summary>
        public IGameState GameState { get; set; }

        /// <summary>
        /// Loads resources, images, etc.
        /// </summary>
        public void LoadResources()
        {
            this.player = new BitmapImage(new System.Uri("Textures/player.png", UriKind.Relative));

            for (double i = 0; i < 6; i += 0.04)
            {
                this.todrawsTest.Add(new GameObject() { Position = new Vector2(Math.Cos(i) * 300 + i * 30, Math.Sin(i) * 300 + i * 30) });
            }
        }

        /// <summary>
        /// Draws the game state to the <see cref="DrawingContext"/>
        /// </summary>
        /// <param name="dc">Drawing context parameter.</param>
        public void Draw(DrawingContext dc)
        {
            this.dc = dc;
            this.DrawGameObject(dc, this.player, this.GameState.Player);

            foreach(GameObject go in this.todrawsTest)
            {
                this.DrawGameObject(dc, this.player, go);
            }

        }

        /// <summary>
        /// Override of OnRender
        /// </summary>
        /// <param name="drawingContext">Drawing context parameter.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            //base.OnRender(drawingContext);

            if (this.GameState == null)
            {
                return;
            }

            this.offsetX = -this.GameState.Player.Position.X + (this.ActualWidth / 2.0);
            this.offsetY = -this.GameState.Player.Position.Y + (this.ActualHeight / 2.0);

            this.Draw(drawingContext);

            string text = "";
            text += this.GameState.DeltaTime + "\n" + (1.0 / this.GameState.DeltaTime) + "\nRot:" + this.GameState.Player.Rotation + "\n" + this.GameState.Player.Position.ToString() + "\n" + this.todrawsTest.Count + "db";

            this.DrawText(20, 20, text);
        }

        private void DrawGameObject(DrawingContext dc, ImageSource imageSource, GameObject gameObject)
        {
            if (gameObject == null || imageSource == null)
            {
                return;
            }

            double drawPosX = gameObject.Position.X + this.offsetX;
            double drawPosY = gameObject.Position.Y + this.offsetY;

            if (drawPosX < -32 || drawPosY < -32 || drawPosX > this.ActualWidth + 32 || drawPosY > this.ActualHeight + 32)
            {
                return;
            }

            dc.PushTransform(new RotateTransform(gameObject.Rotation, drawPosX, drawPosY));
            dc.DrawImage(imageSource, new Rect(drawPosX - 32, drawPosY - 32, 64, 64));
            dc.Pop();
        }

        private void DrawText(double x, double y, string text)
        {
            this.dc.DrawText(new FormattedText(text, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 20, Brushes.Black), new System.Windows.Point(x, y));
        }
    }
}
