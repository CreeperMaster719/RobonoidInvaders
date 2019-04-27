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
    class Invader : Sprite
    {
        public float direction;
        public int duration;
        public TimeSpan meanEnemy = TimeSpan.Zero;
        public bool canShoot = false;

        public Invader(Vector2 vector2, Texture2D texture2D, Color color, float direction)
            : base(vector2, texture2D, color)
        {
            this.direction = direction;
            Random random = new Random();




        }

        public void Update(GameTime gameTime, Random random)
        {
            meanEnemy += gameTime.ElapsedGameTime;
            duration = random.Next(5000, 10000);

        }
    }
}
