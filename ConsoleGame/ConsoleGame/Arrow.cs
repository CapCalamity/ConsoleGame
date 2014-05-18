using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Arrow : IProjectile
    {

        public MoveDirection Direction { get; set; }
        public double Speed { get; set; }
        public double Damage { get; set; }
        public Position Position { get; private set; }
        public char Sign { get; set; }
        public ConsoleColor Color { get; set; }
        public bool MarkedForDeletion { get; set; }

        public Arrow(MoveDirection direction, Position pos)
        {
            switch (direction)
            {
                case MoveDirection.Up:
                    Sign = '^';
                    break;
                case MoveDirection.Right:
                    Sign = '>';
                    break;
                case MoveDirection.Down:
                    Sign = 'v';
                    break;
                case MoveDirection.Left:
                    Sign = '<';
                    break;
            }

            Direction = direction;
            Color = ConsoleColor.DarkGreen;
            Speed = 2d;
            Position = new Position { X = pos.X, Y = pos.Y };
            MarkedForDeletion = false;
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
            switch (Direction)
            {
                case MoveDirection.Up:
                    Position.Y -= Speed;
                    break;
                case MoveDirection.Right:
                    Position.X += Speed;
                    break;
                case MoveDirection.Down:
                    Position.Y += Speed;
                    break;
                case MoveDirection.Left:
                    Position.X -= Speed;
                    break;
            }

            if (Position.X < 0 || Position.X > Console.WindowWidth || Position.Y < 0 || Position.Y > Console.WindowHeight)
            {
                MarkedForDeletion = true;
            }
        }
    }
}
