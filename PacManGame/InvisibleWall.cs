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
        public bool colision { get; set; }
        private static int coef = 20;
        private static int size = 60;
        public static List<InvisibleWall> Walls { get; set; } =   new List<InvisibleWall>();
        public InvisibleWall(float posx, float posy, int sizex, int sizey) 
        {
            this.PosX = posx;
            this.PosY = posy;
            this.VelX = 00;
            this.VelY = 00;
            this.SizeX = sizex;
            this.SizeY = sizey;
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

        public void Desactive()
        {
            this.colision = false;
            Timer tm = new Timer();
            tm.Interval = 4000;
            tm.Tick += delegate
            {
                this.colision = true;
                tm.Stop();
            };
            tm.Start();

        }

        public static void CreatWallDownRight(Paredes p)
        {
            var teste = new InvisibleWall(p.PosX + p.SizeX + coef, p.PosY + p.SizeY + coef, size, size);
            teste.CheckCollision(InvisibleWall.Walls);
        }
        public static void CreatWallDownLeft(Paredes p)
        {
            var teste = new InvisibleWall(p.PosX - (coef + size), p.PosY + p.SizeY + coef, size, size);
            teste.CheckCollision(InvisibleWall.Walls);
        }

        public static void CreatWallTopRight(Paredes p)
        {
            var teste = new InvisibleWall(p.PosX + p.SizeX + coef, p.PosY - (coef + size) , size, size);
            teste.CheckCollision(InvisibleWall.Walls);
        }

        public static void CreatWallTopLeft(Paredes p)
        {
            var teste = new InvisibleWall(p.PosX - (coef + size), p.PosY - (coef + size), size, size);
            teste.CheckCollision(InvisibleWall.Walls);
        }

        public static void CreatAroundWall(Paredes p)
        {
            InvisibleWall.CreatWallDownLeft(p);
            InvisibleWall.CreatWallTopLeft(p);
            InvisibleWall.CreatWallDownRight(p);
            InvisibleWall.CreatWallTopRight(p);
        }

        public override void OnCollision(CollisionInfo info, Sprite sprite)
        {
            if(sprite is InvisibleWall iw)
            {
                if(InvisibleWall.Walls.Count > 0)
                {
                    //InvisibleWall.Walls.RemoveAt);

                }
            }
            if(sprite is Paredes)
            {

            }
        }
    }
}
