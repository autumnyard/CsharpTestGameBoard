using ConsoleApp1.Gameplay;

namespace ConsoleApp1.Core
{
    internal class GameRunner
    {
        public int RunGame()
        {
            DisplayIntro();

            eStartGameMode startGameMode;
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.N:
                    startGameMode = eStartGameMode.NewGame;
                    break;

                case ConsoleKey.L:
                    startGameMode = eStartGameMode.Load;
                    break;

                default:
                    return 1;
            }

            Game game = new Game();
            game.Initialize();

            switch (startGameMode)
            {
                case eStartGameMode.NewGame:
                    StartNewGame(game);
                    break;

                case eStartGameMode.Load:
                    LoadGame(game);
                    break;
            }

            while (game.IsRunning)
            {
                game.Tick();
            }

            game.Finish();

            return 0;
        }

        private static void DisplayIntro()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  ========================");
            Console.WriteLine("    Welcome to Pablo's");
            Console.WriteLine("  ========================");
            Console.WriteLine("\n");
            Console.WriteLine(" Do you want to start a (N)ew game, or (L)oad a previous one?");
        }

        public void StartNewGame(Game game)
        {
            game.NewGame(4, 2);
        }

        public void LoadGame(Game game)
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