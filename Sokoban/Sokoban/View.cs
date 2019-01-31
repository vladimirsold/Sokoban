using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sokoban
{
    class View
    {
        private Field field;
        protected Model model;
        //Dictionary<string, Texture2D> TextureBlocks { get; set; }
        public View(Model model)
        {
            this.model = model;
        }   

        public void Draw(SpriteBatch spriteBatch)
        {
            field.Paint(spriteBatch);
        }

        public void LoadTextureBlocks(Dictionary<TextureID, Texture2D> textureBlocks)
        {
            //TextureBlocks = textureBlocks;
            field = new Field(model, textureBlocks);
        }
    }
}