﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monoSpaceInvaders
{
    class Projectile : Sprite
    {
        public int speed = 1;
        public Projectile(Vector2 vector2, Texture2D texture2D, Color color)
            : base(vector2, texture2D, color) { }

        public virtual void Update()
        {
            position.Y -= 5 * speed;
        }

    }
}
