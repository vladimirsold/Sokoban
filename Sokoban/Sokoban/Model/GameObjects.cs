using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class GameObjects
    {
        public HashSet<Wall> Walls { get; private set; }
        public HashSet<Box> Boxes { get; private set; }
        public HashSet<CellForBox> Cells { get; private set; }
        public Storekeeper Player { get; private set; }
        public Vector FieldSize { get; private set; }

        public GameObjects(HashSet<Wall> walls, HashSet<Box> boxes, HashSet<CellForBox> cells, Storekeeper player, Vector fieldSize)
        {
            Walls = walls;
            Boxes = boxes;
            Cells = cells;
            Player = player;
            FieldSize = fieldSize;
        }

        public HashSet<GameObject> GetAllGameObjects()
        {
            HashSet<GameObject> gameObjects = new HashSet<GameObject>();
            gameObjects.UnionWith(Walls);
            gameObjects.UnionWith(Boxes);
            gameObjects.UnionWith(Cells);
            gameObjects.Add(Player);
            return gameObjects;
        }

        public HashSet<CollisionObject> GetCollisionObjects()
        {
            HashSet<CollisionObject> collisionObjects = new HashSet<CollisionObject>(Boxes);
            collisionObjects.UnionWith(Walls);
            return collisionObjects;
        }
    }
}
