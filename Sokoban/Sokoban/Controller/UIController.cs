using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller
{
    
    class GameProcessUIController
    {
        GameModel gameModel; 
        public GameProcessUIController(GameModel gameModel)
        {
            this.gameModel = gameModel; 
        }     

        public void Restart()
        {
            gameModel.Restart();            
        }
        
        public void LoadLevel(Level level)
        {
            gameModel.LoadLevel(level);
        }
    }
}
