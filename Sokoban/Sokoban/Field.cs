using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Sokoban
{
    class Field
    {
        Dictionary<string, Texture2D> textureBlocks;
        private Model model;
        public Field(Model model, Dictionary<string, Texture2D> textureBlocks)
        {
            this.textureBlocks = textureBlocks;
            this.model = model; 
        }

        public void Paint(SpriteBatch spriteBatch)
        {  
            foreach(var gameObject in model.GameObjects.GetAllGameObjects() )
            {
                string type = gameObject.ToString().Split('+', '.').Last();
                spriteBatch.Draw(textureBlocks[type], new Rectangle(gameObject.X*32, gameObject.Y*32, 32, 32), Color.White);
            }
        }

       
    }
}
