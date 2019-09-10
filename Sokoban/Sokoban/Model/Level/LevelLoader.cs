using System;
using System.Collections.Generic;
using System.IO;

namespace Sokoban.Model
{
    class LevelLoader
    {     
        public static ValueTuple<HashSet<Wall>, HashSet<Box>, HashSet<CellForBox>, Storekeeper, Vector> LoadLevel(Level level)
        {
            var walls = new HashSet<Wall>();
            var boxes = new HashSet<Box>();
            var cells = new HashSet<CellForBox>();
            Vector fieldSize = null; 
            Storekeeper storekeeper = null;
            try
            {
                StreamReader fileReader = LoadSeries(level.Series);
                while(!fileReader.ReadLine().Contains($"Maze: {level.NumberOfLevel}"))
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
                                storekeeper = new Storekeeper(j, i);
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
            return (walls, boxes, cells, storekeeper, fieldSize);
        }

        static StreamReader LoadSeries(Series series)
        {
            return new StreamReader("C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\Levels.txt");
        }

        public static Level NextLevel(Level level)
        {
            return new Level(level.Series, level.NumberOfLevel + 1);
        }
    }
}
