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
        public bool IsEmpty { get; private set; }
        public CellForBox(int x, int y) : base(x, y)
        {
            
        }

        public void SetState(bool state)
        {
            IsEmpty = state;
        }
    }
}
