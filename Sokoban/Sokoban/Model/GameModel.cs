using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sokoban.Model
{

    class GameModel
    {
        public event Action LevelCompleted;
        public event Action LevelLoaded;
        public Level CurrentLevel { get; private set; }
        public int Steps { get; private set; }
        public TimeSpan TimeSpan
        {
            get
            {
                return DateTime.Now - begin;
            }
        }

        public Point SizeOfStoreroom
        {
            get
            {
                return storeroom.Size;
            }
        }

        public LevelManager LevelManager => levelManager;

        private readonly LevelManager levelManager;
        private DateTime begin;
        private readonly Storeroom storeroom;

        public GameModel()
        {
            storeroom = new Storeroom(new LevelLoader());
            storeroom.LevelCompleted += () =>
            {
                LevelCompleted();
            };
            levelManager = new LevelManager();
        }

        public void LoadLevel(Level level)
        {
            storeroom.LoadLevel(level);
            Steps = 0;
            begin = DateTime.Now;
            CurrentLevel = level;
            LevelLoaded();
        }

        public void Restart()
        {
            LoadLevel(CurrentLevel);  
        }


        public void Move(Direction direction)
        {
            storeroom.TryStorekeeperMove(direction);
            ++Steps;
        }

        public IEnumerable<GameObject> GetAllGameObjects()
        {
            return storeroom.GetAllGameObjects();
        }
        public Dictionary<string, List<string>> GetLevels()
        {
            return LevelManager.SeriesInfo;
        }
    }
}