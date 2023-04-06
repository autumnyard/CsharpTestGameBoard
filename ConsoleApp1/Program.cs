using ConsoleApp1.Display;
using ConsoleApp1.Gameplay;
using ConsoleApp1.Input;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Displayer displayer = new Displayer();

            InputProvider inputProvider = new InputProvider();
            displayer.AddDisplayable(inputProvider);

            GameStateController gameState = new GameStateController(3, 2);
            displayer.AddDisplayable(gameState);

            while (gameState.IsRunning)
            {
                Console.Clear();

                displayer.Display();

                inputProvider.GetInput(out var newInput);
                gameState.ApplyInput(newInput);

            }

            displayer.RemoveDisplayable(gameState);
            displayer.RemoveDisplayable(inputProvider);

            return 0;
        }
    }

}