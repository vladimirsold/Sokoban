using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public class Level
    {
        public string SeriesName { get; private set; }
        public string Name { get; private set; }

        public Level(string series, string name)
        {
            SeriesName = series;
            Name = name;
        }
    }
}
