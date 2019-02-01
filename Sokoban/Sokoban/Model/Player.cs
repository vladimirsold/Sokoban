using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    class Player : CollisionObject, IMovable
    {
        public Player(int x, int y) : base(x, y)
        {
            Texture = TextureID.PlayerTurnedForward;
        }

        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    --X;
                    Texture = TextureID.PlayerTurnedLeft;
                    break;
                case Direction.Right:
                    ++X;
                    Texture = TextureID.PlayerTurnedRight;
                    break;
                case Direction.Up:
                    --Y;
                    Texture = TextureID.PlayerTurnedBackward;
                    break;
                case Direction.Down:
                    ++Y;
                    Texture = TextureID.PlayerTurnedForward;
                    break;
            }
        }
    }
}
