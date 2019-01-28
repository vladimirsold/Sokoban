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
        public bool IsCollision(GameObject gameObject, Action action)
        {
            bool result = false;
            switch(action)
            {
                case Action.Left:
                    if(X - Model.FieldSellSize == gameObject.X && Y == gameObject.Y)
                        result = true;
                    break;
                case Action.Right:
                    if(X + Model.FieldSellSize == gameObject.X && Y == gameObject.Y)
                        result = true;
                    break;
                case Action.Up:
                    if(X == gameObject.X && Y - Model.FieldSellSize == gameObject.Y)
                        result = true;
                    break;
                case Action.Down:
                    if(X == gameObject.X && Y + Model.FieldSellSize == gameObject.Y)
                        result = true;
                    break;
            }
            return result;
        }
    }
}
