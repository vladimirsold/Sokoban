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
