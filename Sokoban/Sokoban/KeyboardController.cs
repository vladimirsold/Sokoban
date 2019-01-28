﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class KeyboardController
    {
        private Dictionary<Tuple<Keys, Action>, bool> pressedKey;

        public KeyboardController()
        {
            pressedKey = new Dictionary<Tuple<Keys, Action>, bool>
            {
                [new Tuple<Keys,Action>(Keys.Left, Action.Left)] = false,
                [new Tuple<Keys, Action>(Keys.Right, Action.Right)] = false,
                [new Tuple<Keys, Action>(Keys.Up, Action.Up)] = false,
                [new Tuple<Keys, Action>(Keys.Down, Action.Down)] = false,
            };
        }
        public void KeyPressHandler(Controller controller)
        {
            foreach(var key in pressedKey.Keys.ToList())
            {
                if(Keyboard.GetState().IsKeyDown(key.Item1) && !pressedKey[key])
                {
                    pressedKey[key] = true;
                    controller.Move(key.Item2);
                }
                if(Keyboard.GetState().IsKeyUp(key.Item1))
                {

                    pressedKey[key] = false;
                }
            }
            //if( Keyboard.GetState().IsKeyDown(Keys.Left) && !pressedKey[Keys.Left])
            //{
            //    pressedKey[Keys.Left] = true;
            //    storekeeper.Move(Direction.Left);
            //}
            //if(Keyboard.GetState().IsKeyUp(Keys.Left))
            //{

            //    pressedKey[Keys.Left] = false;
            //}

            //if(Keyboard.GetState().IsKeyDown(Keys.Right) && !pressedKey[Keys.Right])
            //{
            //    storekeeper.Move(Direction.Right);
            //}
            //if(Keyboard.GetState().IsKeyUp(Keys.Right))
            //{
            //    pressedKey[Keys.Right] = false;
            //}

            //if(Keyboard.GetState().IsKeyDown(Keys.Down) && !pressedKey[Keys.Down])
            //{
            //    storekeeper.Move(Direction.Down);
            //}
            //if(Keyboard.GetState().IsKeyUp(Keys.Down))
            //{
            //    pressedKey[Keys.Down] = false;
            //}

            //if(Keyboard.GetState().IsKeyDown(Keys.Up) && !pressedKey[Keys.Up])
            //{
            //    storekeeper.Move(Direction.Up);
            //}
            //if(Keyboard.GetState().IsKeyUp(Keys.Up))
            //{          
            //    pressedKey[Keys.Up] = false;
            //}
        }
    }
}
