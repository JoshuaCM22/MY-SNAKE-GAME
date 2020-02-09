using System;
using System.Text;
namespace MYSNAKEGAME // Created by: Joshua C. Magoliman
{
    static class Title
    {
        public static void DrawInterface()
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
            Console.WriteLine("                                Press Enter...");
            var userPressed = Console.ReadKey();
            switch (userPressed.Key)
            {
                case ConsoleKey.Enter:
                    Console.Clear();
                    Menu.RunMenu();
                    break;
                default:
                    Console.Clear();
                    DrawInterface();
                    break;
            }
        }
    }
}
