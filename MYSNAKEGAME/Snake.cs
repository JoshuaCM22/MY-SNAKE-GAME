using System;
using System.Collections.Generic;
namespace MYSNAKEGAME // Created by: Joshua C. Magoliman
{
    static class Snake
    {
        private static readonly List<Part> snake = new List<Part>();
        public static Directions directions;
        public static void StartingPointSnake()
        {
            for (int i = 1; i < 6; i++)
            {
                Part part = new Part
                {
                    Xaxis = i,
                    Yaxis = 5
                };
                snake.Add(part);
            }
            directions = Directions.right;
            DrawSnake();
        }
        public static void SnakeMoveRight()
        {
            ClearPart(snake[0]);
            snake.RemoveAt(0);
            Part part = new Part
            {
                Yaxis = snake[snake.Count - 1].Yaxis,
                Xaxis = snake[snake.Count - 1].Xaxis + 1
            };
            snake.Add(part);
            DrawPart(part);
        }
        public static void SnakeMoveLeft()
        {
            ClearPart(snake[0]);
            snake.RemoveAt(0);
            Part part = new Part
            {
                Yaxis = snake[snake.Count - 1].Yaxis,
                Xaxis = snake[snake.Count - 1].Xaxis - 1
            };
            snake.Add(part);
            DrawPart(part);
        }
        public static void SnakeMoveUp()
        {
            ClearPart(snake[0]);
            snake.RemoveAt(0);
            Part part = new Part
            {
                Yaxis = snake[snake.Count - 1].Yaxis - 1,
                Xaxis = snake[snake.Count - 1].Xaxis
            };
            snake.Add(part);
            DrawPart(part);
        }
        public static void SnakeMoveDown()
        {
            ClearPart(snake[0]);
            snake.RemoveAt(0);
            Part part = new Part
            {
                Yaxis = snake[snake.Count - 1].Yaxis + 1,
                Xaxis = snake[snake.Count - 1].Xaxis
            };
            snake.Add(part);
            DrawPart(part);
        }
        public static void ClearPart(Part part)
        {
            Console.SetCursorPosition(part.Xaxis, part.Yaxis);
            Console.Write(" ");
        }
        public static void DrawPart(Part part)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(part.Xaxis, part.Yaxis);
            Console.Write("*");
        }
        public static void DrawSnake()
        {
            foreach (var item in snake)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(item.Xaxis, item.Yaxis);
                Console.Write("*");
            }
        }
        public static void ClearSnake()
        {
            for (int i = 0; i < snake.Count; i++)
            {
                ClearPart(snake[i]);
            }
            snake.Clear();
        }
        public static bool Move()
        {
            switch (directions)
            {
                case Directions.right:
                    if (snake[snake.Count - 1].Xaxis >= 78)
                    {
                        return false;
                    }
                    SnakeMoveRight();
                    break;
                case Directions.left:
                    if (snake[snake.Count - 1].Xaxis <= 1)
                    {
                        return false;
                    }
                    SnakeMoveLeft();
                    break;
                case Directions.up:
                    if (snake[snake.Count - 1].Yaxis <= 1)
                    {
                        return false;
                    }
                    SnakeMoveUp();
                    break;
                case Directions.down:
                    if (snake[snake.Count - 1].Yaxis >= 22)
                    {
                        return false;
                    }
                    SnakeMoveDown();
                    break;
                default:
                    break;
            }
            return true;
        }
        public static void Grow()
        {
            Part part = new Part();
            switch (directions)
            {
                case Directions.right:
                    part.Yaxis = snake[snake.Count - 1].Yaxis;
                    part.Xaxis = snake[snake.Count - 1].Xaxis + 1;
                    break;
                case Directions.left:
                    part.Yaxis = snake[snake.Count - 1].Yaxis;
                    part.Xaxis = snake[snake.Count - 1].Xaxis - 1;
                    break;
                case Directions.up:
                    part.Yaxis = snake[snake.Count - 1].Yaxis - 1;
                    part.Xaxis = snake[snake.Count - 1].Xaxis;
                    break;
                case Directions.down:
                    part.Yaxis = snake[snake.Count - 1].Yaxis + 1;
                    part.Xaxis = snake[snake.Count - 1].Xaxis;
                    break;
                default:
                    break;
            }
            snake.Add(part);
            DrawPart(part);
        }
        public static bool CheckColission(int x, int y)
        {
            for (int i = 0; i < snake.Count; i++)
            {
                if (snake[i].Xaxis == x && snake[i].Yaxis == y)
                {
                    return true;
                }
            }
            return false;
        }
        internal static bool CheckForSelfColission()
        {
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[0].Xaxis == snake[i].Xaxis && snake[0].Yaxis == snake[i].Yaxis)
                {
                    return true;
                }
            }
            return false;
        }
    }
}