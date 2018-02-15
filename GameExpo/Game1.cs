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
        private AnimatedSprite shipF1;
        private GamePadState controllerPlayer1;
        private GamePadState controllerPlayer2;
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
            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("SmileyWalk");// modificar la imagen por la del fzero u otro

            shipF1 = new AnimatedSprite(texture, 4, 4);

        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (controllerPlayer1.IsConnected & controllerPlayer2.IsConnected)
            {
                controllerPlayer1 = GamePad.GetState(PlayerIndex.One);// may cause perfomance or connecting propblems , need testing (migth remove in near future)
                controllerPlayer2 = GamePad.GetState(PlayerIndex.Two);//  ||   ||    ||   || 

                if (controllerPlayer1.DPad.Down == ButtonState.Pressed)
                {
                    // move
                }

                if (controllerPlayer1.Triggers.Left > 0)
                {
                    // accelerate
                }
            }

            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            shipF1.Update();
            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            shipF1.Draw(spriteBatch, new Vector2(400, 200));

            base.Draw(gameTime);
        }


    }
}
