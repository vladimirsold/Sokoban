using GeonBit.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Model;
using Sokoban.View.Scenes;
using System;


namespace Sokoban.View.Scenes
{
    class SceneManager
    {
        IScene currentScene;
        readonly GameModel gameModel;
        readonly GameScene gameScene;
        readonly MainMenu mainMenu;
        readonly Pause pause;
        readonly LevelSelect levelSelect;
        public event Action Exit;
        readonly GraphicsDeviceManager graphics;
        public readonly Texture2D textureBackground;


        public SceneManager(ContentManager contentManager, LoadedContent loadedContent, GraphicsDeviceManager graphics)
        {
            UserInterface.Initialize(contentManager, BuiltinThemes.hd);
            gameModel = new GameModel();
            this.graphics = graphics;
            pause = new Pause();
            mainMenu = new MainMenu();
            gameScene = new GameScene(graphics, loadedContent, gameModel);
            levelSelect  = new LevelSelect(gameModel, graphics, loadedContent);
            gameModel.LevelCompleted += () =>
            {
                currentScene = levelSelect;
                levelSelect.Call();
            };
            textureBackground = loadedContent.TextureBackground;

            mainMenu.StartButtonPressed += () =>
            {  
                currentScene = levelSelect;
                levelSelect.Call();
            };
            mainMenu.ExitButtonPressed += ()=>Exit();

            levelSelect.GameStart += () =>
            {
                currentScene = gameScene;
            };
            pause.ContinueButtonPressed += () => currentScene = gameScene;
            pause.MainMenuButtonPressed += mainMenu.Call;
            pause.RestartButtonPressed += () =>
            {
                gameModel.Restart();
                currentScene = gameScene;
            };

            currentScene = mainMenu;
        }
        public void Update(GameTime gameTime)
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
            UserInterface.Active.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        { 
            spriteBatch.Begin();
            spriteBatch.Draw(textureBackground, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.End(); 
            currentScene.Draw(spriteBatch);
            UserInterface.Active.Draw(spriteBatch);
        }
    }
}
