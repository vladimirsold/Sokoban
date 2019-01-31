using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sokoban
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Sokoban : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Texture { get; set; }
        Controller controller;
        View view;
        Dictionary<TextureID, Texture2D> textureBlocks;
        KeyboardController keyboardController;
        Model model;
        public Sokoban()
        {
            graphics = new GraphicsDeviceManager(this);
            model = new Model();
            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1200;
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
            
            keyboardController = new KeyboardController();
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
            Texture = Content.Load<Texture2D>("background");
            textureBlocks = new Dictionary<TextureID, Texture2D>
            {
                [TextureID.Wall] = Content.Load<Texture2D>("Blocks/block_05"),
                [TextureID.PlayerTurnedForward] = Content.Load<Texture2D>("Player/Forward"),
                [TextureID.PlayerTurnedBackward] = Content.Load<Texture2D>("player/Backward"),
                [TextureID.PlayerTurnedLeft] = Content.Load<Texture2D>("Player/Left"),
                [TextureID.PlayerTurnedRight] = Content.Load<Texture2D>("Player/Right"),
                [TextureID.Box] = Content.Load<Texture2D>("Crates/crate_09"),
                [TextureID.EmptyCell] = Content.Load<Texture2D>("Crates/crate_29"),
                [TextureID.CellWithBox] = Content.Load<Texture2D>("Crates/crate_44")
            };
            model.LoadLevel(12);
            view = new View(model);
            view.LoadTextureBlocks(textureBlocks);
            controller = new Controller(model);

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
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            keyboardController.KeyPressHandler(controller);
            model.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            view.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
