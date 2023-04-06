using ConsoleApp1.Gameplay;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            RunGame();

            return 0;
        }

        private static void RunGame()
        {
            Game game = new Game();
            game.Initialize();

            //StartNewGame(game);
            LoadGame(game);

            while (game.IsRunning)
            {
                game.Tick();
            }

            game.Finish();
        }


        private static void StartNewGame(Game game)
        {
            game.NewGame(4, 2);
        }

        private static void LoadGame(Game game)
        {
            GameStatePersistence gameStatePersistence = new()
            {
                map = new()
                {
                    size = 5
                },
                player = new()
                {
                    currentPosition = 1
                }
            };
            game.Load(gameStatePersistence);
        }
    }

}