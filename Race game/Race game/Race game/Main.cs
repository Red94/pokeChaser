using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Race_game.Recources;
using Race_game.Content.Screens;

namespace Race_game
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ScreenManager screenManager;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            this.Window.Title = "Poke Chaser";
            Content.RootDirectory = "Content";

            Globals.contentManager = Content;
            Globals.graphics = graphics;

            Globals.ScreenHeight = 500;
            Globals.ScreenWidth = 500;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.graphicsDevice = GraphicsDevice;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            screenManager = new ScreenManager();
            screenManager.CreateScreen(new StartScreen());
            Local.screenManager = screenManager;
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            screenManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tomato);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            screenManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
