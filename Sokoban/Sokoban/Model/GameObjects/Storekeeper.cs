using Microsoft.Xna.Framework;


namespace Sokoban.Model
{
    public class Storekeeper : GameObject
    {
        public Direction State { get; set; }
        public Storekeeper(Point coords) : base(coords)
        {
            State = Direction.Down;

        }

        public void Move(Point coordinates)
        {
            Coordinates = coordinates; 
        }
    }
}
