using GeonBit.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace View
{
    abstract class UI : IScene
    {
        public UI(ContentManager contentManager)
        { 
            UserInterface.Initialize(contentManager, BuiltinThemes.editor);   
        }

        public abstract void SetVisibility(bool value);
        public void Update(GameTime gameTime)
        {
            UserInterface.Active.Update(gameTime);
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            UserInterface.Active.Draw(spriteBatch);
        }
    }
}
