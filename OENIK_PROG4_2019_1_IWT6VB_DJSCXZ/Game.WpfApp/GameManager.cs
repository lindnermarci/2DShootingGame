// <copyright file="GameManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Game.WpfApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using Game.BusinessLogic.Classes.GameImplementation;
    using Game.BusinessLogic.Classes.GameObject;
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// GameManager class.
    /// </summary>
    internal class GameManager
    {
        private DrawingContext dc;
        private IGameLogic gameLogic;
        private IGameState gameState;
        private GameDrawer drawer = new GameDrawer();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameManager"/> class.
        /// </summary>
        public GameManager()
        {
            this.gameLogic = new GameLogic();
            this.gameState = new GameState();

            this.gameState.Player = new GameObject();
        }

        /// <summary>
        /// Update method of <see cref="GameManager"/>
        /// </summary>
        /// <param name="dc">Drawing context parameter.</param>
        /// <param name="deltaTime">Elpased time since last update.</param>
        /// <param name="screenWidth">Screen width.</param>
        /// <param name="screenHeight">Screen height.</param>
        public void Update(DrawingContext dc, double deltaTime, double screenWidth, double screenHeight)
        {
            this.dc = dc;

            if (this.gameLogic == null || this.gameState == null)
            {
                return;
            }

            this.gameLogic.Update(this.gameState, deltaTime);
            this.drawer.Draw(this.gameState, dc, screenWidth, screenHeight);
        }
    }
}
