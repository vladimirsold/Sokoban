using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model
{
    class CellForBox : GameObject
    {
        public readonly int X;
        public readonly int Y;
        readonly GameObject[,] storeroom;
        public bool IsEmpty
        {
            get
            {
                return !(storeroom[X, Y] is Box);
            }
        }
        public CellForBox(int x, int y, GameObject[,] storeroom)
        {
            X = x;
            Y = y;
            this.storeroom = storeroom;
        }

    }
}
