// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.WpfApp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
    using Game.BusinessLogic.Classes.GameImplementation;
    using Game.BusinessLogic.Classes.GameObject;
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

            this.gameState.Player = new GameObject();

            this.gameFrameworkElement.LoadResources();
            this.gameFrameworkElement.GameState = this.gameState;

            this.dTimer = new DispatcherTimer(DispatcherPriority.Render);
            this.dTimer.Tick += this.RenderTimerTick;
            this.dTimer.Interval = TimeSpan.FromMilliseconds(3);
            this.dTimer.Start();
        }

        private void RenderTimerTick(object sender, EventArgs e)
        {
            this.stopWatch.Stop();

            double deltaTime = this.stopWatch.Elapsed.TotalSeconds;

            if (this.stopWatch.ElapsedMilliseconds == 0 || double.IsNaN(this.deltaTime))
            {
                this.deltaTime = 0.001;
            }

            this.stopWatch.Reset();
            this.stopWatch.Start();

            this.gameLogic.Update(this.gameState, deltaTime);
            this.gameFrameworkElement.InvalidateVisual();
        }
    }
}
