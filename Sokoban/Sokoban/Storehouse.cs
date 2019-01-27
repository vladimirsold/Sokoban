using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Storehouse
    {
        Texture2D texture;
        Storekeeper storekeeper;
        private Block[,] blocks;
        public Storehouse(int x, int y, Texture2D texture)
        {
            this.texture = texture;
            blocks = new Block[x, y];
            for(var i = 0; i < x; i++)
            {
                for(var j = 0; j < y; j++)
                {
                    blocks[i, j] = Block.Wall;
                }
            }
        }

        public void Initialize(Point size)
        {
            blocks = new Block[size.X, size.Y];
            for(var i = 0; i < size.X; i++)
            {
                for(var j = 0; j < size.Y; j++)
                {
                    blocks[i, j] = Block.Wall;
                }
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            int rows = blocks.GetUpperBound(0) + 1;
            int columns = blocks.Length / rows;
            for(var i = 0; i < rows; i++)
            {
                for(var j = 0; j < columns; j++)
                {
                    spriteBatch.Draw(texture,new Rectangle(i*32+96, j*32+128, 32, 32), Color.White);
                }
            }
        }
    }
}
