// See https://aka.ms/new-console-template for more information

using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            BoardController board = new BoardController(3, 2);
            board.Print();

            bool isPlaying = true;

            while (isPlaying)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        isPlaying = false;
                        break;

                    default:
                        break;
                }
            }


            return 0;
        }
    }
}