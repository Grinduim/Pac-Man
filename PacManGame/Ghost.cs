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

        public bool Free { get; set; } = false;
        public int Direction { get => direction; set => direction = value; }

        public static List<Ghost> All { get; set; } = new List<Ghost>();

        private int countMove;
        private bool CollisionWithWall = false ;

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
            Ghost.All.Add(this);

            this.GetOff();

        }
        public override void Draw(PictureBox Jogo, Graphics g)
        {
            g.DrawImage(this.Image[PosImageAtual], this.PosX, this.PosY, this.SizeX, this.SizeY);

        }

        public void Right()
        {
            this.direction = 0;
            this.VelX = coefVel;
            this.VelY = 0;
        }

        public void Left()
        {
            this.direction = 1;
            this.VelX = -coefVel;
            this.VelY = 0;
        }

        public void Up()
        {
            this.direction = 2;
            this.VelX = 0;
            this.VelY = -coefVel;
        }

        public void Down()
        {
            this.direction = 3;
            this.VelX = 0;
            this.VelY = coefVel;
        }

        public static void DrawAll(PictureBox Jogo, Graphics g)
        {
            foreach (var item in Ghost.All)
            {
                item.Draw(Jogo, g);
            }
        }

        public void GetOff()
        {
            Timer tm = new Timer();
            tm.Interval = 1500  * (this.PosImageAtual +1 ) / 2 ;
            tm.Tick += delegate
            { 
                tm.Stop();
                this.Free = true;
                this.PosY = 220;
            };
            tm.Start();
            
        }

        public override void Move()
        {
            base.Move();
            if (this.CollisionWithWall)
            {
                if (this.countMove ==  6 )
                {
                    this.CollisionWithWall = false;
                    this.ChangeDirection();
                    this.countMove = 0;
                    return;

                }
                this.countMove++;
            }
           

        }
        public void ChangeDirection()
        {
            // direita 0
            //esquerda 1
            //cima 2
            //baixo 3
            Random rnd = new Random(DateTime.Now.Millisecond);
            int opc = rnd.Next(1,8);

            if(this.direction == 0)
            {
                if(opc == 1)
                    this.Left();
                else if(opc == 2 ||opc == 3)
                    this.Up();

                else if( opc == 4 || opc == 5)
                    this.Down();

                else if(opc == 7 || opc == 6)
                    this.Right();
            }
            else if(this.direction  == 1)
            {
                if (opc == 1)
                    this.Right();
                else if (opc == 2 || opc == 3)
                    this.Up();

                else if (opc == 4 || opc == 5)
                    this.Down();

                else if (opc == 7 || opc == 6)
                    this.Left();
            }
            else if( this.direction == 2)
            {
                if (opc == 1)
                    this.Up();
                else if (opc == 2 || opc == 3)
                    this.Right();

                else if (opc == 4 || opc == 5)
                    this.Down();

                else if (opc == 7 || opc == 6)
                    this.Left();
            }
            else if(this.direction == 3)
            {
                if (opc == 1)
                    this.Down();
                else if (opc == 2 || opc == 3)
                    this.Right();

                else if (opc == 4 || opc == 5)
                    this.Up();

                else if (opc == 7 || opc == 6)
                    this.Left();
            }

        }

        public static void MovelAll()
        {
            foreach (var ghost in Ghost.All)
            {
                var posx = ghost.PosX;
                var posy = ghost.PosY;
                if (ghost.Free == true)
                {
                    ghost.Move();
                    ghost.CheckCollision(Paredes.TodasAsParedes);
                    ghost.CheckCollision(InvisibleWall.Walls);
                }
                else
                {

                    continue;
                }

                if (posx == ghost.PosX && posy == ghost.PosY)
                {
                    ghost.ChangeDirection();
                }
            }
        }

        public override void OnCollision(CollisionInfo info, Sprite sprite)
        {
            if (sprite is Paredes p)
            {
                if (info.CollisionPoints.Count > 1)
                {
                    if (info.CollisionPoints[0].X == info.CollisionPoints[1].X)
                    {
                        this.PosX = PosX - VelX;
                    }
                    else
                    {
                        this.PosY = this.PosY - VelY;
                    }
                }
                else if (info.SideA.X == info.SideB.X)
                {
                    this.PosX = PosX - VelX;
                }
                else
                {
                    this.PosY = this.PosY - VelY;
                }
            }
            if (sprite is InvisibleWall i)
            {
                if( i.colision == true )
                {
                    this.CollisionWithWall = true;
                    i.Desactive();
                }
               
            }
        }

    }

}
