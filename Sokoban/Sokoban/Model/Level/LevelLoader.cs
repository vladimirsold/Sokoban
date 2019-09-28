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
            XmlNode nodeOfLevel = serie.SelectSingleNode($"//Level[@Id ='{level.Name}']");
            Field field = CreateFieldFromNode(nodeOfLevel);
            return field;
        }

        private static Field CreateFieldFromNode(XmlNode nodeOfLevel)
        {
            int width = int.Parse(nodeOfLevel.Attributes["Width"].Value);
            int height = int.Parse(nodeOfLevel.Attributes["Height"].Value);
            var size = new Vector(height, width);
            var storeroom = new GameObject[height, width];
            Storekeeper storekeeper = null;
            var cellsForBoxes = new HashSet<CellForBox>();
            for(var i = 0; i < height; i++)
            {
                var str = nodeOfLevel.ChildNodes[i].InnerText;
                for(var j = 0; j < str.Length; j++)
                {
                    GameObject newObject = null;
                    switch(str[j])
                    {
                        case '#':
                            newObject = new Wall();
                            break;
                        case '$':
                            newObject = new Box();
                            break;
                        case '*':
                            newObject = new Box();
                            cellsForBoxes.Add(new CellForBox(i, j, storeroom));
                            break;
                        case '.':
                            cellsForBoxes.Add(new CellForBox(i, j, storeroom));
                            break;
                        case '+':
                            cellsForBoxes.Add(new CellForBox(i, j, storeroom));
                            storekeeper = new Storekeeper(new Vector(i, j), storeroom);
                            break;
                        case '@':
                            storekeeper = new Storekeeper(new Vector(i, j), storeroom);
                            break;
                    }
                    storeroom[i, j] = newObject;
                }
            }
            Field field = new Field(storeroom, cellsForBoxes, storekeeper, size);
            return field;
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
    }
}
