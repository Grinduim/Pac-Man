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
            Paredes parede = new Paredes(150, 200, 300, 60);
            Paredes.TodasAsParedes.Add(parede);

            var coin = new Coin(400, 150);
            Coin.TodasMoedas.Add(coin);

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
                Pacman.CheckCollision(coin);
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
    }
}
