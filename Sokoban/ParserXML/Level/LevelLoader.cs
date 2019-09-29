using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
namespace Sokoban.Model
{
    class LevelLoader
    {

        public static void LoadLevel(Level level)
        {
            XmlDocument serie = LoadSerie(level.Series);
            LoadLevelFromSerie(serie, "Go gack");
        }
        public static void LoadLevelFromSerie(XmlDocument serie, string levelName)
        {
            XmlNode nodeOfLevel = serie.SelectSingleNode($"//Level[@Id ='{levelName}']");
            int width = int.Parse(nodeOfLevel.Attributes["Width"].Value);
            int height = int.Parse(nodeOfLevel.Attributes["Height"].Value);
            foreach(XmlNode e in nodeOfLevel.ChildNodes)
            {
                Console.WriteLine(e.InnerText);
            }


            Console.WriteLine(width + " " + height);
        }
        
        static XmlDocument LoadSerie(Series serie)
        {
            var xml = new XmlDocument();
             string path;
            switch(serie)
            {
                default:
                    path = "C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\Aruba7.slc";
                    break;
                case Series.Test:
                    path = "C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\Test.txt";
                    break;
            }
            xml.Load(path);
            return xml;
        }

        public static Level NextLevel(Level level)
        {
            return new Level(level.Series, level.NumberOfLevel + 1);
        }
    }
}
