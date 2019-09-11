using System;
using System.Collections.Generic;
using System.Linq;

namespace Sokoban.Model
{

    class GameModel : ISokobanGameModel
    {
        public event Action LevelCompleted;
        public Level CurrentLevel { get; private set; }
        public int Steps { get; private set; }      
        private  DateTime begin; 
        public HashSet<Wall> Walls { get; private set; }
        public HashSet<Box> Boxes { get; private set; }
        public HashSet<CellForBox> CellsForBoxes { get; private set; }
        public Storekeeper Storekeeper { get; private set; }
        public Vector FieldSize { get; private set; }
        public TimeSpan TimeSpan
        {
            get
            {
                return DateTime.Now - begin;
            }
        }

        public void LoadLevel(Level level)
        {
            (Walls, Boxes, CellsForBoxes, Storekeeper, FieldSize) = LevelLoader.LoadLevel(level);
            Steps = 0;
            begin = DateTime.Now;
            CurrentLevel = level;
        }

        public void Restart()
        {
            LoadLevel(CurrentLevel);
            LevelCompleted();
        }

        public void StartNextLevel()
        {
            Level nextLevel = LevelManager.NextLevel(CurrentLevel);
            LoadLevel(nextLevel);
        }

        public void Move(Direction direction)
        {
            if(IsWallCollision( direction))
            {
                return;
            }
            if(IsBoxCollision(direction, out Box stopedBox))
            {
                if(!TryMoveBox(stopedBox, direction))
                {
                    return;
                }
            }
            Storekeeper.Move(direction);
            ++Steps;
        }

        private bool TryMoveBox(Box stopedBox, Direction direction)
        {
            var collisionObjects = new HashSet<CollisionObject>(Boxes);
            collisionObjects.UnionWith(Walls);
            foreach(var collisionObject in collisionObjects)
            {
                if(stopedBox.IsCollision(collisionObject, direction))
                {
                    return false;
                }
            }
            stopedBox.Move(direction);
            return true;
        }

        bool IsWallCollision( Direction direction)
        {
            foreach(Wall wall in Walls)
            {

                if(Storekeeper.IsCollision(wall, direction))
                {
                    return true;
                }
            }
            return false;
        }

        bool IsBoxCollision(Direction direction, out Box stopedBox)
        {
            stopedBox = null;
            foreach(var box in Boxes)
            {
                if(Storekeeper.IsCollision(box, direction))
                {
                    stopedBox = box;
                }
            }
            return stopedBox != null;
        }

        void SetStateOfCell()
        {
            foreach(CellForBox cell in CellsForBoxes)
            {
                bool empty = true;
                cell.SetState(empty);
                foreach(Box box in Boxes)
                {
                    if((box.X == cell.X) && (box.Y == cell.Y))
                    {
                        cell.SetState(!empty);
                        break;
                    }
                }
            }
        }

        public HashSet<GameObject> GetAllGameObjects()
        {
            HashSet<GameObject> gameObjects = new HashSet<GameObject>();
            gameObjects.UnionWith(Walls);
            gameObjects.UnionWith(Boxes);
            gameObjects.UnionWith(CellsForBoxes);
            gameObjects.Add(Storekeeper);
            return gameObjects;
        }

        bool IsLevelCompleted()
        {
            foreach(CellForBox cell in CellsForBoxes)
            {
                if(cell.IsEmpty)
                {
                    return false;
                }
            }
            return true;
        }

        public void Update()
        {
            SetStateOfCell();
            if(IsLevelCompleted())
            {
                StartNextLevel();
                LevelCompleted();
            }
        }
    }
}