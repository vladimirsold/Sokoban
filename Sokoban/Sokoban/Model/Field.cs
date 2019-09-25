using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Field
    {
        public GameObject[,] Storeroom { get; private set; }  
        public HashSet<CellForBox> CellForBoxes { get; private set; }
        public Storekeeper Storekeeper { get; private set; }
        public Vector Size { get; private set; }
        public Field(GameObject[,] storeroom, HashSet<CellForBox> cellForBoxes, Storekeeper storekeeper, Vector size)
        {
            Storeroom = storeroom;
            CellForBoxes = cellForBoxes;
            Storekeeper = storekeeper;
            Size = size;
        }

        public void TryStorekeeperMove(Direction direction)
        { 
            Storekeeper.TryMove(direction);
        } 

    }
}
