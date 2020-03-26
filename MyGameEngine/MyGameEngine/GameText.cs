using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameEngine
{
    public class GameText
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        private RenderWindow _renderWindow;

        public enum TextAlignment
        {
            TopLeft,
            TopCenter,
            TopRight,
            CenterLeft,
            Center,
            CenterRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        };

        public GameText(RenderWindow renderWindow)
        {
            _renderWindow = renderWindow;
        }

        public void DrawText(Graphics gfx, string text, int textSize, Color textColor, TextAlignment textAlignment)
        {

            // Create string to draw.
            String drawString = text;

            // Create font and brush.
            Font drawFont = new Font("Arial", textSize);
            SolidBrush drawBrush = new SolidBrush(textColor);

            SizeF stringSize = new SizeF();
            stringSize = gfx.MeasureString(text, drawFont);

            // Create rectangle for drawing.
            float width = stringSize.Width;
            float height = stringSize.Height;


            float x = 0;
            float y = 0;

            if (textAlignment == TextAlignment.TopCenter)
            {
                x = (_renderWindow.Width / 2) - (width / 2);
                y = (_renderWindow.Height / 6);
            }
            else if (textAlignment == TextAlignment.Center)
            {
                x = (_renderWindow.Width / 2) - (width / 2);
                y = (_renderWindow.Height / 2) - (height / 2);
            }
            else if (textAlignment == TextAlignment.BottomRight)
            {
                x = (_renderWindow.Width - (_renderWindow.Width / 4));
                y = (_renderWindow.Height - (_renderWindow.Height / 12));
            }



            // Draw text on screen
            gfx.DrawString(drawString, drawFont, drawBrush, x, y);
        }
        public void DrawTextRect(Graphics gfx, string text, int textSize, Color textColor, TextAlignment textAlignment)
        {

            // Create string to draw.
            String drawString = text;

            // Create font and brush.
            Font drawFont = new Font("Arial", textSize);
            SolidBrush drawBrush = new SolidBrush(textColor);

            SizeF stringSize = new SizeF();
            stringSize = gfx.MeasureString(text, drawFont);

            // Create rectangle for drawing.
            float width = stringSize.Width;
            float height = stringSize.Height;


            float x = 0;
            float y = 0;

            if (textAlignment == TextAlignment.TopCenter)
            {
                x = (_renderWindow.Width / 2) - (width / 2);
                y = (_renderWindow.Height / 6);
            }
            else if (textAlignment == TextAlignment.Center)
            {
                x = (_renderWindow.Width / 2) - (width / 2);
                y = (_renderWindow.Height / 2) - (height / 2);
            }
            else if (textAlignment == TextAlignment.BottomRight)
            {
                x = (_renderWindow.Width - (_renderWindow.Width / 8)) - (width / 2);
                y = (_renderWindow.Height - (_renderWindow.Height / 12)) - (height / 2);
            }

            RectangleF drawRect = new RectangleF(x, y, width, height);

            // Draw rectangle to screen.
            Pen blackPen = new Pen(Color.Red);
            gfx.DrawRectangle(blackPen, x, y, width, height);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;

            // Draw text on screen
            gfx.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);
        }
    }
}
