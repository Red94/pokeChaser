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
using Race_game.Recources;

namespace Race_game.Content.EnemyClass
{
    class Enemy : Sprite
    {
        public float speed;
        float elapsed;
        public Enemy(Texture2D texture, Vector2 position,float speed) : base(texture, position)
        {
            //animation
            totalFrame = 2;
            interval = 200;
            interspace = 1;
            this.speed = speed;
            srcRect = new Rectangle(0, 0, 30, 30);

            //collision
            hitTest = new Rectangle(0, 0, 30, 30);
        }

        public override void Update(GameTime gameTime)
        {
            elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            UpdatePichuMovement(gameTime);
        }

        public void UpdatePichuMovement(GameTime gameTime)
        {
            Console.WriteLine("sdjf");
            Vector2 point;

            if(Local.waypoints.Count > 1)
                point = Local.waypoints[1];
            else
                point = Local.waypoints[0];


            if (!(Vector2.Distance(position, point) < speed * elapsed))
            {
                float direction = (float)Math.Atan2(-(position.Y - point.Y), -(position.X - point.X));

                direction = MathHelper.ToDegrees(direction);

                position.X += (float)Math.Cos(direction * (Math.PI / 180)) * speed * elapsed;
                position.Y += (float)Math.Sin(direction * (Math.PI / 180)) * speed * elapsed;
            }
            else
            {
                position = point;

                if (Local.waypoints.Count > 1)
                    Local.waypoints.Remove(point);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
