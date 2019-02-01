using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sokoban
{
    class Field
    {
        private readonly int blockSize;
        private readonly Point pointDraw;
        private readonly Dictionary<TextureID, Texture2D> textureBlocks;
        private Model model;
        public Field(Model model, Dictionary<TextureID, Texture2D> textureBlocks, GraphicsDeviceManager graphics, int defaultBlockSize)
        {
            this.textureBlocks = textureBlocks;
            this.model = model;
            var possibleSizeBlock = new int[]{graphics.PreferredBackBufferWidth / model.GameObjects.FieldSize.X,
                graphics.PreferredBackBufferHeight / (model.GameObjects.FieldSize.Y + 1), defaultBlockSize};
            blockSize = possibleSizeBlock.Min();           
            var pointX = (graphics.PreferredBackBufferWidth - model.GameObjects.FieldSize.X * blockSize) / 2;
            var pointY = (graphics.PreferredBackBufferHeight - model.GameObjects.FieldSize.Y * blockSize) / 2;
            pointDraw = new Point(pointX, pointY);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(var gameObject in model.GameObjects.GetAllGameObjects())
            {
                var rectangle = GetRectangleFromGameObject(gameObject);
                spriteBatch.Draw(textureBlocks[gameObject.Texture], rectangle, Color.White);
            }
        }

        Rectangle GetRectangleFromGameObject(GameObject gameObject)
        {
            return new Rectangle(gameObject.X * blockSize + pointDraw.X, gameObject.Y * blockSize + pointDraw.Y, blockSize, blockSize);
        }
    }
}
