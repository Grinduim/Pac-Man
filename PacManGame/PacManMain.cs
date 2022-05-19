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
        PacMan Pacman = new PacMan(10, 150);
        

        Timer tm = new Timer();
        
        public PacManMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
           
        }

        private void PacManMain_Load(object sender, EventArgs e)
        {
            Pacman.PosX = Jogo.Width / 2;
            Pacman.PosY = Jogo.Height / 2;
            CriarParedes();
            

            var coin = new Coin(400, 150);

            Jogo.Image = new Bitmap(Jogo.Width, Jogo.Height);
            Bitmap bmp = Jogo.Image as Bitmap;
            Graphics g = Graphics.FromImage(bmp);
            Pacman.Draw(Jogo,g);
            Jogo.Refresh();
            tm.Interval = 60;
            tm.Tick += delegate
            {
                Pacman.Move(tm);
                g.Clear(Color.Black);
                Pacman.CheckCollision(Coin.TodasMoedas);
                Pacman.CheckCollision(Paredes.TodasAsParedes);
                Pacman.HitBox.Draw(g);
                coin.HitBox.Draw(g);
                Pacman.Draw(Jogo,g);
                Paredes.DrawAll(Jogo, g);
                Coin.DrawAll(Jogo,g);
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
                tm.Start();
                return;
            }
            if(e.KeyCode == Keys.Left) {
                Pacman.Left();
                tm.Start();
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                Pacman.Down();
                tm.Start();
                return;
            }
            if(e.KeyCode == Keys.Up)
            {
                Pacman.Up();
                tm.Start();
                return;
            }

        }

        public void CriarParedes()
        {
            Paredes p0 = new Paredes(0, 0, 50, Jogo.Height);
            Paredes p1 = new Paredes(0, 0, Jogo.Width, 50);
            Paredes p2 = new Paredes(Jogo.Width -50,0,50, Jogo.Height);
            Paredes p3 = new Paredes(0, Jogo.Height-50, Jogo.Width, 50);

            Paredes p4 = new Paredes(Jogo.Width / 9, Jogo.Height / 7, 300, 50);


        }
    }
}
