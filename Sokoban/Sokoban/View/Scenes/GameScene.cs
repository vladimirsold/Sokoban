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

namespace View.Scenes
{
    class GameScene : IScene
    {

        private readonly Field field;
        private readonly GameModel gameModel;
        public readonly GameProcessUIController uiController;
        private readonly Dictionary<TextureID, Texture2D> textureBlocks;
        private readonly SpriteFont font;
        private readonly GraphicsDeviceManager graphics;
        private readonly KeyboardController keyboardController = new KeyboardController();

        public GameScene(GraphicsDeviceManager graphics, LoadedContent content)
        {

            textureBlocks = content.BlocksTextures;
            font = content.Font;
            this.graphics = graphics;
            gameModel = new GameModel();
            uiController = new GameProcessUIController(gameModel);
            uiController.LoadLevel(new Level(Series.ThinkingRabbitOriginal, 0));
            field = new Field(gameModel, textureBlocks, graphics);
            gameModel.LevelCompleted += field.Update;             
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
            gameModel.Update();
            keyboardController.KeyPressHandler(gameModel);
        }
    }
}
