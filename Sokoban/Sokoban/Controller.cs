using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    
    class Controller : IEventListener
    {
        Model model;
        View view;  
        public Controller()
        {
            model = new Model();
            model.SetEventListener(this); 
            view = new View(this);
            view.Initialize();
            view.SetEventListener(this);
        }
        public void LevelCompleted(int level)
        {
            view.Completed(level);
        }

        public void Move(Action action)
        {
            model.Move(action);   
        }

        public void Restart()
        {
            model.Restart();
            //view.Update();
        }

        public void StartNextLevel()
        {
            model.StartNextLevel();
            //view.Update();
        }

        public GameObjects GetGameObjects()
        {
            return model.GameObjects;
        }

        public View GetView()
        {
            return view;
        }

        public void LoadTextures(Dictionary<string, Texture2D> textureBlocks)
        {
            model.LoadTextureBlocks(textureBlocks);
            model.LoadLevel(1);
        }
    }
}
