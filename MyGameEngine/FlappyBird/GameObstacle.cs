using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    class GameObstacle
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public SolidBrush drawBrush { get; set; }
        public Rectangle rect = new Rectangle();

        public GameObstacle()
        {

        }

        public void Draw(Graphics gfx)
        {


            Pen pen = new Pen(Color.Black, 4);
            rect.X = Convert.ToInt32(X);
            rect.Y = Convert.ToInt32(Y);
            rect.Width = Convert.ToInt32(Width);
            rect.Height = Convert.ToInt32(Height);

            // Draw sprite image on screen
            gfx.FillRectangle(drawBrush, new RectangleF(X, Y, Width, Height));
            gfx.DrawRectangle(pen, rect);
        }
    }
}
