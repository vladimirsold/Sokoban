using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{

    class Model
    {
        public const int FieldSellSize = 32;
        public int CurrentLevel { get; private set; }
        public GameObjects GameObjects { get; private set; }
        private LevelLoader levelLoader;

        Dictionary<string, Texture2D> textureBlocks;

        public Model()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            levelLoader = new LevelLoader(dir.FullName + "\\Content\\Level.txt");
            CurrentLevel = 0;
        }

        public void LoadLevel(int level)
        {
            GameObjects = levelLoader.LoadLevel(level);
            foreach(var gameObject in GameObjects.GetAllGameObjects())
            {
                string type = gameObject.ToString().Split('+','.').Last();
                gameObject.Texture = textureBlocks[type];
            }
            CurrentLevel = level;
        }

        public void Restart()
        {
            LoadLevel(CurrentLevel);
        }

        public void StartNextLevel()
        {
            LoadLevel(CurrentLevel + 1);
        }

        public void Move(Action action)
        {
            Player player = GameObjects.Player;

            if(IsWallCollision(player, action))
            {
                return;
            }
            if(IsBoxCollision(action))
            {
                return;
            }
            switch(action)
            {
                case Action.Left:
                    player.Move(-FieldSellSize, 0);
                    break;
                case Action.Right:
                    player.Move(FieldSellSize, 0);
                    break;
                case Action.Up:
                    player.Move(0, -FieldSellSize);
                    break;
                case Action.Down:
                    player.Move(0, FieldSellSize);
                    break;
            }     
        }

        public void LoadTextureBlocks(Dictionary<string, Texture2D> textureBlocks)
        {
            this.textureBlocks = textureBlocks;  
        }

        public bool IsWallCollision(CollisionObject gameObject, Action action)
        {
            foreach(Wall wall in GameObjects.Walls)
            {

                if(gameObject.IsCollision(wall, action))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsBoxCollision(Action action)
        { //проверяет столкновение с ящиками + передвижение
            Player player = GameObjects.Player;

            // найдем во что уперся игрок
            GameObject stoped = null;
            foreach(GameObject gameObject in GameObjects.GetAllGameObjects())
            {
                if(!(gameObject is Player) && !(gameObject is CellForBox) && player.IsCollision(gameObject, action))
                {
                    stoped = gameObject;
                }
            }
            //свободное место или дом
            if((stoped == null))
            {
                return false;
            }
            if(stoped is Box)
            {
                Box stopedBox = (Box)stoped;
                if(IsWallCollision(stopedBox, action))
                {
                    return true;
                }
                foreach(Box box in GameObjects.Boxes)
                {
                    if(stopedBox.IsCollision(box, action))
                    {
                        return true;
                    }
                }
                switch(action)
                {
                    case Action.Left:
                        stopedBox.Move(-FieldSellSize, 0);
                        break;
                    case Action.Right:
                        stopedBox.Move(FieldSellSize, 0);
                        break;
                    case Action.Up:
                        stopedBox.Move(0, -FieldSellSize);
                        break;
                    case Action.Down:
                        stopedBox.Move(0, FieldSellSize);
                        break;

                }
            }
            return false;


        }

        public bool IsLevelCompleted()
        {            
            foreach(CellForBox cell in GameObjects.Cells)
            {
                bool boxInSell = false;

                foreach(Box box in GameObjects.Boxes)
                {
                    if((box.X == cell.X) && (box.Y == cell.Y))
                    {
                        boxInSell = true;
                    }
                }
                if(!boxInSell)
                {
                    return false;
                }
            }
            return true;
        }

        public void Update()
        {
            if(IsLevelCompleted())
            {
                StartNextLevel();
            }
        }

    }
}