﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Position
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Position()
        {
            X = 0;
            Y = 0;
        }

        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Position(Position pos)
        {
            X = pos.X;
            Y = pos.Y;
        }
    }
}
