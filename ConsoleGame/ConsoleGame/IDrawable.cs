using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal interface IDrawable : IElement
    {
        /// <summary>
        /// Defines the elements Position on the screen
        /// <remarks>Must not be set by value or else all both elements' position will be set if one value is changed</remarks>
        /// </summary>
        Position Position { get; }
        /// <summary>
        /// Defines the elements' Character on the screen
        /// </summary>
        char Sign { get; set;}
        /// <summary>
        /// Sets the elements' Color on the Screen, Defaults to White
        /// </summary>
        ConsoleColor Color { get; set; }

        void SetPosition(double x, double y);
        void SetSign(char c);
    }
}
