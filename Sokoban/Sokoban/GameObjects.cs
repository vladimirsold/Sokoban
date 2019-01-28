using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class GameObjects
    {
        public HashSet<Wall> Walls { get; private set; }
        public HashSet<Box> Boxes { get; private set; }
        public HashSet<CellForBox> Cells { get; private set; }
        public Player Player { get; private set; }

        public GameObjects(HashSet<Wall> walls, HashSet<Box> boxes, HashSet<CellForBox> cells, Player player)
        {
            Walls = walls;
            Boxes = boxes;
            Cells = cells;
            Player = player;
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
    }
}
