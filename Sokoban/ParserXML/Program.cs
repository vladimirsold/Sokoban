using System;
using Sokoban.Model;
namespace ParserXML
{
    class Program
    {
        static void Main(string[] args)
        {
            LevelLoader.LoadLevel(new Level(Series.ThinkingRabbitOriginal, 1));
        }
    }
}
