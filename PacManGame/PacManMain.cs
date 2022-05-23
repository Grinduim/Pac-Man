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
            Pacman.PosY = Jogo.Height / 2 +200;
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
            //barreiras em volta do jogo
            Paredes lado1 = new Paredes(0, 0, 50, Jogo.Height);
            Paredes cima = new Paredes(0, 0, Jogo.Width, 50);
            Paredes lado2 = new Paredes(Jogo.Width - 50, 0, 50, Jogo.Height);
            Paredes baixo = new Paredes(0, Jogo.Height - 50, Jogo.Width, 50);


            // canto esquerdo e direto em cima e baixo
            Paredes p1 = new Paredes(lado1.PosX + lado1.SizeX + 100, lado1.PosY + lado1.SizeX + 100, 300, 50);
            Paredes p2 = new Paredes(lado1.PosX + lado1.SizeX + 100, baixo.PosY - baixo.SizeY - 100, 300, 50);
            Paredes p3 = new Paredes(lado2.PosX - lado2.SizeX - 350, lado1.PosY + lado1.SizeX + 100, 300, 50);
            Paredes p4 = new Paredes(lado2.PosX - lado2.SizeX - 350, baixo.PosY - baixo.SizeY - 100, 300, 50);

            Paredes mm = new Paredes(Jogo.Width / 2 - 150, Jogo.Height / 2, 300, 50);
            Paredes me = new Paredes(Jogo.Width / 2 - 150, Jogo.Height / 2 - 200, 50, 250);
            Paredes md = new Paredes((Jogo.Width / 2) + 100, Jogo.Height / 2 - 200, 50, 250);

            Paredes p5 = new Paredes(mm.PosX, mm.PosY+ mm.SizeY + 100, 300, 50);
            Paredes p6 = new Paredes(me.PosX - 150, me.PosY -150, 50, 750);
            Paredes p7 = new Paredes(md.PosX + 150, me.PosY - 150, 50, 750);
            //Paredes p6 = new Paredes(Jogo.Width / 11, Jogo.Height / 10 * 8, 300, 50);
            //Paredes p7 = new Paredes(Jogo.Width / 11 * 8, Jogo.Height / 10 * 8, 300, 50);

            ////cabine dos fantasmas
            //
            //Paredes p9 = new Paredes(Jogo.Width / 2-150, Jogo.Height / 2 - 200, 50, 250);
            //Paredes p10 = new Paredes((Jogo.Width / 2 ) +100, Jogo.Height / 2 - 200, 50, 250);


            //Paredes p11 = new Paredes(Jogo.Width / 8 * 6  - 50, Jogo.Height / 7 + 150, 50,200);
            //Paredes p12 = new Paredes(Jogo.Width / 8 * 6 - 50, Jogo.Height / 7 + 350, 200, 50);
            //Paredes p13 = new Paredes(p12.PosX + p12.SizeX, p12.PosY, 50, 200);



        }
    }
}
