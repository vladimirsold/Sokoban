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
        private View view;
        public IEventListener eventListener;

        private Dictionary<Tuple<Keys, Action>, bool> pressedKey;

       
        public void KeyPressHandler()
        {
            foreach(var key in pressedKey.Keys.ToList())
            {
                if(Keyboard.GetState().IsKeyDown(key.Item1) && !pressedKey[key])
                {
                    pressedKey[key] = true;
                    eventListener.Move(key.Item2);
                }
                if(Keyboard.GetState().IsKeyUp(key.Item1))
                {

                    pressedKey[key] = false;
                }
            }
        }

        public Field(View view )
        {
            this.view = view;
            pressedKey = new Dictionary<Tuple<Keys, Action>, bool>
            {
                [new Tuple<Keys, Action>(Keys.Left, Action.Left)] = false,
                [new Tuple<Keys, Action>(Keys.Right, Action.Right)] = false,
                [new Tuple<Keys, Action>(Keys.Up, Action.Up)] = false,
                [new Tuple<Keys, Action>(Keys.Down, Action.Down)] = false,
            };
        }

        public void SetEventListener(IEventListener eventListener)
        {
            this.eventListener = eventListener;
        }

        public void Paint(SpriteBatch spriteBatch)
        {
  
            HashSet<GameObject> gameObjects = view.GetGameObjects().GetAllGameObjects();
            foreach(var gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }

        }

       
    }
}
