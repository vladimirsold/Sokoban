
using System;
using System.Collections.Generic;
using System.IO;

namespace Sokoban.Model
{
    class LevelLoader
    {     
        public static (HashSet<Wall>, HashSet<Box>, HashSet<CellForBox>, Storekeeper, Vector) LoadLevel(Level level)
        {
            var walls = new HashSet<Wall>();
            var boxes = new HashSet<Box>();
            var cells = new HashSet<CellForBox>();
            Storekeeper storekeeper = null;
            StreamReader fileReader = LoadSeries(level.Series);
            GameObject[,] field;
            using(fileReader)
            {
                
                while(!fileReader.ReadLine().Contains($"Maze: {level.NumberOfLevel}"))
                {
                    ;
                }

                fileReader.ReadLine();
                int x = int.Parse(fileReader.ReadLine().Split(' ')[2]);
                int y = int.Parse(fileReader.ReadLine().Split(' ')[2]);
                field = new GameObject[x, y];
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
                                field[i, j] = new Wall(i, j);
                                break;
                            case '@':
                                field[i, j] = new Storekeeper(i, j);
                                break;
                            case '*':
                                field[i, j] = new Box(i, j);
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
            return (walls, boxes, cells, storekeeper, fieldSize);
        }

        static StreamReader LoadSeries(Series series)
        {
            switch(series)
            {
                default:  return new StreamReader("C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\ThinkingRabbitOriginal.txt");
                case Series.Test:
                    return new StreamReader("C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\Test.txt");
            }
        }

        public static Level NextLevel(Level level)
        {
            return new Level(level.Series, level.NumberOfLevel + 1);
        }
    }
}
