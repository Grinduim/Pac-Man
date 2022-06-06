using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGame
{
    public class InvisibleWall : Sprite
    {
        public bool colision { get; set; };
        public static List<InvisibleWall> Walls { get; set; } =   new List<InvisibleWall>();
        public InvisibleWall(float posx, float posy, int sizex, int sizey) 
        {
            this.PosX = posx;
            this.PosY = posy;
            this.VelX = 00;
            this.VelY = 00;
            this.SizeX = 80;
            this.SizeY = 80;
            colision = true;
            this.HitBox = HitBox.FromRectangle(new RectangleF(PosX, PosY, SizeX, sizey));
            InvisibleWall.Walls.Add(this);

        }

        public static void DrawAll(PictureBox Jogo, Graphics g)
        {
            foreach (InvisibleWall wall in InvisibleWall.Walls)
            {
                wall.HitBox.Draw(g);
            }
        }
    }
}
