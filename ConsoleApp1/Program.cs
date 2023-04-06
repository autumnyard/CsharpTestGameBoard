using ConsoleApp1.Core;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            GameRunner game = new();
            int result = game.RunGame();

            return result;
        }
    }
}