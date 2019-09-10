using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    interface ISokobanGameModel
    {
        void Move(Direction direction);
        void Restart();
        void Update();


    }
}
