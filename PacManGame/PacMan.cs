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
        public float coefVel { get; set; }

        public int Direction { get => direction; set => direction = value; }

        public PacMan(float posX, float posY)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.VelX = 00;
            this.VelY = 00;
            this.SizeX = 80;
            this.SizeY = 80;
            this.Image = new Image[] { Properties.Resources.pacman_boca_aberta, Properties.Resources.pacaman_boca_fechada };
            this.HitBox = HitBox.FromSprite(this);

            this.PosImageAtual = 0;

            this.Direction = 0;

            coefVel = 10;
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

        //public void Colisao(PictureBox Jogo, Timer tm, List<Coin> ListCoin)
        //{
        //    if (PosX <= 0)
        //    {
        //        PosX = +10;
        //        tm.Stop();
        //    }
        //    if (PosY <= 0)
        //    {
        //        PosY = +10;
        //        tm.Stop();
        //    }
        //    if (PosX+SizeX >= Jogo.Width)
        //    {
        //        PosX = Jogo.Width - SizeX-10;
        //        tm.Stop();
        //    }
        //    if(PosY+SizeY >= Jogo.Height)
        //    {
        //        PosY = Jogo.Height - SizeY-10;
        //        tm.Stop();
        //    }

        //    foreach (Paredes item in Paredes.TodasAsParedes)
        //    {
        //        if(this.PosX >= item.PosX && this.PosX <= item.PosX + item.SizeX && this.PosY >= item.PosY && this.PosY <= item.PosY + item.SizeY)
        //        {
        //            tm.Stop();
        //        }
        //    }

        //    foreach(Coin item in ListCoin)
        //    {
        //        if (this.PosX >= item.PosX && this.PosX <= item.PosX + item.SizeX && this.PosY >= item.PosY && this.PosY <= item.PosY + item.SizeY)
        //        {
        //            item.Coletada = false;
        //        }
        //    }
        //}

        public void Draw(PictureBox Jogo, Graphics g)
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

        public override void OnCollision(CollisionInfo info, Sprite sprite)
        {
            if (sprite is Coin c)
            {
                c.Pegou();
            }
            if(sprite is Paredes p)
            {
                if(info.SideA.X != info.SideB.X)
                {
                    if(info.SideA.Y >= this.PosY)
                    {
                        this.PosY = PosY - VelY;
                    }
                    else
                    {
                        this.PosY = PosY + VelY;
                    }
                    
                }
                else if( info.SideB.Y != info.SideA.Y)
                {
                    if (info.SideA.X >= this.PosX )
                    {
                        this.PosX = PosX  - VelX;
                    }
                    else if( info.SideB.Y <= this.PosX)
                    {
                        this.PosX = PosX - VelX;
                    }
                }
            }
            
        }
    }
}

