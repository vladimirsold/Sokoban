using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Sokoban.Model
{
    public class LevelLoader
    {
        public Storekeeper Storekeeper { get; private set; }
        public Point Size { get; private set; }
        public HashSet<CellForBox> CellsForBoxes { get; private set; }
        public HashSet<Box> Boxes { get; private set; }
        public HashSet<Wall> Walls { get; private set; }

        public void Load(Level level)
        {
            CellsForBoxes = new HashSet<CellForBox>();
            Boxes = new HashSet<Box>();
            Walls = new HashSet<Wall>();
            XmlDocument serie = new XmlDocument();
            serie.Load(level.PathToSerie);
            XmlNode nodeOfLevel = serie.SelectSingleNode($"//Level[@Id ='{level.Name}']");
            CreateGameObjectsFromNode(nodeOfLevel);
        }

        private void CreateGameObjectsFromNode(XmlNode nodeOfLevel)
        {
            SetSizeFromNode(nodeOfLevel);
            for(var i = 0; i < Size.X; i++)
            {
                var str = nodeOfLevel.ChildNodes[i].InnerText;
                for(var j = 0; j < str.Length; j++)
                {
                    ParseGameObjects(str[j], new Point(i, j));
                }
            }
        }

        private void ParseGameObjects(char symbol, Point coords)
        {
            switch(symbol)
            {
                case '#':
                    Walls.Add(new Wall(coords));
                    break;
                case '$':
                    Boxes.Add(new Box(coords));
                    break;
                case '*':
                    Boxes.Add(new Box(coords));
                    var cell = new CellForBox(coords);
                    cell.IsEmpty = false;
                    CellsForBoxes.Add(cell);
                    break;
                case '.':
                    CellsForBoxes.Add(new CellForBox(coords));
                    break;
                case '+':
                    CellsForBoxes.Add(new CellForBox(coords));
                    Storekeeper = new Storekeeper(coords);
                    break;
                case '@':
                    Storekeeper = new Storekeeper(coords);
                    break;
            }
        }

        private void SetSizeFromNode(XmlNode nodeOfLevel)
        {
            int width = int.Parse(nodeOfLevel.Attributes["Width"].Value);
            int height = int.Parse(nodeOfLevel.Attributes["Height"].Value);
            Size = new Point(height, width);
        }
    }
}
