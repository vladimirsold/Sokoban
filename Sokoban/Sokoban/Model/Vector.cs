using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban
{
    class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector (int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector(Vector coordinates, Direction direction)
        {
            X = coordinates.X;
            Y = coordinates.Y;
            switch(direction)
            {
                case Direction.Left:
                    X--;
                    break;
                case Direction.Right:
                    X++;
                    break;
                case Direction.Up:
                    Y--;
                    break;
                case Direction.Down:
                    Y++;
                    break;
            }
        }
    }
}
