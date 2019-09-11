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

namespace View
{
    class GameScene : IScene
    {

        private Field field;
        private GameModel gameModel;
        private Dictionary<TextureID, Texture2D> textureBlocks;
        private readonly SpriteFont font;
        private readonly Settings settings;
        private readonly GraphicsDeviceManager graphics; 
        private KeyboardController keyboardController = new KeyboardController();
        internal MainMenu currentScene;

        public GameScene(GraphicsDeviceManager graphics, ContentLoader content, Settings settings, GameModel gameModel)
        {
            this.settings = settings; 
            textureBlocks = content.TextureBlocks;
            font = content.Font;
            this.graphics = graphics;
            this.gameModel = gameModel;
            this.gameModel.LevelCompleted += () => field = new Field(this.gameModel, textureBlocks, graphics, settings.DefaultBlockSize);
            field = new Field(this.gameModel, textureBlocks, graphics, settings.DefaultBlockSize); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, $"Steps:{gameModel.Steps}", Vector2.Zero, Color.Black);
            spriteBatch.DrawString(font, $"Time {gameModel.TimeSpan.ToString("mm\\:ss")}", new Vector2(200, 0), Color.Black);
            spriteBatch.End();
            field.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            gameModel.Update();
            keyboardController.KeyPressHandler(gameModel);
        }

        internal void Start()
        {
            throw new NotImplementedException();
        }
    }
}
