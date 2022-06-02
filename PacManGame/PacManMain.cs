﻿using System;
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
            Pacman.PosX = Jogo.Width / 2 - 40;
            Pacman.PosY = Jogo.Height / 2 +220;
            CriarParedes();
            CreatCoin();

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
            if(e.KeyCode == Keys.Space)
            {
                MessageBox.Show($"x: { Pacman.PosX} e Y: {Pacman.PosY}");
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
            Paredes p1 = new Paredes(lado1.PosX + lado1.SizeX + 100, lado1.PosY + lado1.SizeX + 100, 400, 50);
            //Paredes p2 = new Paredes(lado1.PosX + lado1.SizeX + 100, baixo.PosY - baixo.SizeY - 100, 400, 50);
            Paredes p3 = new Paredes(lado2.PosX - lado2.SizeX - 450, lado1.PosY + lado1.SizeX + 100, 400, 50);
            Paredes p4 = new Paredes(lado2.PosX - lado2.SizeX - 450, baixo.PosY - baixo.SizeY - 100, 400, 50);

            //paredes dos fantasma

            Paredes mm = new Paredes(Jogo.Width / 2 - 150, Jogo.Height / 2 +20, 300, 50);
            Paredes me = new Paredes(Jogo.Width / 2 - 150, Jogo.Height / 2 - 200 +20, 50, 250);
            Paredes md = new Paredes((Jogo.Width / 2) + 100, Jogo.Height / 2 - 200 +20, 50, 250);
            Paredes mcc = new Paredes(me.PosX, me.PosY -50, mm.SizeX, 50);
            

            //paredes laterais gigantes
            Paredes p6 = new Paredes(me.PosX - 150, p1.PosY, 50, (int)(baixo.PosY - 100 - p1.PosY));
            Paredes p7 = new Paredes(md.PosX + 150, p1.PosY, 50, (int)(baixo.PosY - 100 - p1.PosY));
            Paredes mc = new Paredes(me.PosX, p6.PosY, mm.SizeX, 50);

            Paredes p5 = new Paredes(mm.PosX, mm.PosY+ mm.SizeY + 100, 300, 50); // parede no meio para apoio
            Paredes meomenor = new Paredes(p5.PosX + (p5.SizeX) / 2 -50, p5.PosY + 100 + p5.SizeY, 100, 50);


            Paredes p8 = new Paredes(p7.PosX+ p7.SizeX + 100, p7.PosY + 150, 400, 50); // L INVERTIDO MAIOR
            Paredes p9 = new Paredes(p8.PosX + p8.SizeX -50, p8.PosY + p8.SizeY, 50, 300);

            Paredes p10 = new Paredes(p8.PosX , p8.PosY + p8.SizeY +100, (int)p8.SizeX - p7.SizeX - 100 , 50); // L INVERTIDO MENOR
            Paredes p11 = new Paredes(p10.PosX+p10.SizeX - 50, p10.PosY + p10.SizeY, 50, (int)((p4.PosY - p10.PosY+ p10.SizeY) -200));

            Paredes p12 = new Paredes(p9.PosX, p9.PosY + p9.SizeY + 100, 50, (int)(p11.PosY + p11.SizeY  -(p9.PosY + p9.SizeY + 100)));
            Paredes p13 = new Paredes(p10.PosX, p10.PosY + p10.SizeY, 50, (int)((p4.PosY - p10.PosY + p10.SizeY) - 200));

            //lado esquerd
            Paredes p14 = new Paredes(p1.PosX, p1.PosY+ p1.SizeY + 100, 400, 50);
            Paredes p15A = new Paredes(p14.PosX + ( p14.SizeX )/2 -25 , p14.PosY + p14.SizeY, 50, 200);
            Paredes p15B = new Paredes(p14.PosX + (p14.SizeX) / 2 - 25, p15A.PosY + p15A.SizeY + 100, 50, 125);

            Paredes p16 = new Paredes(p15A.PosX - 150, p14.PosY + p14.SizeY + 100, 50, 330);
            Paredes p17 = new Paredes(p15A.PosX + p15A.SizeX + 100, p14.PosY + p14.SizeY + 100, 50, 330);
            Paredes p18 = new Paredes(p14.PosX, p16.PosY + p16.SizeY + 100, 400, 50);


        }

        public void CreatCoin()
        { 
            float coefx = 70;
            float coefy = 60;
            for(int x = 0; x < Jogo.Width / coefx; x++)
            {
                for(int y = 0; y < Jogo.Height / coefy; y ++)
                {
                    var flag = false;
                    float posx = x * coefx;
                    float posy = y * coefy;
                    foreach(var p in Paredes.TodasAsParedes)
                    {
                        if(p.PosX - 10 <= posx && p.PosX+p.SizeX + 10 >= posx && p.PosY - 10 <= posy && p.PosY + p.SizeY + 10 >= posy)
                        {
                            
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        var c = new Coin( posx - 15, posy - 15);
                    }
                   
                }
            }
            /*foreach(var p in Paredes.TodasAsParedes)
            {
                for(int i = 0; i < p.SizeX / 79; i ++)
                {
                    float posx = p.PosX + i * 80;
                    float posy = p.PosY + 80;
                    var c = new Coin(p.PosX + i * 80, p.PosY  + p.PosY + 80 );
                    c.CheckCollision(Paredes.TodasAsParedes);
                }
                for(int i = 0; i < p.SizeY / 79; i++)
                {
                    var a = new Coin(p.PosX + p.SizeX + 40, p.PosY + i * 80 );
                }
              
            }*/
        }
    }
}
