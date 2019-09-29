using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
