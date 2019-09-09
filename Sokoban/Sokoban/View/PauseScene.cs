using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace View
{
    class Pause : UI
    {
        public event Action ContinueButtonPressed;
        public event Action MainMenuButtonPressed;
        private readonly Panel pausePanel;
        public Pause(ContentManager content) : base(content)
        {
            pausePanel = new Panel(new Vector2(250, 400), PanelSkin.Default, Anchor.Center);
            pausePanel.AddChild(new Header("Pause"));
            pausePanel.AddChild(new HorizontalLine());
            pausePanel.AddChild(
                new Button("Continue")
                {
                    OnClick = (Entity btn) =>
                    {
                        UserInterface.Active.RemoveEntity(pausePanel);
                        ContinueButtonPressed?.Invoke();
                    }
                }); 
            pausePanel.AddChild(
                new Button("Main Menu")
                {
                    OnClick = (Entity btn) =>
                    {
                        UserInterface.Active.RemoveEntity(pausePanel);
                        MainMenuButtonPressed?.Invoke();
                    }
                });
        }
        public void CallPause() => UserInterface.Active.AddEntity(pausePanel);
        public override void SetVisibility(bool value) => pausePanel.Visible = value; 
    }
}

