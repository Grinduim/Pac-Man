using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGame
{
    public class Paredes : Sprite
    {

        private static List<Paredes> todasAsParedes = new List<Paredes>();

        public static List<Paredes> TodasAsParedes { get => todasAsParedes; set => todasAsParedes = value; }

        public Paredes(float posx, float posy, int sizex, int sizey)
        {
            PosX = posx;
            PosY = posy;
            SizeX = sizex;
            SizeY = sizey;
            VelX = 0;
            VelY = 0;
            this.Image = new Image[] { Properties.Resources.bars };
            PosImageAtual = 0;
        }

        public override void Draw(PictureBox Jogo, Graphics g)
        {
            g.DrawImage(this.Image[0], this.PosX, this.PosY, this.SizeX, this.SizeY);
        }

        public static void DrawAll(PictureBox Jogo, Graphics g)
        {
            foreach(Paredes parede in Paredes.TodasAsParedes)
            {
                parede.Draw(Jogo,g);

            }
        }
    }
}
