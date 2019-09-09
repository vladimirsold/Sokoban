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
        private GameProcess gameProcess;
        private Dictionary<TextureID, Texture2D> textureBlocks;
        private readonly SpriteFont font;
        private readonly Settings settings;
        private readonly GraphicsDeviceManager graphics;
        private GameProcessController controller;      
        private KeyboardController keyboardController;

        public GameScene(GraphicsDeviceManager graphics, ContentLoader content, Settings settings)
        {
            this.settings = settings; 
            textureBlocks = content.TextureBlocks;
            font = content.Font;
            this.graphics = graphics;
            keyboardController = new KeyboardController();
            gameProcess = new GameProcess();
            gameProcess.LoadLevel(new Level(Series.ThinkingRabbitOriginal, 0));
            field = new Field(gameProcess, textureBlocks, graphics, settings.DefaultBlockSize);
            controller = new GameProcessController(gameProcess);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, $"Steps:{gameProcess.Steps}", Vector2.Zero, Color.Black);
            spriteBatch.DrawString(font, $"Time {gameProcess.TimeSpan.ToString("mm\\:ss")}", new Vector2(200, 0), Color.Black);
            spriteBatch.End();
            field.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if(gameProcess.Update())
            {
                field = new Field(gameProcess, textureBlocks, graphics, settings.DefaultBlockSize);
            }
            keyboardController.KeyPressHandler(controller);
        }
    }
}
