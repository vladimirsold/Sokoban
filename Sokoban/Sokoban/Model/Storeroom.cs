using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Storeroom
    {
        public event Action LevelCompleted;
        HashSet<Box> boxes;
        HashSet<CellForBox> cellsForBoxes;
        HashSet<Wall> walls;
        Storekeeper storekeeper;
        public Point Size { get; private set; }
        private readonly LevelLoader levelLoader;
        public Storeroom(LevelLoader levelLoader)
        {
            this.levelLoader = levelLoader;
        }
        
        public void LoadLevel(Level level)
        {
            levelLoader.Load(level);
            boxes = levelLoader.Boxes;
            cellsForBoxes = levelLoader.CellsForBoxes;
            walls = levelLoader.Walls;
            storekeeper = levelLoader.Storekeeper;
            Size = levelLoader.Size;
        }
        public void TryStorekeeperMove(Direction direction)
        {
            storekeeper.State = direction;
            Point  coordsToMove = GetCoordsToMove(storekeeper.Coordinates,direction);
            if(IsCollision(walls, coordsToMove))
            {
                return;
            }
            if(IsCollision(boxes, coordsToMove))
            {
                if(TryMoveBox(coordsToMove, direction))
                {
                    storekeeper.Move(coordsToMove);
                    SetStateOfCellForBoxes();
                    CheckLevelComplete();
                }
            }
            else
            {
                storekeeper.Move(coordsToMove);
            }
        }

        private void SetStateOfCellForBoxes()
        {
           foreach(var cell in cellsForBoxes)
            {
                cell.IsEmpty = !boxes.Any(box => box.Coordinates == cell.Coordinates);
            }
        }

        private Point GetCoordsToMove(Point coordinates, Direction direction)
        {
            Point dv = Point.Zero;
            switch(direction)
            {
                case Direction.Left:
                    dv = new Point(-1, 0);
                    break;
                case Direction.Right:
                    dv = new Point(1, 0);
                    break;
                case Direction.Up:
                    dv = new Point(0, -1);
                    break;
                case Direction.Down:
                    dv = new Point(0, 1);
                    break;
            }
            return coordinates + dv;
        }

        private bool TryMoveBox(Point coordsOfBox, Direction direction)
        {
            var coordsToMove = GetCoordsToMove(coordsOfBox, direction);
            if(IsCollision(boxes, coordsToMove) || IsCollision(walls, coordsToMove))
            {
                return false;
            }
            boxes
                .Single(box => box.Coordinates == coordsOfBox)
                .Move(coordsToMove);
            return true;
        }

        private bool IsCollision(IEnumerable<GameObject> gameObjects, Point coordsToMove)
        {
            return gameObjects.Any(x => x.Coordinates == coordsToMove);
        }

        private void CheckLevelComplete()
        {
            if(cellsForBoxes.All(cell => cell.IsEmpty == false))
            {
                LevelCompleted();
            }
        }

        public IEnumerable<GameObject> GetAllGameObjects()
        {
            HashSet<GameObject> gameObjects = new HashSet<GameObject>();
            gameObjects.UnionWith(walls);
            gameObjects.UnionWith(boxes);
            gameObjects.UnionWith(cellsForBoxes);
            gameObjects.Add(storekeeper);
            return gameObjects;
        }
    }
}
