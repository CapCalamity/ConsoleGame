using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    interface ICharacter : IDrawable
    {
        double MaxHealth { get; set; }
        double CurrentHealth { get; set; }
        Inventory Inventory { get; set; }

        void Move(MoveDirection direction);
    }
}
