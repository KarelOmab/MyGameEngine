using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameEngine
{
    public class GameSprite
    {
        public Bitmap SpriteImage { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public int Velocity { get; set; }
        public Rectangle rect { get; set; }

        public void Draw(Graphics gfx)
        {

            if (rect != null)
                rect = GetSpriteRectangle();

            // Draw sprite image on screen
            gfx.DrawImage(SpriteImage, new RectangleF(X, Y, Width, Height));
        }

        public Rectangle GetSpriteRectangle()
        {
            Rectangle rect = new Rectangle();
            rect.X = Convert.ToInt32(X);
            rect.Y = Convert.ToInt32(Y);
            rect.Width = Convert.ToInt32(Width);
            rect.Height = Convert.ToInt32(Height);

            return rect;
        }
    }
}
