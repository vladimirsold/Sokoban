using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sokoban.View.Scenes
{
    class MainMenu : IScene
    {
        private readonly Panel menuPanel;
        public event Action StartButtonPressed;
        public event Action ExitButtonPressed;
        public MainMenu()
            {
            menuPanel = new Panel(new Vector2(250, 400), PanelSkin.Default, Anchor.Center);
            UserInterface.Active.AddEntity(menuPanel);

            menuPanel.AddChild(new Header("Sokoban"));
            menuPanel.AddChild(new HorizontalLine());


            var startButton = new Button("Start")
            {
                OnClick = (Entity btn) =>
                {
                    menuPanel.Visible = false;
                    StartButtonPressed?.Invoke();
                }
            };
            menuPanel.AddChild(startButton);
            //var settingsButton = new Button("Settings")
            //{
            //    OnClick = (Entity btn) =>
            //    {
            //        menuPanel.Visible = false;
            //    }
            //};
            //menuPanel.AddChild(settingsButton);

            var exitButton = new Button("Exit")
            {
                OnClick = (Entity btn) =>
                {
                    ExitButtonPressed?.Invoke();
                }
            };
            menuPanel.AddChild(exitButton);
        }
        public void Call()
        {
            menuPanel.Visible = true;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
