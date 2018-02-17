using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameExpo
{
    class MapObject
    {
        public AnimatedSprite placeHolder;
        public bool enemy;
        public float positionX; 
        public float positionY;
        public int positionMap; // este  es el "lane" en el que estan
        public int secuencia; //  este es el orden en el cual estan callendo
        public float factov;
        private int currentUpdate;
        private int updatesPerFrame;
        private int currentFrame;
        private int totalFrames;

        public MapObject(Texture2D pH, int x, int y, bool type, int FU, int row,int colum,int MP,int SC,int TF)
        {
            placeHolder = new AnimatedSprite(pH, row, colum, FU);
            positionX = x;
            positionY = y;
            enemy = type;
            secuencia = SC;
            positionMap = MP;
            currentUpdate = 0;
            updatesPerFrame = 5;
            placeHolder.totalFrames = TF;
        }

        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == updatesPerFrame)
            {
                //agregar delay
                currentUpdate = 0;
                
                    positionY += (10*factov);
               
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            placeHolder.Draw(spriteBatch, new Vector2(positionX, positionY),1,1);
        }
    }
}
