using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace monoSpaceInvaders
{
    /// <summary>
    /// MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW MEME REVIEW
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;        
        Invader testInvader;
        SpaceShip testSpaceShip;
        KeyboardState keyboard;
        KeyboardState preKeyboard;
        int numberOfRows = 16;
        int numberOfInvaders = 80;
        List<Invader> invaders;
        SpriteFont font;
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

            invaders = new List<Invader>();

            base.Initialize();
        }
        ///<summary>
        /// mmmMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM ohhhhhhhhhhhhhhhhhhhhhhHHHHHHHHHHHHHHHHHHHHHHH
        ///</summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            Texture2D testTextureP = Content.Load<Texture2D>("Test_Projectile");
            Texture2D testTextureI = Content.Load<Texture2D>("Test_Invader");
            Texture2D testTextureS = Content.Load<Texture2D>("Test_Ship");
            Vector2 testPositionP = new Vector2(-100, -100);
            Vector2 testPositionI = new Vector2(120, 50);
            Vector2 testPositionS = new Vector2(100, 820);
            Color testTintP = Color.White;
            Color testTintI = Color.White;
            Color testTintS = Color.White;            
            testInvader = new Invader(testPositionI, testTextureI, testTintI);
            testSpaceShip = new SpaceShip(testPositionS, testTextureS, testTintS, testTextureP, 1000);            
            for(int i = 0; i < numberOfRows; i++)
            {
                for(int j = 0; j < numberOfInvaders / numberOfRows; j++)
                {
                    Vector2 vector2 = new Vector2((j * 128), 30 * i);

                    invaders.Add(new Invader(vector2, testTextureI, testTintI));
                }
                
            }
            // TODO: use this.Content to load your game content here
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////hello i like to eat myself on stages of lol and froll plol flol tlolp holp i say tolp

        ///<summary>
        /// someBODY once told me the wORLD was gonna roll me
        ///</summary>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            preKeyboard = keyboard;
            keyboard = Keyboard.GetState();
            // TODO: Add your update logic here
            testSpaceShip.Update(GraphicsDevice.Viewport, gameTime, 2, keyboard, preKeyboard, invaders);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            testSpaceShip.Draw(spriteBatch);
            //testInvader.Draw(spriteBatch);
            spriteBatch.DrawString(font, $"{testSpaceShip.startFuel}", new Vector2(testSpaceShip.position.X + 10, testSpaceShip.position.Y + 10), Color.Black);
            //the middle will STAY the middle
            for(int i = 0; i < invaders.Count; i++)
            {
                invaders[i].Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
