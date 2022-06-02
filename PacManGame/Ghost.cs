using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGame
{
    internal class Ghost : Sprite
    {
        int direction = 0;
        public float coefVel { get; set; }

        public int Direction { get => direction; set => direction = value; }

        public Ghost(float posx, float posy, int Color)
        {
            this.PosX = posx;
            this.PosY = posy;
            this.VelX = 00;
            this.VelY = 00;
            this.SizeX = 80;
            this.SizeY = 80;
            this.Image = new Image[] { Properties.Resources.ghost_amarelo, Properties.Resources.ghost_amarelo2, Properties.Resources.ghost_azul, Properties.Resources.ghost_azul2,
            Properties.Resources.ghost_rose, Properties.Resources.ghost_rosa2 , Properties.Resources.ghost_vermelho, Properties.Resources.ghost_vermelho2};
            this.HitBox = HitBox.FromSprite(this);

            switch (Color)
            {
                case 1:
                    PosImageAtual = 0;
                    break;
                case 2:
                    PosImageAtual = 2;
                    break;
                case 3:
                    PosImageAtual = 4;
                    break;
                case 4:
                    PosImageAtual = 6;
                    break;

            }

            this.Direction = 0;

            coefVel = 10;
        }
        public override void Draw(PictureBox Jogo, Graphics g)
        {

            if (PosImageAtual % 2 == 0)
            {
                PosImageAtual++;
            }
            else
            {
                PosImageAtual--;
            }


            g.DrawImage(this.Image[PosImageAtual], this.PosX, this.PosY, this.SizeX, this.SizeY);

        }

        public void Right()
        {
            this.PosImageAtual = 0;
            RotateFlipType rft = new RotateFlipType();
            if (this.Direction != 0)
            {
                if (this.direction == 1)
                {
                    rft = (RotateFlipType)4;
                }
                if (this.direction == 2)
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
            this.VelX = coefVel;
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
            this.VelX = -coefVel;
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
            this.VelY = -coefVel;
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
            this.direction = 3;
            this.VelX = 0;
            this.VelY = coefVel;
        }

    }

}
