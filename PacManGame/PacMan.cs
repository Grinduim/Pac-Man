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
            if(this.Direction != 0)
            {
                var printImage = this.Image[0];
                direction = direction *-1 +3;
                RotateFlipType rft = (RotateFlipType)direction;
                printImage.RotateFlip(rft);
                printImage = this.Image[1];
                rft = (RotateFlipType)direction;
                printImage.RotateFlip(rft);
            }
                

            this.direction = 0;
            this.VelX = 10;
            this.VelY = 0;
        }

        public void Left()
        {
            
            this.PosImageAtual = 0;
            if (this.Direction != 1)
            {
                var printImage = this.Image[0];
                direction = direction *-1 +4;
                RotateFlipType rft = (RotateFlipType)direction;
                printImage.RotateFlip(rft);
                printImage = this.Image[1];
                rft = (RotateFlipType)direction;
                printImage.RotateFlip(rft);
            }

            this.direction = 1;
            this.VelX = -10;
            this.VelY = 0; 

        }

        public void Up()
        {
            this.PosImageAtual = 0;
            this.direction = 2;
            this.VelX = 0;
            this.VelY = -10;
        }

        public void Down()
        {
            this.PosImageAtual = 0;
            this.direction =3;
            this.VelX = 0;
            this.VelY = 10;
        }

        public  override void Colisao(PictureBox Jogo)
        {
            if (PosX <= 0)
            {
                PosX = 0;
            }
            if (PosY <= 0)
            {
                PosY = 0;
            }
            if (PosX+SizeX >= Jogo.Width)
            {
                PosX = Jogo.Width - SizeX;
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

