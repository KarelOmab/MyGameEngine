using MyGameEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RenderWindow rWindow = new RenderWindow(100, 100, Color.SteelBlue, "");
            Game game = new Game(rWindow);
            rWindow.game = game;
            rWindow.EngSetScreenSize(RenderWindow.ScreenSize.FULLSCREEN); //using my template


            Application.Run(rWindow);
        }
    }
}
