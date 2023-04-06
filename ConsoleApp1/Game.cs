using ConsoleApp1.Display;
using ConsoleApp1.Gameplay;
using ConsoleApp1.Input;

namespace ConsoleApp1
{
    internal class Game
    {
        private Displayer _displayer;
        private InputProvider _inputProvider;
        private GameStateController _gameState;

        public bool IsRunning => _gameState.IsRunning;

        public void Initialize()
        {
            _inputProvider = new InputProvider();
            _gameState = new GameStateController(3, 2);

            _displayer = new Displayer();
            _displayer.AddDisplayable(_inputProvider);
            _displayer.AddDisplayable(_gameState);
        }

        public void Tick()
        {
            Console.Clear();

            _displayer.Display();

            _inputProvider.GetInput(out var newInput);

            _gameState.ApplyInput(newInput);

        }

        public void Finish()
        {
            _displayer.RemoveDisplayable(_gameState);
            _displayer.RemoveDisplayable(_inputProvider);
        }
    }
}
