using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sokoban.Model
{
    public class CellForBox : GameObject
    {

        public bool IsEmpty { get; set; } 
        public CellForBox(Point coords ) : base(coords)
        {
            IsEmpty = true;
        }

    }
}
