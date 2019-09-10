using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    interface IMovable
    {
        void Move(Direction directon);
    }
}
