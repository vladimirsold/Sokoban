using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.View
{
    class MenuScene : Scene
    {
        private ContentManager content;
        private Button startButton;
        private Button exitButton;
        public MenuScene(ContentManager content)
        {
            this.content = content;
            UserInterface.Initialize(content, BuiltinThemes.editor);
            Panel panel = new Panel(new Vector2(250, 400), PanelSkin.Default, Anchor.Center);
            UserInterface.Active.AddEntity(panel);

            // add title and text
            panel.AddChild(new Header("Sokoban"));
            panel.AddChild(new HorizontalLine());

            // add a button at the bottom
            startButton = new Button("Start");
            panel.AddChild(startButton);
            Button settingsButton = new Button("Settings");
            panel.AddChild(settingsButton);

            exitButton = new Button("Exit");
            panel.AddChild(exitButton);
        }

        public override void Initialize()
        {
           
        }

        public override void Update(GameTime gameTime)
        {
            UserInterface.Active.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            UserInterface.Active.Draw(spriteBatch);
        }

        public bool Start()
        {
            return startButton.State == EntityState.MouseDown;
        }

        public bool Exit()
        {
            return exitButton.State == EntityState.MouseDown;      
        }
    }
}
