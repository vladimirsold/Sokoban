using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace View
{
    class MainMenu : UI
    {
        private readonly Panel menuPanel;
        public event Action StartButtonPressed;
        public event Action ExitButtonPressed;
        public MainMenu(ContentManager content) : base(content)
            {
            menuPanel = new Panel(new Vector2(250, 400), PanelSkin.Default, Anchor.Center);
            UserInterface.Active.AddEntity(menuPanel);
            // add title and text
            menuPanel.AddChild(new Header("Sokoban"));
            menuPanel.AddChild(new HorizontalLine());

            // add a button at the bottom
            var startButton = new Button("Start")
            {
                OnClick = (Entity btn) =>
                {
                    UserInterface.Active.RemoveEntity(menuPanel);
                    StartButtonPressed?.Invoke();
                }
            };
            menuPanel.AddChild(startButton);
            var settingsButton = new Button("Settings")
            {
                OnClick = (Entity btn) =>
                {
                    menuPanel.Visible = false;
                }
            };
            menuPanel.AddChild(settingsButton);

            var exitButton = new Button("Exit")
            {
                OnClick = (Entity btn) =>
                {
                    ExitButtonPressed?.Invoke();
                }
            };
            menuPanel.AddChild(exitButton);
        }
        public void CallMenu()
        {
            UserInterface.Active.AddEntity(menuPanel);
        }
        public override void SetVisibility(bool value) => menuPanel.Visible = value; 
    }
}
