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
        GameModel gameProcess; 
        public GameProcessController(GameModel gameProcess)
        {
            this.gameProcess = gameProcess;
        }     

        public void Move(Direction direction)
        {
            gameProcess.Move(direction);   
        }

        public void Restart()
        {
            gameProcess.Restart();
            
        }

        public void StartNextLevel()
        {
            gameProcess.StartNextLevel();
            
        }
    }
}
