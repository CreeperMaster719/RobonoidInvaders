using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoSpaceInvaders
{
    public class Sprite
    {
       public Vector2 position;
       public Texture2D texture;
       public Color tint;

        public Sprite(Vector2 vector2, Texture2D texture2D, Color color)
        {
            position = vector2;
            texture = texture2D;
            tint = color;
        }

        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, tint);
        }
    }
}
