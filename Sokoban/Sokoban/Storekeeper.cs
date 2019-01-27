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
        public int Offset { get; set; }
        private Rectangle position;

        public Rectangle Position
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

        public int X
        {
            get
            {
                return position.X;
            }
            set
            {
                if(value > 0 && value < 1200)
                {
                    position.X = value;
                }
            }
        }

        public int Y
        {
            get
            {
                return position.Y;
            }
            set
            {
                if(value > 0 && value < 900)
                {
                    position.Y = value;
                }
            }
        }

        public Storekeeper(Texture2D texture, Point position, int size)
        {
            Texture = texture;
            this.position = new Rectangle(position.X, position.Y, size, size);
            Offset = size;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

        public void Move(Action direction)
        {
            switch(direction)
            {
                case Action.Left:
                    X -= Offset;
                    break;
                case Action.Up:
                    Y -= Offset;
                    break;
                case Action.Right:
                    X += Offset;
                    break;
                case Action.Down:
                    Y += Offset;
                    break;
                default:
                    throw new ArgumentException("Wrong direction");
            }
        }
    }
}
