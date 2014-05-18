using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleGame
{
    class Controller
    {
        internal static string GameTitle = "UberGame 0.1";
        internal static double Points = 0;

        private Thread MainThread { get; set; }
        private ConsoleController ConsoleController { get; set; }
        private Player Player { get; set; }
        private List<IDrawable> Drawables { get; set; }

        public Controller()
        {
            MainThread = new Thread(new ParameterizedThreadStart(this.GameLoop));
            Drawables = new List<IDrawable>();

            Player = new Player();
            Player.SetPosition(1, 1);
            Drawables.Add(Player);

            ConsoleController = new ConsoleController(this);
            ConsoleController.InitializeConsole();
            ConsoleController.InputRead += ConsoleController_InputRead;
        }

        void ConsoleController_InputRead(ConsoleController sender, InputEventArgs args)
        {
            switch (args.KeyInfo.Key)
            {
                case ConsoleKey.A:
                    Player.Move(MoveDirection.Left);
                    break;
                case ConsoleKey.D:
                    Player.Move(MoveDirection.Right);
                    break;
                case ConsoleKey.S:
                    Player.Move(MoveDirection.Down);
                    break;
                case ConsoleKey.W:
                    Player.Move(MoveDirection.Up);
                    break;
                case ConsoleKey.UpArrow:
                    Drawables.Add(Player.Shoot(MoveDirection.Up));
                    break;
                case ConsoleKey.RightArrow:
                    Drawables.Add(Player.Shoot(MoveDirection.Right));
                    break;
                case ConsoleKey.DownArrow:
                    Drawables.Add(Player.Shoot(MoveDirection.Down));
                    break;
                case ConsoleKey.LeftArrow:
                    Drawables.Add(Player.Shoot(MoveDirection.Left));
                    break;
                case ConsoleKey.N:
                    Drawables.Add(new Spider());
                    break;
                default: break;
            }
        }

        internal void Start()
        {
            MainThread.Start();
            ConsoleController.HandleInput();
        }

        internal void GameLoop(object param)
        {
            while (true)
            {
                try
                {
                    //to achieve 60 iterations per second
                    //Thread.Sleep(16);
                    
                    //should be equal to 30 fps
                    Thread.Sleep(33);

                    Console.Clear();

                    int drawn = 0;

                    for (int i = 0; i < Drawables.Count; i++)
                    {
                        IDrawable unit = Drawables[i];

                        unit.Update();

                        if (unit.Position.X > 0 && unit.Position.Y > 0 && 
                            unit.Position.X < Console.WindowWidth - 1 && 
                            unit.Position.Y < Console.WindowHeight)
                        {
                            //Console.ForegroundColor = unit.Color != null ? unit.Color : ConsoleColor.White;
                            Console.ForegroundColor = unit.Color;
                            Console.SetCursorPosition((int)unit.Position.X, (int)unit.Position.Y);
                            Console.Write(unit.Sign);
                            Console.ResetColor();
                            drawn++;
                        }

                        if (unit.MarkedForDeletion)
                        {
                            Drawables.RemoveAt(i);
                            Debug.WriteLine("Removed " + unit.ToString());
                        }

                        //Debug.WriteLine(unit.ToString() + " " + unit.Position.X + " " + unit.Position.Y);
                    }

                    Console.SetCursorPosition(1, Console.WindowHeight - 2);
                    Console.Write(drawn + " items drawn");
                    Console.SetCursorPosition(1, Console.WindowHeight - 1);
                    Console.Write(Points + " points");
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}