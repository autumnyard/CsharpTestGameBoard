using ConsoleApp1.Display;
using ConsoleApp1.Gameplay;
using ConsoleApp1.Input;

namespace ConsoleApp1.Core
{
    internal class GameController : IPersistable<GameStatePersistence>
    {
        private Displayer _displayer;
        private InputProvider _inputProvider;
        private GameStateController _gameState;

        public bool IsRunning => _gameState.IsRunning;

        public void Initialize()
        {
            _inputProvider = new InputProvider();

            _displayer = new Displayer();
            _displayer.AddDisplayable(_inputProvider);

            _gameState = new GameStateController();
            _displayer.AddDisplayable(_gameState);
        }

        public void NewGame(int level)
        {
            _gameState.NewGame(level);
        }

        public void Load(GameStatePersistence persistence)
        {
            _gameState.Load(persistence);
        }

        public GameStatePersistence Save()
        {
            return _gameState.Save();
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
