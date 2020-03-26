using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace MyGameEngine
{
    public class Game
    {

        public Game()
        {
            //_renderWindow = renderWindow;
        }

        /// <summary>
        /// Load assets eg graphics, music etc
        /// </summary>
        public virtual void Load()
        {
            // Load graphics
            // Turn off game music
        }

        /// <summary>
        /// Unload assets eg graphics, music etc
        /// </summary>
        public void Unload()
        {
            // Unload graphics
            // Turn off game music
        }

        /// <summary>
        /// Standard OnUpdate event
        /// </summary>
        public virtual void Update(TimeSpan gameTime)
        {
            // Gametime elapsed
            double gameTimeElapsed = gameTime.TotalMilliseconds / 1000;


            // Move player sprite, when Arrow Keys are pressed on Keyboard
            //if ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0)
            //{
            //    playerSprite.X += moveDistance;
            //}
            //else if ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0)
            //{
            //    playerSprite.X -= moveDistance;
            //}
            //else if ((Keyboard.GetKeyStates(Key.Up) & KeyStates.Down) > 0)
            //{
            //    playerSprite.Y -= moveDistance;
            //}
            //else if ((Keyboard.GetKeyStates(Key.Down) & KeyStates.Down) > 0)
            //{
            //    playerSprite.Y += moveDistance;
            //}

          


        }

        /// <summary>
        /// Standard OnPaint event
        /// </summary>
        public virtual void Draw(Graphics gfx)
        {
                        
            // Draw Player Sprite
            //playerSprite.Draw(gfx);

        }

    }
}
