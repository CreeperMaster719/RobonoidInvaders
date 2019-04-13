using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoSpaceInvaders
{
    class SpaceShip : Sprite
    {
        List<Projectile> projectiles = new List<Projectile>();
        Texture2D projectileImage;
        int randomNumber = 0;
        TimeSpan shootTime = TimeSpan.FromMilliseconds(500);
        TimeSpan elaspedShootTime = TimeSpan.Zero;
        TimeSpan meanEnemies = TimeSpan.Zero;
        bool hasThingHappened = false;
        List<Texture2D> ITextures;
        int numberOfRows = 5;
        int numberEliminated = 0;
        List<Projectile> IProjectiles = new List<Projectile>();
        public int frozen = 0;
        float set = 0;
        Random random = new Random();
        float levelMultiplier = 1;
        int numberOfInvaders = 10;
        public int totalEliminations = 0;
        public int startFuel = 0;

        public SpaceShip(Vector2 vector2, Texture2D texture2D, Color color, Texture2D projectileImage, int startingFuel, List<Texture2D> ITextures)
            : base(vector2, texture2D, color)
        {
            this.projectileImage = projectileImage;
            this.ITextures = ITextures;
            startFuel = startingFuel;
        }        


        public void Update(Viewport viewport, GameTime gameTime, int speed, KeyboardState keyboard, KeyboardState preKeyboard, List<Invader> invaders,List<Texture2D> invaderTextures, float invaderDirection)
        {      
            //~~~~~~~~~~~~~~~~~~~~Controls~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            if (keyboard.IsKeyDown(Keys.A) && startFuel > 0)
            {
                position.X -= 5 * speed;
                startFuel -= 1;
            }
            else if (keyboard.IsKeyDown(Keys.D) && startFuel > 0)
            {
                position.X += 5 * speed;
                startFuel -= 1;
            }

            if (keyboard.IsKeyDown(Keys.Space) && preKeyboard.IsKeyUp(Keys.Space))
            {
                elaspedShootTime = TimeSpan.Zero;
                projectiles.Add(new Projectile(new Vector2(position.X + (float)(texture.Width * (3/4)), position.Y - texture.Height), projectileImage, Color.White));
            }
            else if (keyboard.IsKeyDown(Keys.Space))
            { 
                elaspedShootTime += gameTime.ElapsedGameTime;

                if (elaspedShootTime >= shootTime)
                {
                    elaspedShootTime = TimeSpan.Zero;
                    projectiles.Add(new Projectile(position, projectileImage, Color.White));
                }
            }
            else if(keyboard.IsKeyDown(Keys.C))
            {
                projectiles.Add(new Projectile(position, projectileImage, Color.White));
            }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Invader Projectile Collision~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            
            
            for (int i = 0; i <projectiles.Count; i++)
            {
                projectiles[i].Update();
                
                if (projectiles[i].position.Y <= 0)
                {
                    projectiles.RemoveAt(i);
                }
                // bool exit = false;
                if(invaders.Count > 0 && projectiles.Count > 0)
                {
                    for (int j = 0; j < invaders.Count; j++)
                    {
                        if(projectiles.Count > 1)
                        {
                            if (invaders[j].HitBox.Intersects(projectiles[i].HitBox))
                            {
                                //  exit = true;
                                projectiles.RemoveAt(i);
                                invaders.RemoveAt(j);
                                startFuel += 50;
                                numberEliminated += 1;
                                totalEliminations += 1;
                                break;
                            }
                        }

                    }
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~Speed Up and Respawn~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
            if(invaders.Count <= 40)
            {
                levelMultiplier *= (float)1.01;
                
                if (numberEliminated > 9)
                {
                    for (int i = 0; i < numberOfRows; i++)
                    {
                        for (int j = 0; j < numberOfInvaders / numberOfRows; j++)
                        {
                            if (randomNumber == 0)
                            {
                                randomNumber = 1;
                            }
                            else
                            {
                                randomNumber = 0;
                            }
                            Vector2 vector2 = new Vector2((j * 128), 100 * i);

                            invaders.Add(new Invader(vector2, invaderTextures[randomNumber], Color.White, invaderDirection));
                            invaders[j].direction = set;
                        }

                    }
                    numberEliminated -= 10;
                }
                hasThingHappened = true;
            }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~Invader Movement~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            for(int i = 0; i < invaders.Count(); i++)
            {
                if(hasThingHappened)
                {
                  invaders[i].direction *= levelMultiplier;
                    set = Math.Abs(invaders[i].direction);  
                }
            }
            hasThingHappened = false;

            for (int i = 0; i < invaders.Count(); i++)
            {
                if(invaders[i].position.X + invaders[i].texture.Width >= viewport.Width)
                {
                    invaders[i].direction = -Math.Abs(invaders[i].direction * 1.1f);
                    invaders[i].position.Y += 20;
                    invaders[i].position.X = viewport.Width - (5 + invaders[i].texture.Width);
                }
                else if(invaders[i].position.X <= 0)
                {
                    invaders[i].direction = Math.Abs(invaders[i].direction *1.1f);
                    invaders[i].position.Y += 20;
                    invaders[i].position.X = 5;
                }
                else
                {
                    invaders[i].position.X += 2 * invaders[i].direction;
                }
                if (invaders[i].duration < meanEnemies.TotalMilliseconds)
                {
                    IProjectiles.Add (new Projectile(invaders[i].position, ITextures[random.Next(0,2)], Color.White));

                    for (int j = 0; j < IProjectiles.Count(); j++)
                    {
                       // IProjectiles[i].speed = -1;
                        meanEnemies = TimeSpan.Zero;
                    }
                }

                    //~~~~~~~~~~~~~~~~~~Game End~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    if (invaders[i].position.Y > viewport.Height)
                {
                    invaders.RemoveAt(i);
                    frozen =1;
                }
                //~~~~~~~~~~~~~~~~~~~~~~~Invader Projectile Movement and Fuel Reduction~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
            for (int j = 0; j < IProjectiles.Count; j++)
            {
                IProjectiles[j].Update();
                IProjectiles[j].speed = -1;
                if (IProjectiles[j].position.Y >= viewport.Height)
                {
                    IProjectiles.RemoveAt(j);
                    
                }
                if(IProjectiles.Count > 0)
                {
                    if (IProjectiles[j].HitBox.Intersects(HitBox))
                    {
                        startFuel -= 1000;
                        IProjectiles.RemoveAt(j);
                    }
                }

            }
            meanEnemies += gameTime.ElapsedGameTime;
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(spriteBatch);
            }
            for (int i = 0; i < IProjectiles.Count; i++)
            {
                IProjectiles[i].Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }

    }
}
