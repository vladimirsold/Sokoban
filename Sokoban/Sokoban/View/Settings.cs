using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Settings
    {
        public int DefaultBlockSize { get; private set; }
        public int HeightWindow { get; private set; }
        public int WidthWindow { get; private set; }

        public Settings()
        {
            DefaultBlockSize = 32;
            HeightWindow = 900;
            WidthWindow = 1200;
        }
    }
}
