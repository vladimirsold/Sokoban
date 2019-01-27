using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sokoban
{
    class Storekeeper
    {
        public Texture2D Texture { get; set; }
        public Direction  Direction{get; set;}
        public int Offset { get; set; }
        private Vector2 position;

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public float X
        {
            get
            {
                return position.X;
            }
            set
            {
                position.X = value;
            }
        }

        public float Y
        {
            get
            {
                return position.Y;
            }
            set
            {
                position.Y = value;
            }
        }

        public Storekeeper(Texture2D texture, Vector2 position, int offset)
        {
            Texture = texture;
            this.position = position;
            Offset = offset;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    X -= Offset;
                    break;
                case Direction.Up:
                    Y -= Offset;
                    break;
                case Direction.Right:
                    X += Offset;
                    break;
                case Direction.Down:
                    Y += Offset;
                    break;
                default:
                    throw new ArgumentException("Wrong direction");
            }
        }
    }
}
