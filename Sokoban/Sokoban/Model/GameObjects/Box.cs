using Microsoft.Xna.Framework;


namespace Sokoban.Model
{
    public class Box : GameObject
    {
        public Box(Point coords) : base(coords)
        {

        }

        internal void Move(Point coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
