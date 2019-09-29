using System;
using Sokoban.Model;

namespace TestProject
{
    class Program
    {
        static void Main()
        {
            var level = new LevelManager();
            foreach(var pair in level.SeriesInfo)
            {
                Console.WriteLine(pair.Key);
                foreach(var nameLevel in pair.Value)
                {
                    Console.WriteLine("     " + nameLevel);
                }
            }
            Console.ReadKey();
        }
    }
}
