// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.WpfApp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Windows.Threading;
    using Game.BusinessLogic.Classes.GameClasses;
    using Game.BusinessLogic.Classes.GameImplementation;
    using Game.BusinessLogic.Classes.Math;
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dTimer;
        private Stopwatch stopWatch;
        private IGameLogic gameLogic;
        private IGameState gameState;
        private double deltaTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.stopWatch = new Stopwatch();
            this.gameLogic = new GameLogic();
            this.gameState = new GameState();

            this.gameState.Player = new GameObject() { Size = new Vector2(0.5, 0.5) };

            this.gameFrameworkElement.Initialize();
            this.gameFrameworkElement.GameState = this.gameState;

            for (double i = 0; i < 6; i += 0.4)
            {
                this.gameState.Enemies.Add(new GameObject() { Position = new Vector2((Math.Cos(i) * 2) + (i * 1), (Math.Sin(i) * 2) + (i * 1)), Size = new Vector2(0.5, 0.5) });
            }

            for (int i = -15; i < 15; i++)
            {
                for (int j = -15; j < 15; j++)
                {
                    this.gameState.Map.Backgrounds.Add(new GameObject() { Position = new Vector2(i, j), Size = new Vector2(1, 1), Type = GameObjectType.Background });
                }
            }

            this.gameState.Map.Walls.Add(new GameObject() { Position = new Vector2(1, 1), Size = new Vector2(1, 1), Type = GameObjectType.Wall });
            this.gameState.Map.Walls.Add(new GameObject() { Position = new Vector2(2, 1), Size = new Vector2(1, 1), Type = GameObjectType.Wall });

            this.gameState.Map.Walls.Add(new GameObject() { Position = new Vector2(4, 4), Size = new Vector2(1, 1), Type = GameObjectType.Wall });

            this.dTimer = new DispatcherTimer(DispatcherPriority.Render);
            this.dTimer.Tick += this.RenderTimerTick;
            this.dTimer.Interval = TimeSpan.FromMilliseconds(10);
            this.dTimer.Start();
        }

        private void RenderTimerTick(object sender, EventArgs e)
        {
            this.stopWatch.Stop();

            double deltaTime = this.stopWatch.Elapsed.TotalSeconds;

            if (this.stopWatch.ElapsedMilliseconds == 0 || double.IsNaN(this.deltaTime))
            {
                this.deltaTime = 0.01;
            }

            this.stopWatch.Reset();
            this.stopWatch.Start();

            Input.Handle(this, this.gameFrameworkElement, this.gameState);

            this.gameLogic.Update(this.gameState, deltaTime);

            if (this.gameFrameworkElement.IsDrawing == false)
            {
                this.gameFrameworkElement.InvalidateVisual();
            }
        }
    }
}
