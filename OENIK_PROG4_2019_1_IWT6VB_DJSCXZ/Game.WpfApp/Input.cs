namespace Game.WpfApp
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Input;
    using Game.BusinessLogic.Classes.GameClasses;
    using Game.BusinessLogic.Classes.Math;
    using Game.BusinessLogic.Interfaces;

    /// <summary>
    /// Input class
    /// </summary>
    internal partial class Input
    {
        /// <summary>
        /// Handle input
        /// </summary>
        /// <param name="window">Window.</param>
        /// <param name="gameArea">Game area.</param>
        /// <param name="gameState">Game state.</param>
        public static void Handle(Window window, GameFrameworkElement gameArea, IGameState gameState)
        {
            if (window.IsActive == false)
            {
                return;
            }

            POINT rawMousePosition;
            GetCursorPos(out rawMousePosition);
            Vector2 cursorPos = window.WindowState == WindowState.Maximized ? new Vector2(rawMousePosition.X, rawMousePosition.Y) : new Vector2(rawMousePosition.X - window.Left, rawMousePosition.Y - window.Top);

            Vector2 ingameMousePos = cursorPos;

            ingameMousePos.X -= gameArea.OffsetX;
            ingameMousePos.Y -= gameArea.OffsetY;

            ingameMousePos.X = ingameMousePos.X / gameArea.TextureReferenceSize;
            ingameMousePos.Y = ingameMousePos.Y / gameArea.TextureReferenceSize;

            gameState.PlayerLookAt = ingameMousePos;

            if (GetAsyncKeyState(Keys.Up) != 0)
            {
                gameState.Inputs.Add(GameMovementInputType.MoveUp);
            }

            if (GetAsyncKeyState(Keys.Down) != 0)
            {
                gameState.Inputs.Add(GameMovementInputType.MoveDown);
            }

            if (GetAsyncKeyState(Keys.Left) != 0)
            {
                gameState.Inputs.Add(GameMovementInputType.MoveLeft);
            }

            if (GetAsyncKeyState(Keys.Right) != 0)
            {
                gameState.Inputs.Add(GameMovementInputType.MoveRight);
            }
        }

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey); // Keys enumeration

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }
    }
}
