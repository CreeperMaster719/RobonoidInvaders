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

        TimeSpan shootTime = TimeSpan.FromMilliseconds(500);
        TimeSpan elaspedShootTime = TimeSpan.Zero;

        public int startFuel = 0;

        public SpaceShip(Vector2 vector2, Texture2D texture2D, Color color, Texture2D projectileImage, int startingFuel)
            : base(vector2, texture2D, color)
        {
            this.projectileImage = projectileImage;
            startFuel = startingFuel;
        }        


        public void Update(Viewport viewport, GameTime gameTime, int speed, KeyboardState keyboard, KeyboardState preKeyboard, List<Invader> invaders)
        {          
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
                projectiles.Add(new Projectile(position, projectileImage, Color.White));
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
                        if (invaders[j].HitBox.Intersects(projectiles[i].HitBox))
                        {
                            //  exit = true;
                            projectiles.RemoveAt(i);
                            invaders.RemoveAt(j);
                           
                            break;
                        }
                    }
                }


                //if (exit)
                //{
                //    break;
                //}
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }

    }
}
