using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Spider : ICharacter
    {
        public double MaxHealth { get; set; }
        public double CurrentHealth { get; set; }
        public Inventory Inventory { get; set; }
        public Position Position { get; private set; }
        public char Sign { get; set; }
        public ConsoleColor Color { get; set; }

        public bool MarkedForDeletion { get; set; }

        private DateTime LastUpdate { get; set; }
        private Random RandomGenerator { get; set; }

        public Spider()
        {
            MaxHealth = 4d;
            CurrentHealth = MaxHealth;
            Position = new Position { X = 0, Y = 0 };
            Color = ConsoleColor.Red;
            Sign = 'M';
            MarkedForDeletion = false;
            LastUpdate = DateTime.Now;
            RandomGenerator = new Random();
        }

        public void SetPosition(double x, double y)
        {
            Position.X = x;
            Position.Y = y;
        }

        public void SetSign(char c)
        {
            Sign = c;
        }

        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    if (Position.Y - 1 > 0)
                        Position.Y -= 1;
                    break;
                case MoveDirection.Right:
                    if (Position.X + 1 < Console.WindowWidth)
                        Position.X += 1;
                    break;
                case MoveDirection.Down:
                    if (Position.Y + 1 < Console.WindowHeight)
                        Position.Y += 1;
                    break;
                case MoveDirection.Left:
                    if (Position.X - 1 > 0)
                        Position.X -= 1;
                    break;
            }
        }

        public void Update()
        {
            if (DateTime.Now - LastUpdate > new TimeSpan(0, 0, 1))
            {
                switch (RandomGenerator.Next(0, 4))
                {
                    case 0: 
                        Move(MoveDirection.Up);
                        break;
                    case 1:
                        Move(MoveDirection.Right);
                        break;
                    case 2:
                        Move(MoveDirection.Down);
                        break;
                    case 3:
                        Move(MoveDirection.Left);
                        break;
                    default: break;
                }
                LastUpdate = DateTime.Now;
            }
        }
    }
}
