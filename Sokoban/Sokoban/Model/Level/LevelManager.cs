using System;

namespace Sokoban.Model
{
    internal class LevelManager
    {
        internal static Level NextLevel(Level currentLevel)
        {
            return new Level(currentLevel.Series, currentLevel.Name);
        }
    }
}