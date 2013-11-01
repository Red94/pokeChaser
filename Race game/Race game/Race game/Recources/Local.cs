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
using Race_game.Content.Screens;

namespace Race_game.Recources
{
    class Local
    {
        public static List<Rectangle> collisions;
        public static List<Vector2> waypoints;
        public static List<Texture2D> textures;
        public static ScreenManager screenManager;
    }
}
