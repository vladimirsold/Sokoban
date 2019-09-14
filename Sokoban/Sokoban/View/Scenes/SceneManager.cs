using GeonBit.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using View.Scenes;

namespace View
{
    class SceneManager
    {
        IScene currentScene;
        GameScene gameScene;
        MainMenu mainMenu;
        Pause pause;
        public event Action Exit;
        GraphicsDeviceManager graphics;
        public readonly Texture2D textureBackground;


        public SceneManager(ContentManager contentManager, LoadedContent loadedContent, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            pause = new Pause(contentManager);
            mainMenu = new MainMenu(contentManager);
            textureBackground = loadedContent.TextureBackground;
            mainMenu.StartButtonPressed += () =>
            {
                gameScene = new GameScene(graphics, loadedContent);  
                currentScene = gameScene;
            };
            mainMenu.ExitButtonPressed += ()=>Exit();
            pause.ContinueButtonPressed += () => currentScene = gameScene;
            pause.MainMenuButtonPressed += mainMenu.CallMenu;
            pause.RestartButtonPressed += () =>
            {
                gameScene.uiController.Restart();
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
