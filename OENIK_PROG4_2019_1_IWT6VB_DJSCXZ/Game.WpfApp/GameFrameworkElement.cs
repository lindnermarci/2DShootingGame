// <copyright file="GameFrameworkElement.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.WpfApp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Game.BusinessLogic.Classes.GameClasses;
    using Game.BusinessLogic.Classes.GameImplementation;
    using Game.BusinessLogic.Classes.Math;
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// GameDrawer class.
    /// </summary>
    public class GameFrameworkElement : FrameworkElement
    {
        private ImageSource player;
        private ImageSource box;
        private ImageSource background;

        private DrawingContext dc;

        private int drawCalls;

        /// <summary>
        /// Gets or sets camera offset X
        /// </summary>
        public double OffsetX { get; set; }

        /// <summary>
        /// Gets or sets camera offset Y
        /// </summary>
        public double OffsetY { get; set; }

        /// <summary>
        /// Gets texture reference size;
        /// </summary>
        public double TextureReferenceSize
        {
            get => 128;
        }

        /// <summary>
        /// Gets a value indicating whether is drawing
        /// </summary>
        public bool IsDrawing { get; private set; }

        /// <summary>
        /// Gets or sets game state.
        /// </summary>
        public IGameState GameState { get; set; }

        /// <summary>
        /// Loads resources, images, etc.
        /// </summary>
        public void Initialize()
        {
            this.player = new BitmapImage(new System.Uri("Textures/player.png", UriKind.Relative));
            this.background = new BitmapImage(new System.Uri("Textures/dust.png", UriKind.Relative));
            this.box = new BitmapImage(new System.Uri("Textures/box.png", UriKind.Relative));
        }

        /// <summary>
        /// Draws the game state to the <see cref="DrawingContext"/>
        /// </summary>
        /// <param name="dc">Drawing context parameter.</param>
        public void DrawGameElements(DrawingContext dc)
        {
            this.dc = dc;

            foreach (GameObject go in this.GameState.Map.Backgrounds)
            {
                this.DrawGameObject(dc, this.background, go);
            }

            foreach (GameObject go in this.GameState.Map.Walls)
            {
                this.DrawGameObject(dc, this.box, go);
            }

            foreach (GameObject go in this.GameState.Enemies)
            {
                this.DrawGameObject(dc, this.player, go);
            }

            this.DrawGameObject(dc, this.player, this.GameState.Player);

            foreach (GameObject go in this.GameState.Map.Decorations)
            {
            }
        }

        /// <summary>
        /// Override of OnRender
        /// </summary>
        /// <param name="drawingContext">Drawing context parameter.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            this.IsDrawing = true;

            base.OnRender(drawingContext);

            if (this.GameState == null)
            {
                return;
            }

            this.drawCalls = 0;

            this.OffsetX = (-this.GameState.Player.Position.X * this.TextureReferenceSize) + (this.ActualWidth / 2.0);
            this.OffsetY = (-this.GameState.Player.Position.Y * this.TextureReferenceSize) + (this.ActualHeight / 2.0);

            this.DrawGameElements(drawingContext);

            string text = this.GameState.DeltaTime + "\n" + (1.0 / this.GameState.DeltaTime) + "\nRot:" + this.GameState.Player.Rotation + "\n" + this.GameState.Player.Position.ToString() + "\n" + "Draw calls: " + this.drawCalls;

            this.DrawText(20, 20, text);

            this.IsDrawing = false;
        }

        private void DrawGameObject(DrawingContext dc, ImageSource imageSource, GameObject gameObject)
        {
            if (gameObject == null || imageSource == null)
            {
                return;
            }

            double drawPosX = (gameObject.Position.X * this.TextureReferenceSize) + this.OffsetX;
            double drawPosY = (gameObject.Position.Y * this.TextureReferenceSize) + this.OffsetY;
            double sizeX = (gameObject.Size.X * this.TextureReferenceSize) + 0.75;
            double sizeY = (gameObject.Size.Y * this.TextureReferenceSize) + 0.75;

            if (drawPosX < -sizeX || drawPosY < -sizeY || drawPosX > this.ActualWidth + sizeX || drawPosY > this.ActualHeight + sizeY)
            {
                return;
            }

            this.drawCalls++;

            if (gameObject.Rotation == 0)
            {
                dc.DrawImage(imageSource, new Rect(drawPosX - (sizeX / 2.0), drawPosY - (sizeY / 2.0), sizeX, sizeY));
                return;
            }

            dc.PushTransform(new RotateTransform(gameObject.Rotation, drawPosX, drawPosY));
            dc.DrawImage(imageSource, new Rect(drawPosX - (sizeX / 2.0), drawPosY - (sizeY / 2.0), sizeX, sizeY));
            dc.Pop();

        }

        private void DrawText(double x, double y, string text)
        {
            this.dc.DrawText(new FormattedText(text, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 20, Brushes.Black), new System.Windows.Point(x, y));
        }
    }
}
