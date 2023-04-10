using BoardGame1.BoardGame1;
using BoardGame1.Core;
using Kernel;

namespace ConsoleApp
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

            IGame game = new MainGame();
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

        public void StartNewGame(IGame game)
        {
            Console.WriteLine("\n");
            Console.WriteLine(" Now press the number of the level you want to play: ");

            var key = Console.ReadKey(true);

            bool valid = int.TryParse(key.KeyChar.ToString(), out int level);
            if (!valid) level = 0;
            else level--;

            game.NewGame(level);
        }

        public void LoadGame(IGame game)
        {
            game.LoadGame();
        }
    }
}