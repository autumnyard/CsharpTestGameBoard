
namespace ConsoleApp
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