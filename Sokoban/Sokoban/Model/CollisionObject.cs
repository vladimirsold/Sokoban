using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    abstract class CollisionObject : GameObject
    {
        public CollisionObject(int x, int y) : base(x, y)
        {
            X = x;
            Y = y;
        }
        public bool IsCollision(GameObject gameObject, Direction direction)
        {  
            switch(direction)
            {
                case Direction.Left:
                    if(X - 1 == gameObject.X && Y == gameObject.Y)
                        return true;
                    break;
                case Direction.Right:
                    if(X + 1 == gameObject.X && Y == gameObject.Y)
                        return true;
                    break;
                case Direction.Up:
                    if(X == gameObject.X && Y - 1 == gameObject.Y)
                        return true;
                    break;
                case Direction.Down:
                    if(X == gameObject.X && Y + 1 == gameObject.Y)
                        return true;
                    break;
            }
            return false;
        }
    }
}
