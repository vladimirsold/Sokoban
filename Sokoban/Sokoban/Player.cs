using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    class Player : CollisionObject, IMovable
    {
        public Player(int x, int y) : base(x, y) { }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }
    }
}
