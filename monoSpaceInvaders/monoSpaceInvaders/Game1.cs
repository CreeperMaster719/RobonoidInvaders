using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monoSpaceInvaders
{
    /// <summary>
    /// MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Projectile testProjectile;
        Invader testInvader;
        SpaceShip testSpaceShip;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 980;
            graphics.ApplyChanges();
            base.Initialize();
        }
        ///<summary>
        /// mmmMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM ohhhhhhhhhhhhhhhhhhhhhhHHHHHHHHHHHHHHHHHHHHHHH
        ///</summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D testTextureP = Content.Load<Texture2D>("Test_Projectile");
            Texture2D testTextureI = Content.Load<Texture2D>("Test_Invader");
            Texture2D testTextureS = Content.Load<Texture2D>("Test_Ship");
            Vector2 testPositionP = new Vector2(170, 650);
            Vector2 testPositionI = new Vector2(120, 50);
            Vector2 testPositionS = new Vector2(100, 820);
            Color testTintP = Color.White;
            Color testTintI = Color.White;
            Color testTintS = Color.White;
            testProjectile = new Projectile(testPositionP, testTextureP, testTintP);
            testInvader = new Invader(testPositionI, testTextureI, testTintI);
            testSpaceShip = new SpaceShip(testPositionS, testTextureS, testTintS);
            // TODO: use this.Content to load your game content here
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////hello i like to eat myself on stages of lol and froll plol flol tlolp holp i say tolp

        ///<summary>
        /// someBODY once told me
        ///</summary>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            testProjectile.Draw(spriteBatch);
            testSpaceShip.Draw(spriteBatch);
            testInvader.Draw(spriteBatch);
            //the middle will STAY the middle

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
