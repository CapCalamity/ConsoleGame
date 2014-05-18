using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Player : ICharacter
    {
        public double MaxHealth { get; set; }
        public double CurrentHealth { get; set; }
        public Inventory Inventory { get; set; }
        public Position Position { get; private set; }
        public char Sign { get; set; }
        public ConsoleColor Color { get; set; }
        public bool MarkedForDeletion { get; set; }

        public Player()
        {
            Color = ConsoleColor.Yellow;
            Position = new Position(0, 0);
            Sign = '@';
            MarkedForDeletion = false;
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

        public Arrow Shoot(MoveDirection direction)
        {
            Arrow arr = new Arrow(direction, new Position { X = Position.X, Y = Position.Y });

            return arr;
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

        public void Update()
        {

        }
    }
}
