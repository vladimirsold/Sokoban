using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sokoban.Model
{

    class GameModel
    {
        public event Action LevelCompleted;
        public Level CurrentLevel { get; private set; }
        public int Steps { get; private set; }

        private  DateTime begin;
        public Field Field { get; private set; }
        public TimeSpan TimeSpan
        {
            get
            {
                return DateTime.Now - begin;
            }
        }


        public void LoadLevel(Level level)
        {
            Field = LevelLoader.LoadLevel(level);
            Steps = 0;
            begin = DateTime.Now;
            CurrentLevel = level;
        }

        public void Restart()
        {
            LoadLevel(CurrentLevel);
            LevelCompleted();
        }

        public void StartNextLevel()
        {
            Level nextLevel = LevelManager.NextLevel(CurrentLevel);
            LoadLevel(nextLevel);
        }

        public void Move(Direction direction)
        {
            Field.TryStorekeeperMove(direction);
            ++Steps;
        }

    


        bool IsAllCellsWithBox()
        {
            return Field.CellForBoxes.All(cell => cell.IsEmpty);
        }

        public void Update()
        {
            if(IsAllCellsWithBox())
            { 
                LevelCompleted();
            }
        }
    }
}