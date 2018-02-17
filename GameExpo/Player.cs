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
        public float factorVelocity; // velocidad
        private GamePadState controllerPlayer1; 
        public int positionMap; // posision en el mapa "lane"
        private int currentUpdate;
        private int updatesPerFrame;
        private int currentFrame;
        private int totalFrames;
        int totalmovimientosL;
        int totalmovimientosR;
        float maximumV;
        public int monkaS;
        public float Puntuacion;
        public Player(Texture2D pH,int x,int y)
        {
            // le doy una velocidad basica o pongo 0 ?? y que halla boton que acelere en el control
            placeHolder = new AnimatedSprite(pH,1,4,3);
            positionX = x;
            positionY = y;
            totalFrames = 60;
            factorVelocity = 1.0f;
            updatesPerFrame = 5;
            totalmovimientosL = 1;
            totalmovimientosR = 1;
            maximumV = 5.0f;
            positionMap = 0;// o centro -1  izquierda  +1 derecha
            Puntuacion = 0;
            monkaS = 3;
        }
        
        public void Draw(SpriteBatch spriteBatch, Color A)
        {
            placeHolder.Draw(spriteBatch,new Vector2(positionX,positionY),4,3,A);
        }

        public void Input(GamePadState e)
        {
            currentUpdate++;
            if (currentUpdate == updatesPerFrame)
            {
                currentUpdate = 0;

                
                    if (e.DPad.Left == ButtonState.Pressed)
                    {
                        // move left
                        if (totalmovimientosL>0)
                        {
                            positionX -=250;
                            totalmovimientosL--;
                            totalmovimientosR++;
                            positionMap--;
                        }
                    }
                   
                        if (e.DPad.Right == ButtonState.Pressed)
                        {
                            // move rigth 
                            if (totalmovimientosR > 0)
                            {
                                positionX += 250;
                                totalmovimientosR--;
                                totalmovimientosL++;
                                positionMap++;
                            }
                        }
                    
                    if (e.Triggers.Right > 0)
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