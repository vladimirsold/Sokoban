﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    
    class Controller
    {
        Model model; 
        public Controller(Model model)
        {
            this.model = model;
        }     

        public void Move(Direction action)
        {
            model.Move(action);   
        }

        public void Restart()
        {
            model.Restart();
            
        }

        public void StartNextLevel()
        {
            model.StartNextLevel();
            
        }

        public GameObjects GetGameObjects()
        {
            return model.GameObjects;
        } 
    }
}