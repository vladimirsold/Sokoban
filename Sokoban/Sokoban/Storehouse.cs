using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Storehouse
    {
        Rectangle rectangle;

        public Storehouse(int x, int y, int width, int height)
        {
            rectangle = new Rectangle(x, y, width, height);
        }
    }
}
