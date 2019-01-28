using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    interface IEventListener
    {
        void Move(Action action);
        void Restart();
        void StartNextLevel();
        void LevelCompleted(int level);
    }
}
