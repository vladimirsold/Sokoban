using Microsoft.Xna.Framework;

namespace Sokoban.Model
{
    public abstract class GameObject
    {
        //TODO: Add TextureId Property
        public Point Coordinates { get; protected set; }

        protected GameObject(Point coords)
        {
            Coordinates = coords;
        }
    }
}
