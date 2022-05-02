using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PacManGame
{
    public class PacMan : Sprite
    {

        public PacMan(float posX, float posY, float velX, float velY, int sizeX, int sizeY, int posimage)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.VelX = velX;
            this.VelY = velY;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.Image = new Image[] { Properties.Resources.Pacman_Openmouth_right, Properties.Resources.pacman_closemouthn_right, Properties.Resources.pacman_openmouth_left, Properties.Resources.pacman_closemouthn_left, Properties.Resources.pacman_openmouth_up, Properties.Resources.pacman_closemouthn_up, Properties.Resources.pacaman_openmouth_bot, Properties.Resources.pacman_closemouthn_up };

            this.PosImageAtual = posimage;
        }

        public void Right()
        {
            this.PosImageAtual = 0;
            this.VelX = 10;
            this.VelY = 0;
        }

        public void Left()
        {
            this.PosImageAtual = 2;
            this.VelX = -10;
            this.VelY = 0;
        }

        public void Up()
        {
            this.PosImageAtual = 4;
            this.VelX = 0;
            this.VelY = -10;
        }

        public void Down()
        {
            this.PosImageAtual = 6;
            this.VelX = 0;
            this.VelY = 10;
        }
    }
}
