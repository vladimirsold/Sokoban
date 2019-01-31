using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    class Box : CollisionObject, IMovable
    {
        public Box(int x, int y) : base(x, y)
        {
            Texture = TextureID.Box;
        }
        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    --X;
                    break;
                case Direction.Right:
                    ++X;
                    break;
                case Direction.Up:
                    --Y;
                    break;
                case Direction.Down:
                    ++Y;
                    break;
            }
        }
    }
}
