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
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public TextureID Texture { get; protected set; }

        public GameObject(int x, int y)
        {
            X = x;
            Y = y; 
        }
    }
}
