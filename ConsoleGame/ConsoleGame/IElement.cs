﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    interface IElement
    {
        bool MarkedForDeletion { get; set; }

        void Update();
    }
}
