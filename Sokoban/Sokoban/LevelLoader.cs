using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class LevelLoader
    {
        private string path;

        public LevelLoader(string path)
        {
            this.path = path;
        }

        public GameObjects LoadLevel(int level)
        {
            int tmpLevel = level;
            if(tmpLevel > 60)
                tmpLevel -= 60;
            var walls = new HashSet<Wall>();
            var boxes = new HashSet<Box>();
            var cells = new HashSet<CellForBox>();
            Player player = null;
            try
            {
                StreamReader fileReader = new StreamReader("C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\Levels.txt");
                int cellSize = Model.FieldSellSize;
                int x0 = cellSize / 2;
                int y0 = cellSize / 2;
                while(!fileReader.ReadLine().Contains($"Maze: {level}")) ;
                fileReader.ReadLine();
                fileReader.ReadLine();
                double y = double.Parse(fileReader.ReadLine().Split(' ')[2]);
                fileReader.ReadLine();
                fileReader.ReadLine();
                fileReader.ReadLine();
                for(int i = 0; i < y; i++)
                {
                    string read = fileReader.ReadLine();
                    for(int j = 0; j < read.Length; j++)
                        switch(read[j])
                        {
                            case 'X':
                                walls.Add(new Wall(x0 + j * cellSize, y0 + i * cellSize));
                                break;
                            case '@':
                                player = new Player(x0 + j * cellSize, y0 + i * cellSize);
                                break;
                            case '*':
                                boxes.Add(new Box(x0 + j * cellSize, y0 + i * cellSize));
                                break;
                            case '.':
                                cells.Add(new CellForBox(x0 + j * cellSize, y0 + i * cellSize));
                                break;
                            case '&':
                                cells.Add(new CellForBox(x0 + j * cellSize, y0 + i * cellSize));
                                boxes.Add(new Box(x0 + j * cellSize, y0 + i * cellSize));
                                break;
                        }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new GameObjects(walls, boxes, cells, player);
        }
    }
}
