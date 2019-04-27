using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
        int numberOfRows = 5;
        int numberOfInvaders = 50;
        float invaderDirection = 1;
        Random random = new Random();
        List<Texture2D> invaderTextures;
        int randomNumber;
        List<Invader> invaders;
        List<Texture2D> IProjectileTextures;
        SpriteFont font;
        Texture2D invaderStyle2;
        Texture2D invaderStyle1;
        Texture2D background;
        Texture2D InvaderProjectile1;
        Texture2D InvaderProjectile2;
        SoundEffect losesong;
        Texture2D winCondition;

        int invadersEliminated = 0;
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
            invaderTextures = new List<Texture2D>();
            IProjectileTextures = new List<Texture2D>();
            Texture2D testTextureP = Content.Load<Texture2D>("pearlspear");
            Texture2D testTextureI = Content.Load<Texture2D>("Test_Invader");
            Texture2D testTextureS = Content.Load<Texture2D>("ship");
            background = Content.Load<Texture2D>("DEEP PERIDOT");
            winCondition = Content.Load<Texture2D>("wincondition");
            invaderTextures.Add (invaderStyle1 = Content.Load<Texture2D>("invader"));
            invaderTextures.Add (invaderStyle2 = Content.Load<Texture2D>("invader2"));
            IProjectileTextures.Add (InvaderProjectile1 = Content.Load<Texture2D>("I_Projectile_1"));
            IProjectileTextures.Add (InvaderProjectile2 = Content.Load<Texture2D>("I_Projectile_2"));
            Vector2 testPositionP = new Vector2(-100, -100);
            Vector2 testPositionI = new Vector2(120, 50);
            Vector2 testPositionS = new Vector2(100, 820);
            Color testTintP = Color.White;
            Color testTintI = Color.White;
            Color testTintS = Color.White;
            losesong = Content.Load<SoundEffect>("losesong");
            testInvader = new Invader(testPositionI, testTextureI, testTintI, invaderDirection);
            testSpaceShip = new SpaceShip(testPositionS, testTextureS, testTintS, testTextureP, 10000, IProjectileTextures, winCondition);            
            for(int i = 0; i < numberOfRows; i++)
            {
                for(int j = 0; j < numberOfInvaders / numberOfRows; j++)
                {
                    if(randomNumber == 0)
                    {
                        randomNumber = 1;
                    }
                    else
                    {
                        randomNumber = 0;
                    }
                    Vector2 vector2 = new Vector2(((j - 1) * 128), 100 * i);

                    invaders.Add(new Invader(vector2, invaderTextures[randomNumber], testTintI, invaderDirection));
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
            for(int i = 0; i < invaders.Count; i++)
            {
                invaders[i].Update(gameTime, random);
            }
            if(testSpaceShip.frozen == 0)
            {
                testSpaceShip.Update(GraphicsDevice.Viewport, gameTime, 2, keyboard, preKeyboard, invaders, invaderTextures, invaderDirection, losesong, winCondition);
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            if (testSpaceShip.frozen == 1)
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
            }
            
            testSpaceShip.Draw(spriteBatch);
            //testInvader.Draw(spriteBatch);
            spriteBatch.DrawString(font, $"{testSpaceShip.startFuel}", new Vector2(testSpaceShip.position.X + 10, testSpaceShip.position.Y + 10), Color.Black);
            spriteBatch.DrawString(font, $"{testSpaceShip.totalEliminations}", new Vector2(200,300), Color.Black);
            //the middle will STAY the middle
            for (int i = 0; i < invaders.Count; i++)
            {
                invaders[i].Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
