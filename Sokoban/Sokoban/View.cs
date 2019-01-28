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
        private Controller controller;
        private Field field;

        public View(Controller controller)
        {
            this.controller = controller;
        }

        public void Initialize()
        {
            field = new Field(this);
        }

        public void SetEventListener(IEventListener eventListener)
        {
            field.SetEventListener(eventListener);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            field.Paint(spriteBatch);
        }

        public GameObjects GetGameObjects()
        {
            return controller.GetGameObjects();
        }

        public void Completed(int level)
        {
            //Update();
            //вывести сообщение о проходе уровня
            controller.StartNextLevel();
        }
    }
}