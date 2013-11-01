using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Race_game.Recources
{
    class Waypoint : Sprite
    {
        public Waypoint(Vector2 position)
            : base(Assets.CreateRectangle(new Rectangle(0,0,8,8),Color.White), position)
        {
            origin = new Vector2(4, 4);
        }

    }
}
