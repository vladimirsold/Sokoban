using Microsoft.Xna.Framework;

namespace Sokoban.Model
{
    public abstract class GameObject
    {
        public Point Coordinates { get; protected set; }

        protected GameObject(Point coords)
        {
            Coordinates = coords;
        }
    }
}
