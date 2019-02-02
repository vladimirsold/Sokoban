using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban.Model
{
    class Storekeeper : CollisionObject, IMovable
    {
        public Direction State { get; private set; }
        public Storekeeper(int x, int y) : base(x, y)
        {
            State = Direction.Down;
        }

        public void Move(Direction direction)
        {
            State = direction;
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
