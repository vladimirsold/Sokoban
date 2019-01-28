using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Field
    {
        private Model model;
        public Field(Model model)
        {
            this.model = model; 
        }

        public void Paint(SpriteBatch spriteBatch)
        {  
            foreach(var gameObject in model.GameObjects.GetAllGameObjects() )
            {
                gameObject.Draw(spriteBatch);
            }

        }

       
    }
}
