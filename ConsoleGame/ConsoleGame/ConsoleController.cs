using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConsoleGame
{
    class ConsoleController
    {
        private Controller Controller { get; set; }
        internal event InputHandler InputRead;
        internal delegate void InputHandler(ConsoleController sender, InputEventArgs args);

        public ConsoleController(Controller con)
        {
            Controller = con;
        }

        internal void InitializeConsole()
        {
            Console.CursorVisible = false;
            Console.TreatControlCAsInput = true;
            Console.Title = Controller.GameTitle;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(80,40);
        }

        internal void HandleInput()
        {
            while (true)
            {
                while (!Console.KeyAvailable) ;

                var key = Console.ReadKey(true);
                var eargs = new InputEventArgs(key);
                InputRead(this, eargs);
            }
        }
    }

    class InputEventArgs : EventArgs
    {
        public ConsoleKeyInfo KeyInfo { get; private set; }

        public InputEventArgs(ConsoleKeyInfo key)
        {
            KeyInfo = key;
        }
    }
}
