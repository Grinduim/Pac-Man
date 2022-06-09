using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
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

            TodasMoedas.Add(this);
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
            PacManMain.Score += 10;
            tocarSom();
        }

        public void tocarSom()
        {
            SoundPlayer som = new SoundPlayer(Properties.Resources.man_coin_sound_effects_1980_1981__mp3cut_net_);
            som.Play();
        }

        public override void OnCollision(CollisionInfo info, Sprite sprite )
        {
            if (sprite is PacMan)
            {
                this.Pegou();
            }
            if(sprite is Paredes p)
            {
                this.Coletada = true;
            }
            if(sprite is Coin C)
            {
                C.Coletada = true;
            }
        }

        public bool AllCoinsColeted()
        {
            foreach (var item in Coin.TodasMoedas)
            {
                
                if (!item.Coletada)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
