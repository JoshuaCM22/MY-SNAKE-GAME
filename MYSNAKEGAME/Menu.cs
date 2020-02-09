using System;
using System.Text;
using System.Threading;
namespace MYSNAKEGAME // Created by: Joshua C. Magoliman
{
    static class Menu
    {
        public static void RunMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(4, 3);
            Console.Write("MECHANICS: GET ALL THE NUMBERS AND AVOID TO COLLIDE IN ANY SIDE OF SQUARE");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(4, 5);
            Console.Write("CONTROLS: LEFT ARROW KEY, UP ARROW KEY, RIGHT ARROW KEY, DOWN ARROW KEY");
            Console.Write("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(32, 9);
            Console.Write("OPTIONS:");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(32, 11);
            Console.Write("1 = Start new game");
            Console.SetCursorPosition(32, 12);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("2 = Hall of Fame");
            Console.SetCursorPosition(32, 13);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("3 = Exit");
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Game.StartNewGame();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    HallOfFame.Show();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    ExitQuestion();
                    break;
                default:
                    Console.Clear();
                    RunMenu();
                    break;
            }
        }
        public static void ExitQuestion()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(25, 5);
            Console.WriteLine("You want to exit the game?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(31, 7);
            Console.WriteLine("PRESS: Y OR N");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(29, 9);
            Console.WriteLine("Y = YES and N = No");
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            var userPressed = Console.ReadKey();
            switch (userPressed.Key)
            {
                case ConsoleKey.Y:
                    Console.Clear();
                    ExitUserInterface();
                    Thread.Sleep(2000);
                    Console.Clear();
                    return;
                case ConsoleKey.N:
                    Console.Clear();
                    RunMenu();
                    break;
                default:
                    Console.Clear();
                    ExitQuestion();
                    break;
            }
        }
        private static void ExitUserInterface()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("          |||||||     |||     ||        ||       ||    ||    |||||||                                 ");
            Console.WriteLine("          ||          || |    ||      ||  ||     ||   ||     ||                                      ");
            Console.WriteLine("          ||          ||  |   ||     ||    ||    ||  ||      ||                                      ");
            Console.WriteLine("          |||||||     ||   |  ||     ||||||||    ||||||      |||||||                                 ");
            Console.WriteLine("               ||     ||    | ||     ||    ||    ||  ||      ||                                      ");
            Console.WriteLine("               ||     ||     |||     ||    ||    ||   ||     ||                                      ");
            Console.WriteLine("          |||||||     ||      ||     ||    ||    ||    ||    |||||||                                 ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                                                     ");
            Console.WriteLine("               |||||||        ||       ||       ||    |||||||                                        ");
            Console.WriteLine("               ||           ||  ||     |||     |||    ||                                             ");
            Console.WriteLine("               ||  |||     ||||||||    || || || ||    |||||||                                        ");
            Console.WriteLine("               ||   ||     ||    ||    ||   ||  ||    ||                                             ");
            Console.WriteLine("               |||||||     ||    ||    ||       ||    |||||||                                        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("                                   BYE BYE...");
        }
    }
}
