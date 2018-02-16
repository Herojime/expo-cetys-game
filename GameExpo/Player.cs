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
    class Player
    {
        public AnimatedSprite placeHolder; // imagen
        private int positionX; //movimento horizontal
        private int positionY; // movimiento vertical
        private float factorVelocity; // velocidad
        private GamePadState controllerPlayer1; 
        public int positionMap; // posision en el mapa "lane"
        private int currentUpdate;
        private int updatesPerFrame;
        private int currentFrame;
        private int totalFrames;
        int totalmovimientosL;
        int totalmovimientosR;
        float maximumV;

        public Player(Texture2D pH,int x,int y)
        {
            // le doy una velocidad basica o pongo 0 ?? y que halla boton que acelere en el control
            placeHolder = new AnimatedSprite(pH,1,4,3);
            positionX = x;
            positionY = y;
            totalFrames = 60;
            factorVelocity = 1.0f;
            updatesPerFrame = 1;
            totalmovimientosL = 1;
            totalmovimientosR = 1;
            maximumV = 3.0f;
            positionMap = 0;// o centro -1  izquierda  +1 derecha
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            placeHolder.Draw(spriteBatch,new Vector2(positionX,positionY),2,2);
        }

        public void Input()
        {
            currentUpdate++;
            if (currentUpdate == updatesPerFrame)
            {
                currentUpdate = 0;

                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    if (controllerPlayer1.DPad.Left == ButtonState.Pressed)
                    {
                        // move left
                        if (totalmovimientosL>0)
                        {
                            positionX -= 60;
                            totalmovimientosL--;
                            totalmovimientosR++;
                            positionMap--;
                        }
                    }
                    else
                    {
                        if (controllerPlayer1.DPad.Right == ButtonState.Pressed)
                        {
                            // move rigth 
                            if (totalmovimientosR > 0)
                            {
                                positionX += 60;
                                totalmovimientosR--;
                                totalmovimientosL++;
                                positionMap++;
                            }
                        }
                    }
                    if (controllerPlayer1.Triggers.Left > 0)
                    {
                        if (factorVelocity<maximumV)
                        {
                            factorVelocity *= 1.25f;
                        }
                        
                    }
                    else
                    {
                        if (factorVelocity>0.1f)
                        {
                            factorVelocity /= 1.25f;
                        }
                    }
                }
            }
        }

    }
}