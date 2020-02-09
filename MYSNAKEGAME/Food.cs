using System;
namespace MYSNAKEGAME // Created by: Joshua C. Magoliman
{
    class Food
    {
        public int View { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Food()
        {
            Random generator = new Random();
            this.View = generator.Next(0, 9);
            this.X = generator.Next(1, 78);
            this.Y = generator.Next(1, 22);
        }
        public void Appear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.View);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Disappear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(" ");
        }
    }
}
