using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PacManGame
{
    public class PacMan : Sprite
    {

        int direction = 0;

        public int Direction { get => direction; set => direction=value; }

        public PacMan(float posX, float posY, float velX, float velY, int sizeX, int sizeY, int posimage)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.VelX = velX;
            this.VelY = velY;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.Image = new Image[] { Properties.Resources.pacman_direito_aberto, Properties.Resources.pacman_direita_fechado};

            this.PosImageAtual = posimage;

            this.Direction = 0;
        }

        public void Right()
        {
            this.PosImageAtual = 0;
            RotateFlipType rft = new RotateFlipType();
            if (this.Direction != 0)
            {
                if(this.direction == 1)
                {
                    rft = (RotateFlipType)4;
                }
                if(this.direction == 2)
                {
                    rft = (RotateFlipType)1;
                }
                if (this.direction == 3)
                {
                    rft = (RotateFlipType)5;
                }
                var printImage = this.Image[0];
                printImage.RotateFlip(rft);
                printImage = this.Image[1];
                printImage.RotateFlip(rft);
            }
                
            this.direction = 0;
            this.VelX = 10;
            this.VelY = 0;
        }

        public void Left()
        {

            this.PosImageAtual = 0;
            RotateFlipType rft = new RotateFlipType();
            if (this.Direction != 1)
            {
                if (this.direction == 0)
                {
                    rft = (RotateFlipType)4;
                }
                if (this.direction == 3)
                {
                    rft = (RotateFlipType)1;
                }
                if (this.direction == 2)
                {
                    rft = (RotateFlipType)5;
                }
                var printImage = this.Image[0];
                printImage.RotateFlip(rft);
                printImage = this.Image[1];
                printImage.RotateFlip(rft);
            }

            this.direction = 1;
            this.VelX = -10;
            this.VelY = 0;
        }

        public void Up()
        {
            this.PosImageAtual = 0;
            RotateFlipType rft = new RotateFlipType();
            if (this.Direction != 2)
            {
                if (this.direction == 3)
                {
                    rft = (RotateFlipType)6;
                }
                if (this.direction == 0)
                {
                    rft = (RotateFlipType)3;
                }
                if (this.direction == 1)
                {
                    rft = (RotateFlipType)5;
                }
                var printImage = this.Image[0];
                printImage.RotateFlip(rft);
                printImage = this.Image[1];
                printImage.RotateFlip(rft);
            }

            this.direction = 2;
            this.VelX = 0;
            this.VelY = -10;
        }

        public void Down()
        {
            this.PosImageAtual = 0;

            RotateFlipType rft = new RotateFlipType();
            if (this.Direction != 3)
            {
                if (this.direction == 2)
                {
                    rft = (RotateFlipType)6;
                }
                if (this.direction == 0)
                {
                    rft = (RotateFlipType)5;
                }
                if (this.direction == 1)
                {
                    rft = (RotateFlipType)3;
                }
                var printImage = this.Image[0];
                printImage.RotateFlip(rft);
                printImage = this.Image[1];
                printImage.RotateFlip(rft);
            }
            this.direction =3;
            this.VelX = 0;
            this.VelY = 10;
        }

        public void Colisao(PictureBox Jogo, Timer tm)
        {
            if (PosX <= 0)
            {
                PosX = +10;
                tm.Stop();
            }
            if (PosY <= 0)
            {
                PosY = +10;
                tm.Stop();
            }
            if (PosX+SizeX >= Jogo.Width)
            {
                PosX = Jogo.Width - SizeX-10;
                tm.Stop();
            }
            if(PosY+SizeY >= Jogo.Height)
            {
                PosY = Jogo.Height - SizeY-10;
                tm.Stop();
            }
        }

        public void Draw(PictureBox Jogo, Graphics g)
        {

            if (PosImageAtual%2 == 0)
            {
                PosImageAtual++;
            }
            else
            {
                PosImageAtual--;
            }


            g.DrawImage(this.Image[PosImageAtual], this.PosX, this.PosY, this.SizeX, this.SizeY);

        }
    }
    }

