using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{

    class Model
    {
        public const int FieldSellSize = 1;
        public int CurrentLevel { get; private set; }
        public GameObjects GameObjects { get; private set; }
        private LevelLoader levelLoader;

        public Model()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            levelLoader = new LevelLoader(dir.FullName + "\\Content\\Level.txt");
            CurrentLevel = 0;
        }

        public void LoadLevel(int level)
        {
            GameObjects = levelLoader.LoadLevel(level);       
            CurrentLevel = level;
        }

        public void Restart()
        {
            LoadLevel(CurrentLevel);
        }

        public void StartNextLevel()
        {
            LoadLevel(CurrentLevel + 1);
        }

        public void Move(Direction direction)
        {
            if(IsWallCollision(GameObjects.Player, direction))
            {
                return;
            }
            if(IsBoxCollision(direction))
            {
                return;
            }
            GameObjects.Player.Move(direction);   
        }

        public bool IsWallCollision(CollisionObject gameObject, Direction action)
        {
            foreach(Wall wall in GameObjects.Walls)
            {

                if(gameObject.IsCollision(wall, action))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsBoxCollision(Direction direction)
        { 
            Player player = GameObjects.Player;
            GameObject stoped = null;
            foreach(GameObject gameObject in GameObjects.GetAllGameObjects())
            {
                if(!(gameObject is Player) && !(gameObject is CellForBox) && player.IsCollision(gameObject, direction))
                {
                    stoped = gameObject;
                }
            } 
            if((stoped == null))
            {
                return false;
            }
            if(stoped is Box stopedBox)
            {
                if(IsWallCollision(stopedBox, direction))
                {
                    return true;
                }
                foreach(Box box in GameObjects.Boxes)
                {
                    if(stopedBox.IsCollision(box, direction))
                    {
                        return true;
                    }
                }
                stopedBox.Move(direction);     
            }
            return false;
        }

        public bool IsLevelCompleted()
        {            
            foreach(CellForBox cell in GameObjects.Cells)
            {
                bool boxInSell = false;

                foreach(Box box in GameObjects.Boxes)
                {
                    if((box.X == cell.X) && (box.Y == cell.Y))
                    {
                        boxInSell = true;
                    }
                }
                if(!boxInSell)
                {
                    return false;
                }
            }
            return true;
        }

        public void Update()
        {
            if(IsLevelCompleted())
            {
                StartNextLevel();
            }
        }
    }
}