using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameExpo
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private float frameRate;
        private GamePadState controllerPlayer1;
        private GamePadState controllerPlayer2;
         private AnimatedSprite a;
        private Player P1;
        private Player P2;
        private LevelMap world1;
        private Texture2D road1;
        private Texture2D road2;
        private bool started;
        private bool paused;
        // musica 


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            controllerPlayer1 = GamePad.GetState(PlayerIndex.One);
            controllerPlayer2 = GamePad.GetState(PlayerIndex.Two);
            paused = true;
            started = false;
            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
           road1 = Content.Load<Texture2D>("Road");
           road2 = Content.Load<Texture2D>("Road");
            P1 = new Player(Content.Load<Texture2D>("spaceship1"),30,900);
            P2 = new Player(Content.Load<Texture2D>("spaceship1"),900,900);
        
        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit(); // se sale del juego
            }
           

            if (Keyboard.GetState().IsKeyDown(Keys.S)&&paused==true)// Hacer Start el juego y animacion de salida
            {
                paused = false;
                started = true;
               
            }

            if (Keyboard.GetState().IsKeyDown(Keys.P) && started == true)
            {
                paused = true;
                started = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                //metodo que rezetea todo el juego
            }

            if (started)
            {
                P1.placeHolder.Update();
                P2.placeHolder.Update();
                if (controllerPlayer1.IsConnected & controllerPlayer2.IsConnected)
                {
                    P1.placeHolder.Update();
                    P2.placeHolder.Update();
                    // level map update adentro se hace update de map objects
                    P1.Input();
                    P2.Input();
                }
                else
                {
                    paused = true;
                    started = false;
                }   
            }

            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
          
            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            
            spriteBatch.Begin();
            spriteBatch.Draw(road1, new Rectangle(0,0, 768, GraphicsDevice.DisplayMode.Height), Color.PaleTurquoise);
            spriteBatch.Draw(road1, new Rectangle(1152, 0, 768, GraphicsDevice.DisplayMode.Height), Color.PaleVioletRed);
            spriteBatch.End();
            P1.Draw(spriteBatch);
            P2.Draw(spriteBatch);
            // world1. metodo para imprimir todos los objetos
            base.Draw(gameTime);
        }


    }
}
