using System;
using System.Collections.Generic;
using System.IO;

namespace Sokoban
{
    class LevelLoader
    {
        private string path;

        public LevelLoader()
        {
            this.path = "C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\Levels.txt";
        }

        public GameObjects LoadLevel(int level)
        {
            int tmpLevel = level;
            var walls = new HashSet<Wall>();
            var boxes = new HashSet<Box>();
            var cells = new HashSet<CellForBox>();
            Vector fieldSize = null; 
            Player player = null;
            try
            {
                StreamReader fileReader = new StreamReader(path);
                while(!fileReader.ReadLine().Contains($"Maze: {level}"))
                {
                    ;
                }

                fileReader.ReadLine();
                int x = int.Parse(fileReader.ReadLine().Split(' ')[2]);
                int y = int.Parse(fileReader.ReadLine().Split(' ')[2]);
                fieldSize = new Vector(x, y);
                fileReader.ReadLine();
                fileReader.ReadLine();
                fileReader.ReadLine();
                for(int i = 0; i < y; i++)
                {
                    string read = fileReader.ReadLine();
                    for(int j = 0; j < read.Length; j++)
                    {
                        switch(read[j])
                        {
                            case 'X':
                                walls.Add(new Wall(j, i));
                                break;
                            case '@':
                                player = new Player(j, i);
                                break;
                            case '*':
                                boxes.Add(new Box(j, i));
                                break;
                            case '.':
                                cells.Add(new CellForBox(j, i));
                                break;
                            case '&':
                                cells.Add(new CellForBox(j, i));
                                boxes.Add(new Box(j, i));
                                break;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new GameObjects(walls, boxes, cells, player, fieldSize);
        }
    }
}
