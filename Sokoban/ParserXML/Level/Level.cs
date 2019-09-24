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
        public int NumberOfLevel { get; private set; }

        public Level(Series series, int numberOfLEvel)
        {
            Series = series;
            NumberOfLevel = numberOfLEvel;
        }
    }
}
