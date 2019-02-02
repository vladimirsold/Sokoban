using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller
{
    
    class GameProcessController
    {
        GameProcess gameProcess; 
        public GameProcessController(GameProcess gameProcess)
        {
            this.gameProcess = gameProcess;
        }     

        public void Move(Direction action)
        {
            gameProcess.Move(action);   
        }

        public void Restart()
        {
            gameProcess.Restart();
            
        }

        public void StartNextLevel()
        {
            gameProcess.StartNextLevel();
            
        }

        public GameObjects GetGameObjects()
        {
            return gameProcess.GameObjects;
        } 
    }
}
