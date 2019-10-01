using System;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.View.Scenes
{
    class Pause : IScene
    {
        public event Action ContinueButtonPressed;
        public event Action MainMenuButtonPressed;
        public event Action RestartButtonPressed;
        private readonly Panel pausePanel;
        public Pause()
        {
            pausePanel = new Panel(new Vector2(250, 400), PanelSkin.Default, Anchor.Center);
            UserInterface.Active.AddEntity(pausePanel);
            pausePanel.AddChild(new Header("Pause"));
            pausePanel.AddChild(new HorizontalLine());
            pausePanel.AddChild(
                new Button("Continue")
                {
                    OnClick = (Entity btn) =>
                    {
                        pausePanel.Visible = false;
                        ContinueButtonPressed?.Invoke();
                    }
                });
            pausePanel.AddChild(
                new Button("Restart")
                {
                    OnClick = (Entity btn) =>
                    {
                        pausePanel.Visible = false;
                        RestartButtonPressed?.Invoke();
                    }
                });
            pausePanel.AddChild(
                new Button("Main Menu")
                {
                    OnClick = (Entity btn) =>
                    {
                        pausePanel.Visible = false;
                        MainMenuButtonPressed?.Invoke();
                    }
                });
            pausePanel.Visible = false;
        }


        public void CallPause() => pausePanel.Visible = true;

        public void Update(GameTime gameTime)
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
        }
    }
}

