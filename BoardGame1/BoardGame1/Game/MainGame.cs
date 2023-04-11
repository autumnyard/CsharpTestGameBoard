using BoardGame1.BoardGame1.Input;
using Kernel;
using Kernel.Display;
using Kernel.Gameplay;
using Kernel.Input;
using Serialization;

namespace BoardGame1.BoardGame1.Game
{
    public sealed class MainGame : IGame
    {
        private Displayer _displayer;
        private IInputProvider<eInputAction> _inputProvider;
        private GameLogic _logic;

        public bool IsRunning => _logic.IsRunning;


        public void Initialize()
        {
            _displayer = new Displayer();

            _inputProvider = new InputProvider();
            _displayer.AddDisplayable((IDisplayable)_inputProvider);

            _logic = new GameLogic();
            _displayer.AddDisplayable(_logic);
        }

        public void NewGame(int level)
        {
            _logic.NewGame(level);
        }

        public void LoadGame()
        {
            ISerializer serializer = new NewtonsoftJSONSerializer();
            serializer.Deserialize(Common.SAVE_PATH, typeof(GamePersistence), out var save);
            GamePersistence gameStatePersistence = (GamePersistence)save;
            _logic. Load(gameStatePersistence);
        }

        public void Tick()
        {
            Console.Clear();
            _displayer.Display();
            _inputProvider.GetInput(out var newInput);

            if (newInput == eInputAction.Save) SaveGame(this);

            _logic.ApplyInput(newInput);
        }

        private void SaveGame(IPersistable<GamePersistence> game)
        {
            Console.WriteLine($"Save game");

            ISerializer serializer = new NewtonsoftJSONSerializer();
            var save = _logic.Save();
            serializer.Serialize(Common.SAVE_PATH, save);
        }

        public void Finish()
        {
            _displayer.RemoveDisplayable(_logic);
            _displayer.RemoveDisplayable((IDisplayable)_inputProvider);
        }

    }
}
