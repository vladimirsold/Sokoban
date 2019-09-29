using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
