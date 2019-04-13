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
        public Invader(Vector2 vector2, Texture2D texture2D, Color color, float direction)
: base(vector2, texture2D, color)
        {
            this.direction = direction;
            Random random = new Random();
            duration = random.Next(500, 1000);
        }

        

    }
}
