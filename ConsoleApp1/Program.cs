
namespace ConsoleApp1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Game game = new Game();
            game.Initialize();

            while (game.IsRunning)
            {
                game.Tick();
            }

            game.Finish();

            return 0;
        }
    }

}