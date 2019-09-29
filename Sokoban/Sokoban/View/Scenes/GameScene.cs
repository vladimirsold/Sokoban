using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban;
using Sokoban.Controller;
using Sokoban.Model;

namespace Sokoban.View.Scenes
{
    class GameScene : IScene
    {

        private  Field field;
        private readonly GameModel gameModel;
        //public readonly GameProcessUIController uiController;
        private readonly Dictionary<TextureID, Texture2D> textureBlocks;
        private readonly SpriteFont font;
        private readonly GraphicsDeviceManager graphics;
        private readonly KeyboardController keyboardController = new KeyboardController();

        public GameScene(GraphicsDeviceManager graphics, LoadedContent content, GameModel gameModel)
        {

            textureBlocks = content.BlocksTextures;
            font = content.Font;
            this.graphics = graphics;
            this.gameModel = gameModel;
            gameModel.LevelLoaded += () =>
            {
                field = new Field(gameModel.GetAllGameObjects(), gameModel.SizeOfStoreroom, textureBlocks);
                field.Init(new Point(40, 60), new Point(graphics.PreferredBackBufferWidth - 80, graphics.PreferredBackBufferHeight - 120));
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, $"Steps:{gameModel.Steps}", new Vector2(40,30), Color.Black);
            spriteBatch.DrawString(font, $"Time {gameModel.TimeSpan.ToString("mm\\:ss")}", new Vector2(200, 30), Color.Black);
            spriteBatch.End();
            field.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            keyboardController.KeyPressHandler(gameModel);
        }
    }
}
