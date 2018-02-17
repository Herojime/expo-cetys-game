using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
        private Texture2D Lose;
        private Texture2D Win;
        private bool started;
        private bool paused;
        public bool endGame;
        public SpriteFont puto;
        protected Song song;

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
            endGame = false;
           
            base.Initialize();
        }


        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            puto = Content.Load<SpriteFont>("Puntuacion");
            road1 = Content.Load<Texture2D>("Road");
           road2 = Content.Load<Texture2D>("Road");
            Win = Content.Load<Texture2D>("You Win");
            Lose = Content.Load<Texture2D>("Game Over");
            P1 = new Player(Content.Load<Texture2D>("spaceship1"),330,900);
            P2 = new Player(Content.Load<Texture2D>("spaceship1"),1480,900);
            world1 = new LevelMap(Content.Load<Texture2D>("spikeballlj3"));
             song = Content.Load<Song>("Dream Chaser");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            controllerPlayer1 = GamePad.GetState(PlayerIndex.One);
            controllerPlayer2 = GamePad.GetState(PlayerIndex.Two);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit(); // se sale del juego
            }
           

            if (controllerPlayer1.Buttons.A==ButtonState.Pressed&&paused==true || controllerPlayer2.Buttons.A == ButtonState.Pressed && paused == true)// Hacer Start el juego y animacion de salida
            {
                paused = false;
                started = true;
               
            }

            if (Keyboard.GetState().IsKeyDown(Keys.P) && started == true)
            {
                paused = true;
                started = false;
            }

            if (controllerPlayer1.Buttons.B == ButtonState.Pressed || controllerPlayer2.Buttons.B == ButtonState.Pressed && paused == true)
            {
                //metodo que rezetea todo el juego
                endGame = false;
                paused = true;
                started = false;
                P1 = new Player(Content.Load<Texture2D>("spaceship1"), 330, 900);
                P2 = new Player(Content.Load<Texture2D>("spaceship1"), 1480, 900);
                world1 = new LevelMap(Content.Load<Texture2D>("spikeballlj3"));

            }

            if (started )
            {

                controllerPlayer1 = GamePad.GetState(PlayerIndex.One);
                controllerPlayer2 = GamePad.GetState(PlayerIndex.Two);

                if (controllerPlayer1.IsConnected&& controllerPlayer2.IsConnected)
                {
                P1.placeHolder.Update();
                    P2.placeHolder.Update();
                
                    world1.updata(P1);
                    world1.updato(P2);



                    // level map update adentro se hace update de map objects
                    P1.Input(controllerPlayer1);
                    P2.Input(controllerPlayer2);
                  }
                
                  else
                  {
                      paused = true;
                      started = false;
                  }  

                if (P1.monkaS==0)
                {
                    started = false;
                    endGame = true;
                }
                if (P2.monkaS==0)
                {
                    started = false;
                    endGame = true;
                }

                P1.Puntuacion += gameTime.ElapsedGameTime.Milliseconds * P1.factorVelocity ;
                P2.Puntuacion += gameTime.ElapsedGameTime.Milliseconds * P2.factorVelocity;
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
            spriteBatch.DrawString(puto, "Puntuacion de Player1 : \n" + P1.Puntuacion/100, new Vector2( 778, 15), Color.Black);
            spriteBatch.DrawString(puto, "\n Puntuacion de Player2 : \n" + P2.Puntuacion / 100, new Vector2(778, 750), Color.Black);

            spriteBatch.DrawString(puto, "\n Vidas Player1 : \n" + P1.monkaS , new Vector2(778, 85), Color.Black);
            spriteBatch.DrawString(puto, "\n Vidas Player2 : \n" + P2.monkaS , new Vector2(778, 820), Color.Black);

            spriteBatch.End();
            P1.Draw(spriteBatch,Color.White);
            P2.Draw(spriteBatch,Color.Yellow);

            world1.Draw(spriteBatch);

            spriteBatch.Begin();
            if (endGame)
            {
                if (P1.Puntuacion > P2.Puntuacion)
                {
                    spriteBatch.Draw(Win, new Rectangle(0, 0, 768, GraphicsDevice.DisplayMode.Height), Color.White);
                    spriteBatch.Draw(Lose, new Rectangle(1152, 0, 768, GraphicsDevice.DisplayMode.Height), Color.White);
                }
                else
                {
                    spriteBatch.Draw(Lose, new Rectangle(0, 0, 768, GraphicsDevice.DisplayMode.Height), Color.White);
                    spriteBatch.Draw(Win, new Rectangle(1152, 0, 768, GraphicsDevice.DisplayMode.Height), Color.White);
                }
            }
            spriteBatch.End();
            // world1. metodo para imprimir todos los objetos
            base.Draw(gameTime);
        }


    }
}
