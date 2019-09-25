using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Level
    {
        public Series Series { get; private set; }
        public string Name { get; private set; }

        public Level(Series series, string name)
        {
            Series = series;
            Name = name;
        }
    }
}
