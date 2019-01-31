using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sokoban
{
    class Field
    {
        private int size;
        private Point pointDraw;
        Dictionary<TextureID, Texture2D> textureBlocks;
        private Model model;
        public Field(Model model, Dictionary<TextureID, Texture2D> textureBlocks)
        {
            this.textureBlocks = textureBlocks;
            this.model = model;
            size = 32;
            pointDraw = new Point(1, 1);
        }

        public void Paint(SpriteBatch spriteBatch)
        {
            foreach(var gameObject in model.GameObjects.GetAllGameObjects())
            {
                var rectangle = GetRectangleFromGameObject(gameObject); 
                spriteBatch.Draw(textureBlocks[gameObject.Texture], rectangle, Color.White);
            }
        }

        Rectangle GetRectangleFromGameObject(GameObject gameObject)
        {
            return new Rectangle(gameObject.X * size + pointDraw.X, gameObject.Y * size + pointDraw.Y, size, size);
        }
    }
}
