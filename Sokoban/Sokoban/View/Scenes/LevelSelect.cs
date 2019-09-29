using System;
using System.Collections.Generic;
using System.Linq;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Model;

namespace Sokoban.View.Scenes
{
    class LevelSelect : IScene
    {
        public event Action GameStart;

        private readonly LoadedContent content;
        private readonly GameModel gameModel;
        private Panel seriesPanel;
        Field priewLevel;
        GraphicsDeviceManager graphics;
        public LevelSelect(GameModel gameModel, GraphicsDeviceManager graphics, LoadedContent content)
        {
            this.content = content;
            this.gameModel = gameModel;
            this.graphics = graphics;
            BuildSeriesPanel();
        }

        void BuildSeriesPanel()
        {
            seriesPanel = new Panel(new Vector2(400, 500), PanelSkin.Default, Anchor.Center);
            UserInterface.Active.AddEntity(seriesPanel);
            seriesPanel.AddChild(new Header("Choice Serie"));
            seriesPanel.AddChild(new HorizontalLine());

            foreach(var serie in gameModel.GetLevels())
            {
                var levelPanel = BuildLevelPanelForSerie(serie);
                AddButton(seriesPanel, serie.Key,
                (Entity btn) =>
                {
                    seriesPanel.Visible = false;
                    levelPanel.Visible = true;
                });
            }
            seriesPanel.Visible = false;
        }

        private Panel BuildLevelPanelForSerie(KeyValuePair<string, List<string>> serie)
        {
            var levelPanel = new Panel(new Vector2(400, 600), PanelSkin.Default, Anchor.CenterLeft);
            UserInterface.Active.AddEntity(levelPanel);
            AddLevelsList(levelPanel, serie);
            levelPanel.Visible = false;
            return levelPanel;
        }

        private void AddLevelsList(Panel levelPanel, KeyValuePair<string, List<string>> serie)
        {
            SelectList list = new SelectList(new Vector2(0, 300));
            foreach(var level in serie.Value)
            {
                list.AddItem(level);
            }

            list.OnValueChange = (Entity entity) =>
            {
                var loader = new LevelLoader();
                var serieName = serie.Key;
                var levelName = list.SelectedValue;
                loader.Load(new Level(serieName, levelName));
                var data = new HashSet<GameObject>();
                data.UnionWith(loader.Walls);
                data.UnionWith(loader.Boxes);
                data.UnionWith(loader.CellsForBoxes);
                data.Add(loader.Storekeeper);

                priewLevel = new Field(data, loader.Size, content.BlocksTextures);
                var startPoint = new Point(graphics.PreferredBackBufferWidth / 2 - 100, graphics.PreferredBackBufferHeight / 4);
                var sizeOfField = new Point(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
                priewLevel.Init(startPoint, sizeOfField);
            };
            levelPanel.AddChild(list);
            AddButton(levelPanel, "Start",
                (Entity btn) =>
                {
                    seriesPanel.Visible = false;
                    levelPanel.Visible = false;
                    var serieName = serie.Key;
                    var levelName = list.SelectedValue;
                    gameModel.LoadLevel(new Level(serieName, levelName));
                    GameStart?.Invoke();
                    priewLevel = null;
                });
            levelPanel.AddChild(new HorizontalLine());
            AddButton(levelPanel, "Back",
             (Entity btn) =>
             {
                 seriesPanel.Visible = true;
                 levelPanel.Visible = false;
                 priewLevel = null;
             });
        }

        private void AddButton(Panel panel, string name, EventCallback eventCallback)
        {
            var button = new Button(name)
            {
                OnClick = eventCallback
            };
            panel.AddChild(button);
        }

        internal void Call()
        {
            seriesPanel.Visible = true;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            priewLevel?.Draw(spriteBatch);
        }
    }
}
