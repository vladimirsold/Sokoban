
using System;

namespace Sokoban.Model
{

    class GameProcess
    {       
        public Level CurrentLevel { get; private set; }
        public int Steps { get; private set; }      
        private  DateTime begin; 
        public GameObjects GameObjects { get; private set; }
        public TimeSpan TimeSpan
        {
            get
            {
                return DateTime.Now - begin;
            }
        }

        public void LoadLevel(Level level)
        {
            GameObjects = LevelLoader.LoadLevel(level);
            Steps = 0;
            begin = DateTime.Now;
            CurrentLevel = level;
        }

        public void Restart()
        {
            LoadLevel(CurrentLevel);
        }

        public void StartNextLevel()
        {
            var nextLevel = LevelLoader.NextLevel(CurrentLevel);
            LoadLevel(nextLevel);
        }

        public void Move(Direction direction)
        {
            if(IsWallCollision(GameObjects.Storekeeper, direction))
            {
                return;
            }
            if(IsBoxCollision(direction))
            {
                return;
            }
            GameObjects.Storekeeper.Move(direction);
            ++Steps;
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
            Storekeeper player = GameObjects.Storekeeper;
            GameObject stoped = null;
            foreach(CollisionObject gameObject in GameObjects.GetCollisionObjects())
            {
                if(player.IsCollision(gameObject, direction))
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

        public void SetStateOfCell()
        {
            foreach(CellForBox cell in GameObjects.Cells)
            {
                bool empty = true;
                cell.SetState(empty);
                foreach(Box box in GameObjects.Boxes)
                {
                    if((box.X == cell.X) && (box.Y == cell.Y))
                    {
                        cell.SetState(!empty);
                        break;
                    }
                }
            }
        }

        public bool IsLevelCompleted()
        {
            foreach(CellForBox cell in GameObjects.Cells)
            {
                if(cell.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Update()
        {
            SetStateOfCell();
            if(IsLevelCompleted())
            {
                StartNextLevel();
                return true;
            }
            return false;
        }
    }
}