using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGameEngine
{
    public partial class RenderWindow : Form
    {

        public const int SCREEN_SIZE_SMALL_WIDTH = 640;
        public const int SCREEN_SIZE_SMALL_HEIGHT = 480;
        public const int SCREEN_SIZE_MEDIUM_WIDTH = 960;
        public const int SCREEN_SIZE_MEDIUM_HEIGHT = 780;
        public const int SCREEN_SIZE_LARGE_WIDTH = 1920;
        public const int SCREEN_SIZE_LARGE_HEIGHT = 1080;
        private Color SCREEN_COLOR_BACKCOLOR = Color.Black;

        public enum ScreenSize
        {
            SMALL,
            MEDIUM,
            LARGE,
            FULLSCREEN
        };


        private ScreenSize engScreenSize;
        public ScreenSize EngScreenSize
        {
            get { return EngScreenSize; }
            set { engScreenSize = value; EngSetScreenSize(engScreenSize); }
        }

        private Color engScreenColor;
        public Color EngScreenColor
        {
            get { return EngScreenColor; }
            set { engScreenColor = value; this.BackColor = engScreenColor; }
        }

        private string engWindowTitle;
        public string EngWindowTitle
        {
            get { return engWindowTitle; }
            set { engWindowTitle = value; this.Text = engWindowTitle; this.FormBorderStyle = FormBorderStyle.FixedSingle; }
        }

        public Graphics engGraphics;

        public void EngSetScreenSize(ScreenSize screenSize)
        {
            switch (screenSize)
            {
                case ScreenSize.SMALL:
                    Width = SCREEN_SIZE_SMALL_WIDTH;
                    Height = SCREEN_SIZE_SMALL_HEIGHT;
                    break;
                case ScreenSize.MEDIUM:
                    Width = SCREEN_SIZE_MEDIUM_WIDTH;
                    Height = SCREEN_SIZE_MEDIUM_HEIGHT;
                    break;
                case ScreenSize.LARGE:
                    Width = SCREEN_SIZE_LARGE_WIDTH;
                    Height = SCREEN_SIZE_LARGE_HEIGHT;
                    break;
                case ScreenSize.FULLSCREEN:
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }


            CenterToScreen();

        }
        public void EngSetWindowTitle(string title)
        {
            EngWindowTitle = title;
        }
        public void EngSetScreenBackColor(Color color)
        {
            BackColor = color;
        }

        Timer graphicsTimer;
        public GameLoop gameLoop;
        public Game game { get; set; }



        //public Window()
        //{
        //    InitializeComponent();
        //}

        public int GetScreenHeight()
        {
            return Height;
        }

        public int GetScreenWidth()
        {
            return Width;
        }

        public RenderWindow(int width, int height, Color backColor, string title)
        {
            InitializeComponent();
            //EngScreenSize = screenSize;
            Width = width;
            Height = height;

            if (backColor != null)
                EngScreenColor = backColor;
            else EngScreenColor = SCREEN_COLOR_BACKCOLOR;

            if (title.Length > 0)
                EngWindowTitle = title;

            engGraphics = this.CreateGraphics();

            Paint += Window_Paint;
            // Initialize graphicsTimer
            graphicsTimer = new Timer();
            graphicsTimer.Interval = 1000 / 120;
            graphicsTimer.Tick += GraphicsTimer_Tick;




        }

        private void GraphicsTimer_Tick(object sender, EventArgs e)
        {
            // Refresh form graphics
            Invalidate();
        }

        private void Window_Load(object sender, EventArgs e)
        {
            //EngSetScreenSize(ScreenSize.SMALL);
            //EngSetScreenSize(ScreenSize.SMALL);
            //EngSetScreenBackColor(Color.White);
            //EngSetWindowTitle("My Game Engine");
            NewGame();


        }

        public void NewGame()
        {
            // Initialize & Start GameLoop
            gameLoop = new GameLoop();
            gameLoop.Load(game);
            gameLoop.Start();

            // Start Graphics Timer
            graphicsTimer.Start();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();//for now exit the program
            }
            else if(e.KeyCode == Keys.Enter)
            {
                NewGame();
            }
        }

        public void Window_Paint(object sender, PaintEventArgs e)
        {

            //engGraphics = e.Graphics;
            //DrawRectangleScreenCenter(e);
            //DrawString(e, "Sample text", TextAlignment.TopCenter);
            
            // Draw game graphics on form
            gameLoop.Draw(e.Graphics);
        }
    }
}
