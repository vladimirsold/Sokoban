using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model
{
    class Wall : CollisionObject
    {
        public Wall(int x, int y) : base(x, y) { }
    }
}
