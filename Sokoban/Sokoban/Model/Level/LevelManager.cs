using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Sokoban.Model
{
    public class LevelManager
    {
        readonly DirectoryInfo series;
        public Dictionary<string, List<string>> SeriesInfo { get; private set; }
        public string SeriesPath { get { return series.FullName; } }
        
        public LevelManager()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            series = new DirectoryInfo(path).GetDirectories().Single(dir => dir.Name.Contains("Resources"));
            SeriesInfo = LoadSeries(series);
        }

        private Dictionary<string, List<string>> LoadSeries(DirectoryInfo series)
        {
            var seriesInfo = new Dictionary<string, List<string>>();
            foreach(var serie in series.GetFiles())
            {
                var name = Path.GetFileNameWithoutExtension(serie.FullName);
                seriesInfo[name] = GetLevelsNames(serie);
            }
            return seriesInfo;
        }

        private List<string> GetLevelsNames(FileInfo serie)
        {
            var xmlSerie = new XmlDocument();
            xmlSerie.Load(serie.FullName);
            var levelNames = new List<string>();
            foreach(XmlNode level in xmlSerie.SelectNodes($"//Level"))
            {
                levelNames.Add(level.Attributes["Id"].Value);
            }
            return levelNames;
        }

        internal static Level NextLevel(Level currentLevel)
        {
            throw new NotImplementedException();
        }
    }
}