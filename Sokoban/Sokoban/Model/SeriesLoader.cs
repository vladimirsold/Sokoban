using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class SeriesLoader
    {
        public static StreamReader LoadSeries(Series series)
        {
            return new StreamReader("C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\Levels.txt");
        }
    }
}
