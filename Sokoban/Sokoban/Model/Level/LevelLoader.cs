
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Sokoban.Model
{
    class LevelLoader
    {     
        public static Field LoadLevel(Level level)
        {
            XmlDocument serie = LoadSerie(level.Series);
            var field = LoadLevelFromSerie(serie);
            return field;
        }

        private static Field LoadLevelFromSerie(XmlDocument serie)
        {
            var root = serie.DocumentElement;
            foreach(var )

        }

        static XmlDocument LoadSerie(Series serie)
        {
            XmlDocument xmlSerie = new XmlDocument();
            string path;
            switch(serie)
            {
                default:
                    path ="C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\ThinkingRabbitOriginal.txt";
                    break;
                case Series.Test:
                    path ="C:\\Users\\Владимир\\source\\repos\\vladimirsold\\Sokoban\\Sokoban\\Sokoban\\Content\\Test.txt";
                    break;
            }
            xmlSerie.Load(path);
            return xmlSerie;
        }

        public static Level NextLevel(Level level)
        {
            return new Level(level.Series, level.NumberOfLevel + 1);
        }
    }
}
