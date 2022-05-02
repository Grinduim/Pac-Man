using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGame
{
    public partial class PacManMain : Form
    {
        PacMan Pacman = new PacMan(10, 20, 10, 00, 80, 80, 0);


        Timer tm = new Timer();
        public PacManMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void PacManMain_Load(object sender, EventArgs e)
        {
            Jogo.Image = new Bitmap(Jogo.Width, Jogo.Height);
            Pacman.Draw(Jogo);
            Jogo.Refresh();

            tm.Interval = 60;
            tm.Tick += delegate
            {
                Pacman.Move();
                Pacman.Draw(Jogo);
                Jogo.Refresh();
            };
            tm.Start();
        }

        private void ReadKey(object sender, KeyEventArgs e)
        {
            var KeyPress = e.KeyCode;
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();                                                                                                                                                                 
                return;
            }
            if (e.KeyCode == Keys.Right)
            {
                Pacman.Right();
                return;
            }
            if(e.KeyCode == Keys.Left) {
                Pacman.Left();
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                Pacman.Down();
                return;
            }
            if(e.KeyCode == Keys.Up)
            {
                Pacman.Up();
                return;
            }

        }
    }
}
