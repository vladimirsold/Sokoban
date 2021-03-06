﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.View.Scenes;

namespace Sokoban.View
{ 
    public class SokobanGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        LoadedContent loadedContent;
        Settings settings;
        SceneManager scenes;


        public SokobanGame()
        {
            graphics = new GraphicsDeviceManager(this);
            settings = Settings.GetSettings();
            LoadSettings(settings);
        }

        private void LoadSettings(Settings settings)
        {
            graphics.PreferredBackBufferHeight = settings.HeightWindow;
            graphics.PreferredBackBufferWidth = settings.WidthWindow;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {  
            Content.RootDirectory = "Content";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            loadedContent = new LoadedContent(Content);
            scenes = new SceneManager(Content, loadedContent, graphics);
            scenes.Exit += Exit;
            //MediaPlayer.Play(loadedContent.BackgroundMusic);
            //MediaPlayer.IsRepeating = true;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
           
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            scenes.Update(gameTime);
            base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            scenes.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
