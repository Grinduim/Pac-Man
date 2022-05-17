﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacManGame
{
    internal class Coin: Sprite
    {
        public bool Coletada { get; set; }
        public  static List<Coin>TodasMoedas { get; set; } = new List<Coin>();
       

         public Coin(float posX, float posY)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.VelX = 0;
            this.VelY = 0;
            this.SizeX = 25;
            this.SizeY = 25;
            this.Image = new Image[] { Properties.Resources.coin};
            this.HitBox = HitBox.FromRectangle(new RectangleF(posX, posY, this.SizeX, this.SizeY));

            this.PosImageAtual = 0;
            Coletada = false;
        }

        public static  void DrawAll(PictureBox Jogo, Graphics g)
        {
            foreach (Coin coin in Coin.TodasMoedas)
            {
                if (!coin.Coletada)
                {
                    coin.Draw(Jogo, g);
                }
            }
        }


        public void Pegou()
        {
            this.Coletada = true;
        }
    }
}