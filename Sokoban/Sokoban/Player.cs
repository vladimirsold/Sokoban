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
        public Player(int x, int y) : base(x, y)
        {
            Texture = "PlayerFront";
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
