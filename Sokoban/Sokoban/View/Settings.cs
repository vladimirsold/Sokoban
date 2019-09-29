using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.View
{
    class Settings
    {
        private static Settings instance;
        public int DefaultBlockSize { get; private set; }
        public int HeightWindow { get; private set; }
        public int WidthWindow { get; private set; }

        Settings()
        {
            DefaultBlockSize = 40;
            HeightWindow = 900;
            WidthWindow = 1200;
        }

        public static Settings GetSettings()
        {
            if(instance == null)
                instance = new Settings();
            return instance;
        }
    }
}
