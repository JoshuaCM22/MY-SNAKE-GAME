using System;
using System.Linq;
using System.Threading;
namespace MYSNAKEGAME // Created by: Joshua C. Magoliman
{
    static class Game
    {
        static bool inGame = true;
        static DateTime start = DateTime.Now;
        static Food food = new Food();
        static int score = 0;
        public static void StartNewGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            inGame = true;
            score = 0;
            Snake.StartingPointSnake();
            MakePlayground();
            food.Appear();
            Play();
        }
        private static void Play()
        {
            while (inGame)
            {
                CheckForInput();
                ResetFood();
                CheckForSelfColision();
                Move();
                IsFoodEaten();
                Thread.Sleep(100);
            }
        }
        private static void CheckForSelfColision()
        {
            if (Snake.CheckForSelfColission())
            {
                GameOver();
            }
        }
        private static void IsFoodEaten()
        {
            if (Snake.CheckColission(food.X, food.Y))
            {
                if (food.View == 0)
                {
                    Snake.ClearSnake();
                    Snake.StartingPointSnake();
                }
                else
                {
                    score += food.View;
                    Snake.Grow();
                    Console.SetCursorPosition(1, 24);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Your Score = {0}", score);
                }
                food = new Food();
                food.Appear();

            }
        }
        private static void ResetFood()
        {
            if (start <= DateTime.Now.Subtract(TimeSpan.FromSeconds(10)))
            {
                food.Disappear();
                start = DateTime.Now;
                food = new Food();
                food.Appear();
            }
        }
        private static void MakePlayground()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int x = 1; x < 79; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.WriteLine("=");
                Console.SetCursorPosition(x, 23);
                Console.WriteLine("=");
            }
            for (int i = 1; i < 23; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("|");
                Console.SetCursorPosition(79, i);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(1, 24);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Your Score = {0}", score);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void Move()
        {
            bool on = Snake.Move();
            if (!on)
            {
                GameOver();
            }
        }
        private static void GameOver()
        {
            inGame = false;
            Console.SetCursorPosition(35, 12);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER!");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White;
            Snake.ClearSnake();
            CheckResultInHallOfFame();
            Menu.RunMenu();
        }
        private static void CheckResultInHallOfFame()
        {
            if (HallOfFame.CheckForFameResult(score))
            {
                Console.Clear();
                Console.SetCursorPosition(6, 9);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Congratulations! You have now a place in Top 10 Hall of Fame Players");
                Console.SetCursorPosition(14, 11);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("REMINDER: Avoid space ' ', instead use underscore '_'");
                Console.SetCursorPosition(18, 13);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Please enter your name without space: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = true;
                string userNamed = Console.ReadLine();
                Console.CursorVisible = false;
                HallOfFameEntry entry = new HallOfFameEntry();
                string checkerUserNamed = userNamed.Substring(0, 2);
                int x;
                if (userNamed == "" || userNamed == " ")
                {
                    CheckResultInHallOfFame();
                }
                else if (Int32.TryParse(checkerUserNamed, out x))
                {
                    CheckResultInHallOfFame();
                }
                else if (userNamed != "" || userNamed != " ")
                {
                    if (userNamed.Contains(' '))
                    {
                        string[] res = userNamed.Trim().Split();
                        userNamed = res[0];
                    }
                    entry.Name = userNamed;
                    entry.Score = score;
                    HallOfFame.EnterHallOfFame(entry);
                }
            }
        }
        private static void CheckForInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (Snake.directions != Directions.right)
                    {
                        Snake.directions = Directions.left;
                    }
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (Snake.directions != Directions.left)
                    {
                        Snake.directions = Directions.right;
                    }
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (Snake.directions != Directions.down)
                    {
                        Snake.directions = Directions.up;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow && Snake.directions != Directions.up)
                {
                    Snake.directions = Directions.down;
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    inGame = false;
                }
            }
        }
    }
}
