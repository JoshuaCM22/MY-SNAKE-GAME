using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MYSNAKEGAME // Created by: Joshua C. Magoliman
{
    static class HallOfFame
    {
        private static readonly string file = "HallOfFame.txt";
        private static readonly List<HallOfFameEntry> entries = new List<HallOfFameEntry>();
        private static void GetHallOfFame()
        {
            entries.Clear();
            if (File.Exists(file))
            {
                StreamReader read = new StreamReader(file);
                using (read)
                {
                    string line = read.ReadLine();
                    while (line != null)
                    {
                        string[] res = line.Split();
                        HallOfFameEntry entry = new HallOfFameEntry
                        {
                            Name = res[0],
                            Score = int.Parse(res[1])
                        };
                        entries.Add(entry);
                        line = read.ReadLine();
                    }
                }
            }
        }
        public static bool CheckForFameResult(int result)
        {
            GetHallOfFame();
            if (result == 0)
            {
                return false;
            }
            if (entries.Count < 10)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    if (result > entries[i].Score)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static void EnterHallOfFame(HallOfFameEntry entry)
        {
            entries.Add(entry);
            if (entries.Count > 10)
            {
                int min = int.MaxValue;
                int pos = 0;
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].Score < min)
                    {
                        min = entries[i].Score;
                        pos = i;
                    }
                }
                entries.RemoveAt(pos);
            }
            SaveHallOfFame();
        }
        private static void SaveHallOfFame()
        {
            StreamWriter write = new StreamWriter(file, false);
            using (write)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    write.WriteLine("{0} {1}", entries[i].Name, entries[i].Score);
                }
            }
        }
        public static void Show()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(25, 3);
            Console.WriteLine("SNAKE GAME: HALL OF FAME");
            Console.SetCursorPosition(30, 5);
            Console.WriteLine("TOP 10 PLAYERS:");
            Console.ForegroundColor = ConsoleColor.White;
            GetHallOfFame();
            var list = from entry in entries
                       orderby entry.Score descending
                       select entry;
            int counter = 1;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(33, 7);
            Console.WriteLine("Name   Score");
            if (!File.Exists(file))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(25, 3);
                Console.WriteLine("SNAKE GAME: HALL OF FAME");
                Console.SetCursorPosition(30, 5);
                Console.WriteLine("TOP 10 PLAYERS:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(33, 7);
                Console.WriteLine("Name   Score");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(19, 11);
                Console.WriteLine("THE FILE HallOfFame.txt DOESN'T EXIST!");
            }
            else
            {
                if (new FileInfo(file).Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(31, 11);
                    Console.WriteLine("NO RECORD FOUND!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var item in list)
                    {
                        Console.SetCursorPosition(30, 7 + counter);
                        if (counter % 2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        if (counter % 3 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        Console.WriteLine("{0}) {1} = {2}", counter, item.Name, item.Score);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        counter++;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(33, 19);
            Console.WriteLine("PRESS: B");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(33, 20);
            Console.WriteLine("B = Back");
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            var userPressed = Console.ReadKey();
            switch (userPressed.Key)
            {
                case ConsoleKey.B:
                    Console.Clear();
                    Menu.RunMenu();
                    return;
                default:
                    Console.Clear();
                    Show();
                    break;
            }
        }
    }
}