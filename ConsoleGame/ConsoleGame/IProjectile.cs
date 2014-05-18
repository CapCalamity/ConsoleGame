using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    interface IProjectile : IDrawable
    {
        MoveDirection Direction { get; set; }
        double Speed { get; set; }
        double Damage { get; set; }
    }
}
