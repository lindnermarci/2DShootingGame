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
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dTimer;
        private GameManager gameManager;
        private Stopwatch stopWatch;
        private RenderTargetBitmap renderTargetBitmap;
        private Image image;
        private DrawingVisual drawingVisual;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.gameManager = new GameManager();
            this.stopWatch = new Stopwatch();
            this.image = new Image();
            this.drawingVisual = new DrawingVisual();

            this.renderTargetBitmap = new RenderTargetBitmap((int)this.Width, (int)this.Height, 96, 96, PixelFormats.Default);
            this.image.Source = this.renderTargetBitmap;
            this.canvas.Children.Add(this.image);

            this.dTimer = new DispatcherTimer(DispatcherPriority.Render);
            this.dTimer.Tick += this.RenderTimerTick;
            this.dTimer.Start();
        }

        private void RenderTimerTick(object sender, EventArgs e)
        {
            using (DrawingContext drawingContext = this.drawingVisual.RenderOpen())
            {
                this.stopWatch.Stop();
                double deltaTime = 1.0 / ((double)this.stopWatch.ElapsedMilliseconds);
                this.stopWatch.Start();

                this.gameManager.Update(drawingContext, deltaTime, this.ActualWidth, this.ActualHeight);
            }
        }
    }
}
