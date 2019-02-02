﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model;

namespace Sokoban.Controller
{
    class KeyboardController
    {
        private Dictionary<Tuple<Keys, Direction>, bool> pressedKey;

        public KeyboardController()
        {
            pressedKey = new Dictionary<Tuple<Keys, Direction>, bool>
            {
                [new Tuple<Keys,Direction>(Keys.Left, Direction.Left)] = false,
                [new Tuple<Keys, Direction>(Keys.Right, Direction.Right)] = false,
                [new Tuple<Keys, Direction>(Keys.Up, Direction.Up)] = false,
                [new Tuple<Keys, Direction>(Keys.Down, Direction.Down)] = false,
            };
        }
        public void KeyPressHandler(GameProcessController controller)
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
        }
    }
}
