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

namespace Race_game.Content.PlayerClass
{
    class Player : Sprite
    {
        private KeyboardState newKeyState, oldKeyState;
        private Keys leftKey, rightKey, upKey, downKey;
        private Vector2 direction;
        private float speed;

        public bool isOnLeft
        {
            get { return position.X < 0; }
        }

        public bool isOnRight
        {
            get { return position.X > 500; }
        }

        public bool isOnUp
        {
            get { return position.Y < 0; }
        }

        public bool isOnDown
        {
            get { return position.Y > 500; }
        }

        public Player(Vector2 position) : base(Assets.player, position)
        {
            //animation
            totalFrame = 2;
            interval = 200;
            interspace = 0;
            srcRect = new Rectangle(0, 0, 32, 32);
            
            //collision
            hitTest = new Rectangle(0, 0, 32, 32);
            
            //speed
            direction = new Vector2(0, -1);
            speed = 3;
            
            //keys
            leftKey = Keys.Left;
            rightKey = Keys.Right;
            upKey = Keys.Up;
            downKey = Keys.Down;
        }

        public override void Update(GameTime gameTime)
        {
            newKeyState = Keyboard.GetState();

            UpdateMovement(gameTime);

            hitTest.X = (int)position.X;
            hitTest.Y = (int)position.Y;

            UpdateColission();

            oldKeyState = newKeyState;
        }

        public void UpdateMovement(GameTime gameTime)
        {

            if (newKeyState.IsKeyDown(leftKey) && oldKeyState.IsKeyUp(leftKey) && direction.X != 1)
            {
                direction.X = -1;
                direction.Y = 0;

                Local.waypoints.Add(position);
                
                animation = 3;
                base.Update(gameTime);
            }
            else if (newKeyState.IsKeyDown(rightKey) && oldKeyState.IsKeyUp(rightKey) && direction.X != -1)
            {
                direction.X = 1;
                direction.Y = 0;

                Local.waypoints.Add(position);

                animation = 4;
                base.Update(gameTime);
            }
            else if (newKeyState.IsKeyDown(upKey) && oldKeyState.IsKeyUp(upKey) && direction.Y != 1)
            {
                direction.X = 0;
                direction.Y = -1;

                Local.waypoints.Add(position);

                animation = 2;
                base.Update(gameTime);
            }
            else if (newKeyState.IsKeyDown(downKey) && oldKeyState.IsKeyUp(downKey) && direction.Y != -1)
            {
                direction.X = 0;
                direction.Y = 1;

                Local.waypoints.Add(position);

                animation = 1;
                base.Update(gameTime);
            }

            position.X += speed * direction.X;
            position.Y += speed * direction.Y;
        }

        public void UpdateColission()
        {
            foreach (Rectangle rect in Local.collisions)
            {
                if (hitTest.isOnLeft(rect, speed))
                {
                    position.X = rect.Left - hitTest.Width;
                    hitTest.X = rect.Left - hitTest.Width;
                }

                if (hitTest.isOnRight(rect, speed))
                {
                    position.X = rect.Right;
                    hitTest.X = rect.Right;
                }
            }

            foreach (Rectangle rect in Local.collisions)
            {
                if (hitTest.isOnTopOf(rect, speed))
                {
                    position.Y = rect.Top - hitTest.Height;
                    hitTest.Y = rect.Top - hitTest.Height;
                }

                if (hitTest.isUnder(rect, speed))
                {
                    position.Y = rect.Bottom;
                    hitTest.Y = rect.Bottom;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
