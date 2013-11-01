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
using Race_game.Content.PlayerClass;
using Race_game.Content.EnemyClass;

namespace Race_game.Content.Screens
{
    class GameScreen : Screen
    {
        Grid grid;
        Player player;
        Enemy pokemon;
        Texture2D background;
        float timer;
        int currentEnemy;

        public GameScreen()
        {
            player = new Player(new Vector2(250, 425));
            pokemon = new Enemy(Assets.enemy, new Vector2(250,480), 130);

            Local.waypoints = new List<Vector2>();
            Local.waypoints.Add(player.position);

            Local.textures = new List<Texture2D>();
            Local.textures.Add(Assets.enemy);
            Local.textures.Add(Assets.enemy2);
            Local.textures.Add(Assets.enemy3);
            Local.textures.Add(Assets.enemy4);
            Local.textures.Add(Assets.enemy5);

            background = Assets.background;

            grid = new Grid();
            grid.createLevel(0);
        }

        public override void Update(GameTime gameTime)
        {
            ScreenUpdate();
            player.Update(gameTime);

            Local.waypoints[0] = player.position;

            
            if (currentEnemy < 4)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer >= 10000)
                {
                    timer = 0;
                    currentEnemy++;
                    pokemon = new Enemy(Local.textures[currentEnemy], pokemon.position, pokemon.speed + 20);
                }
            }
            pokemon.Update(gameTime);
        }

        public void ScreenUpdate()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background,new Vector2(0,0),Color.White);
            player.Draw(spriteBatch);
            /*foreach (Vector2 pos in Local.waypoints)
           {
                Waypoint wp = new Waypoint(pos);
                wp.Draw(spriteBatch);
                }*/
            pokemon.Draw(spriteBatch);
            grid.Draw(spriteBatch);
        }
    }
}
