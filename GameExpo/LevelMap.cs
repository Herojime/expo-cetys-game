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
    class LevelMap
    {
        //  I dont knwo what type of data structure should it have and what algorithm should use
        // REEEEEE 
        MapObject[] mapita = new MapObject[3];
        MapObject[] mapito = new MapObject[3];
        Random random ;
        Random random2;
        int boneless;
        int pizza;

        public LevelMap(Texture2D frajo)
        {
            random = new Random(264);
            
            mapita[0] = new MapObject(frajo, 10, 10, false, 1, 1, 2, 0, 0, 2);
            mapita[1] = new MapObject(frajo, 266, 10, false, 1, 1, 2, 0, 0, 2);
            mapita[2] = new MapObject(frajo, 522, 10, false, 1, 1, 2, 0, 0, 2);
            random2 = new Random();
            mapito[0] = new MapObject(frajo, 1162, 10, false, 1, 1, 2, 0, 0, 2);
            mapito[1] = new MapObject(frajo, 1418, 10, false, 1, 1, 2, 0, 0, 2);
            mapito[2] = new MapObject(frajo, 1674, 10, false, 1, 1, 2, 0, 0, 2);
            boneless = random.Next(0, 3);
            pizza = random2.Next(0, 3);

        }

        public void updata(Player p1)
        {
           
            if ( p1.placeHolder.destinationRectangle.Intersects(mapita[boneless].placeHolder.destinationRectangle)==false)
            {
                mapita[boneless].Update();
            }
            else
            {
                p1.monkaS--;
                p1.factorVelocity = 0.1f;
                mapita[boneless].positionY = 10;
                boneless = random.Next(0, 3);
            }
            if (mapita[boneless].positionY < 1080)
            {
                mapita[boneless].Update();
                mapita[boneless].factov= p1.factorVelocity;
            }
            else
            {
                mapita[boneless].positionY = 10;
                boneless = random.Next(0, 3);
            }
        }

        public void updato(Player p2)
        {
          

            if (  p2.placeHolder.destinationRectangle.Intersects(mapito[pizza].placeHolder.destinationRectangle) == false)
            {
                mapito[pizza].Update();
            }
            else
            {
                p2.monkaS--;
                p2.factorVelocity = 0.1F;
                mapito[pizza].positionY = 10;
                pizza = random.Next(0, 3);
            }
            if (mapito[pizza].positionY < 1080)
            {
                mapito[pizza].Update();
                mapito[pizza].factov = p2.factorVelocity;
            }
            else
            {
                mapito[pizza].positionY = 10;
                pizza = random.Next(0, 3);
            }
        }

        public void Draw (SpriteBatch spriteBatch) {
            mapita[boneless].Draw(spriteBatch);

            mapito[pizza].Draw(spriteBatch);

            }
    }
}
