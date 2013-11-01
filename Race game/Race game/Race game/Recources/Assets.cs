using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Race_game.Recources
{
    class Assets
    {
        public static Texture2D player = Globals.contentManager.Load<Texture2D>("player");
        public static Texture2D enemy = Globals.contentManager.Load<Texture2D>("pichu");
        public static Texture2D enemy2 = Globals.contentManager.Load<Texture2D>("sparrow");
        public static Texture2D enemy3 = Globals.contentManager.Load<Texture2D>("growlight");
        public static Texture2D enemy4 = Globals.contentManager.Load<Texture2D>("electrode");
        public static Texture2D enemy5 = Globals.contentManager.Load<Texture2D>("dodrio");
        public static Texture2D background = Globals.contentManager.Load<Texture2D>("background");
        public static Texture2D startBackground = Globals.contentManager.Load<Texture2D>("StartBG");

        public static Texture2D CreateRectangle(Rectangle rect, Color color)
        {
            if (rect.Width <= 0)
                rect.Width = 1;
            if (rect.Height <= 0)
                rect.Height = 1;

            Texture2D tex = new Texture2D(Globals.graphicsDevice, rect.Width, rect.Height);
            Color[] data = new Color[rect.Width * rect.Height];

            for (int i = 0; i < data.Length; i++)
                data[i] = color;

            tex.SetData(data);

            return tex;
        }
    }
}
