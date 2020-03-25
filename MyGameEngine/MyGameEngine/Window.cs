using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGameEngine
{
    public partial class Window : Form
    {

        private const int SCREEN_SIZE_WIDTH_SMALL = 640;
        private const int SCREEN_SIZE_HEIGHT_SMALL = 480;
        private const int SCREEN_SIZE_WIDTH_MEDIUM = 960;
        private const int SCREEN_SIZE_HEIGHT_MEDIUM = 780;
        private const int SCREEN_SIZE_WIDTH_LARGE = 1920;
        private const int SCREEN_SIZE_HEIGHT_LARGE = 1080;

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
            set { engScreenSize = value; }
        }

        private Color engScreenColor;
        public Color EngScreenColor
        {
            get { return EngScreenColor; }
            set { engScreenColor = value; }
        }

        private string engWindowTitle;
        public string EngWindowTitle
        {
            get { return engWindowTitle; }
            set { engWindowTitle = value; this.Text = engWindowTitle; this.FormBorderStyle = FormBorderStyle.FixedSingle; }
        }

        public void EngSetScreenSize(ScreenSize screenSize)
        {
            switch (screenSize)
            {
                case ScreenSize.SMALL:
                    Width = SCREEN_SIZE_WIDTH_SMALL;
                    Height = SCREEN_SIZE_HEIGHT_SMALL;
                    break;
                case ScreenSize.MEDIUM:
                    Width = SCREEN_SIZE_WIDTH_MEDIUM;
                    Height = SCREEN_SIZE_HEIGHT_MEDIUM;
                    break;
                case ScreenSize.LARGE:
                    Width = SCREEN_SIZE_WIDTH_LARGE;
                    Height = SCREEN_SIZE_HEIGHT_LARGE;
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

        public Window()
        {
            InitializeComponent();
        }

        public Window(ScreenSize size, Color backColor, string title)
        {
            InitializeComponent();
            engScreenSize = size;
            engScreenColor = backColor;
            engWindowTitle = title;

        }

        private void Window_Load(object sender, EventArgs e)
        {
            EngSetScreenSize(ScreenSize.SMALL);
            //EngSetScreenBackColor(Color.White);
            //EngSetWindowTitle("My Game Engine");

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();//for now exit the program
            }
        }
    }
}
