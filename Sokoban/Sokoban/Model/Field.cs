using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Field
    {
        public GameObject Storeroom { get; private set; }  
        public HashSet<CellForBox> CellForBoxes { get; private set; }
        public Storekeeper Storekeeper { get; private set; }
    }
}
