using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Texture2D Texture { get; set; }

        public GameObject(int x, int y)
        {
            X = x;
            Y = y;
            Width = Model.FieldSellSize;
            Height = Model.FieldSellSize;
        }

        public GameObject(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

         public void Draw(SpriteBatch spriteBratch)
        {
            spriteBratch.Draw(Texture,new Rectangle(X, Y, Width, Height) , Color.White);
        }
    }
}
