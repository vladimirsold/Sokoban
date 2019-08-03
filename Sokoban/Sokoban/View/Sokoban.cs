using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using Sokoban.Controller;
using Sokoban.Model;
using Sokoban.View;
using System;
using GeonBit.UI;

namespace Sokoban
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Sokoban : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D TextureBackground { get; set; }
        ContentLoader ContentLoader { get; set; }
        private Settings settings;
        GameScene gameScene;
        MainMenu mainMenu;
        Pause pause;
        IScene currentScene;
        public Sokoban()
        {
            graphics = new GraphicsDeviceManager(this);

            //IsMouseVisible = true;
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
            TextureBackground = Content.Load<Texture2D>("background");
            ContentLoader = new ContentLoader(Content);
            pause = new Pause(Content);
            mainMenu = new MainMenu(Content);
            gameScene = new GameScene(graphics, ContentLoader, settings);          
            mainMenu.StartButtonPressed += () =>
            {

                currentScene = gameScene;
            };
            mainMenu.ExitButtonPressed += Exit;
            pause.ContinueButtonPressed += () => currentScene = gameScene;
            pause.MainMenuButtonPressed += mainMenu.CallMenu;
            currentScene = mainMenu;
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
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if(currentScene is GameScene)
                {
                    pause.CallPause();
                    currentScene = pause;
                }
            }
            currentScene.Update(gameTime);
            base.Update(gameTime);
            UserInterface.Active.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(TextureBackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.End();
            currentScene.Draw(spriteBatch);
            UserInterface.Active.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
