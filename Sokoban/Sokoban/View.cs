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
        public View(Model model)
        {
            this.model = model;
            field = new Field(model);
        }   

        public void Draw(SpriteBatch spriteBatch)
        {
            field.Paint(spriteBatch);
        }      
    }
}