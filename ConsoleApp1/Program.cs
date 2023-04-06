using ConsoleApp1.Gameplay;
using ConsoleApp1.Input;

namespace ConsoleApp1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            InputProvider inputProvider = new InputProvider();
            GameStateController gameState = new GameStateController(3, 2);

            while (gameState.IsRunning)
            {
                Console.Clear();

                inputProvider.Display();
                gameState.Display();

                var newInput = inputProvider.GetInput();
                gameState.ApplyInput(newInput);

            }

            return 0;
        }
    }
}