using MyGameEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlappyBird
{
    public class Game : MyGameEngine.Game
    {
        Random rnd = new Random();
        List<GameObstacle> gameObstacles = new List<GameObstacle>();
        private GameSprite playerSprite;
        private GameText gameText;
        private RenderWindow _renderWindow;
        private TimeSpan timeSpanElapsedTime = new TimeSpan(0, 0, 0, 0);
        private float score = 0;
        private int gap = 0;
        private int scaler = 3;
        private int lastHeight = 500;




        public Game(RenderWindow renderWindow)
        {
            _renderWindow = renderWindow;
        }

        public override void Load()
        {


            gameText = new GameText(_renderWindow);
            gameObstacles.Clear();
            score = 0;
            timeSpanElapsedTime = new TimeSpan(0, 0, 0, 0);

            // Load player sprite
            playerSprite = new GameSprite();
            // Load sprite image
            playerSprite.SpriteImage = Properties.Resources.bird;
            // Set sprite height & width in pixels
            playerSprite.Width = playerSprite.SpriteImage.Width;
            playerSprite.Height = playerSprite.SpriteImage.Height;
            // Set sprite coodinates
            playerSprite.X = _renderWindow.Width / 2;
            playerSprite.Y = _renderWindow.Height / 2;
            // Set sprite Velocity
            playerSprite.Velocity = 250;

            playerSprite.rect = playerSprite.GetSpriteRectangle();

            float heightMin = Convert.ToInt32(_renderWindow.Height * 0.05);
            float heightMax = Convert.ToInt32(_renderWindow.Height * 0.55);



            // Load obstacles
            gap = _renderWindow.Width / scaler;
            for (int i = 0; i < 6; i++)
            {
                GameObstacle obsUpper = new GameObstacle();
                obsUpper.Width = 60;
                obsUpper.Height = rnd.Next((lastHeight - playerSprite.Velocity), (lastHeight + playerSprite.Velocity));

                //obs.Height = Convert.ToInt32(_renderWindow.Height * 0.90) - playerSprite.Height;
                obsUpper.X = _renderWindow.Width + (i * gap);
                obsUpper.Y = 0;
                obsUpper.drawBrush = new SolidBrush(Color.Green);
                gameObstacles.Add(obsUpper);

                GameObstacle obsLower = new GameObstacle();
                obsLower.Width = 60;
                obsLower.Height = _renderWindow.Height - obsUpper.Height;
                obsLower.X = obsUpper.X;
                obsLower.Y = obsUpper.Y + obsUpper.Height + playerSprite.Height + (playerSprite.Velocity / 2);
                obsLower.drawBrush = new SolidBrush(Color.Green);
                gameObstacles.Add(obsLower);
            }



        }

        public override void Update(TimeSpan gameTime)
        {
            // Gametime elapsed
            double gameTimeElapsed = gameTime.TotalMilliseconds / 1000;
            timeSpanElapsedTime += gameTime;
            // Calculate sprite movement based on Sprite Velocity and GameTimeElapsed
            int moveDistance = (int)(playerSprite.Velocity * gameTimeElapsed);
            playerSprite.Y += moveDistance;

            if ((Keyboard.GetKeyStates(Key.Space) & KeyStates.Down) > 0)
            {
                playerSprite.Y -= moveDistance * 3;
            }


            for (int i = 0; i < gameObstacles.Count; i++)
            {
                //collision detection
                if (gameObstacles[i].rect.IntersectsWith(playerSprite.rect))
                    GameOver();

                //did we pass obstacle?
                if (playerSprite.X == gameObstacles[i].X)
                    score += 0.5f;

                //is the obstacle off screen? If so then reposition
                if (gameObstacles[i].X <= (gameObstacles[i].Width * (-1)))
                {
                    gameObstacles[i].X = ((gameObstacles.Count / 2) * gap);
                }


                //obstacle speed
                gameObstacles[i].X -= 5;



            }
        }

        public void GameOver()
        {
            _renderWindow.gameLoop.Stop();
        }

        public override void Draw(Graphics gfx)
        {

            foreach (GameObstacle obs in gameObstacles)
            {
                obs.Draw(gfx);
            }

            // Draw Player Sprite
            playerSprite.Draw(gfx);
            gameText.DrawText(gfx, score.ToString(), 32, Color.White, GameText.TextAlignment.TopCenter);

        }



    }
}
