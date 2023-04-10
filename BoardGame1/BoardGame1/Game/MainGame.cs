using BoardGame1.BoardGame1.Input;
using Kernel;
using Kernel.Display;
using Kernel.Gameplay;
using Kernel.Input;
using Serialization;

namespace BoardGame1.BoardGame1.Game
{
    public sealed class MainGame : IGame, IPersistable<GamePersistence>
    {
        private Displayer _displayer;
        private IInputProvider<eInputAction> _inputProvider;
        private MainGameLogic _mainGame;

        public bool IsRunning => _mainGame.IsRunning;


        public void Initialize()
        {
            _displayer = new Displayer();

            _inputProvider = new InputProvider();
            _displayer.AddDisplayable((IDisplayable)_inputProvider);

            _mainGame = new MainGameLogic();
            _displayer.AddDisplayable(_mainGame);
        }

        public void Finish()
        {
            _displayer.RemoveDisplayable(_mainGame);
            _displayer.RemoveDisplayable((IDisplayable)_inputProvider);
        }


        public void NewGame(int level)
        {
            _mainGame.NewGame(level);
        }

        public void LoadGame()
        {
            ISerializer serializer = new NewtonsoftJSONSerializer();
            serializer.Deserialize(Common.SAVE_PATH, typeof(GamePersistence), out var save);
            GamePersistence gameStatePersistence = (GamePersistence)save;
            Load(gameStatePersistence);
        }

        public void Tick()
        {
            Console.Clear();
            _displayer.Display();
            _inputProvider.GetInput(out var newInput);

            if (newInput == eInputAction.Save) SaveGame(this);

            _mainGame.ApplyInput(newInput);
        }

        private void SaveGame(IPersistable<GamePersistence> game)
        {
            Console.WriteLine($"Save game");

            ISerializer serializer = new NewtonsoftJSONSerializer();
            var save = game.Save();
            serializer.Serialize(Common.SAVE_PATH, save);
        }


        #region IPersistable

        public void Load(GamePersistence persistence)
        {
            _mainGame.Load(persistence);
        }

        public GamePersistence Save()
        {
            return _mainGame.Save();
        }

        #endregion // IPersistable

    }
}
