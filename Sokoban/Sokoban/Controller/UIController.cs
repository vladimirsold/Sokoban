using Sokoban.Model;

namespace Sokoban.Controller
{
    
    class GameProcessUIController
    {
        readonly GameModel gameModel; 
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
