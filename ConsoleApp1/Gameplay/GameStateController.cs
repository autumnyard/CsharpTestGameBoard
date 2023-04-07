using ConsoleApp1.Display;
using ConsoleApp1.Input;

namespace ConsoleApp1.Gameplay
{
    internal class GameStateController : IDisplayable, IPersistable<GameStatePersistence>
    {
        private MapController _map;
        private PlayerController _player;
        private MovementValidator _movementValidator;
        private LevelDataProvider _levelDataProvider;
        private bool _isRunning;
        private int _currentLevel;

        public bool IsRunning => _isRunning;

        public void NewGame(int level)
        {
            _levelDataProvider = new LevelDataProvider();
            _map = new MapController();
            _movementValidator = new MovementValidator(_map);
            _player = new PlayerController(_movementValidator);

            // Load from level data
            _currentLevel = level;
            _levelDataProvider.TryGet(level, out var data);
            _map.SetMap(data.MapSize);
            _player.NewGame(data.PlayerSpawnPosition);

            _isRunning = true;
        }

        public void Load(GameStatePersistence save)
        {
            _levelDataProvider = new LevelDataProvider();
            _map = new MapController();
            _movementValidator = new MovementValidator(_map);
            _player = new PlayerController(_movementValidator);

            // Load data from level data
            _currentLevel = save.level;
            _levelDataProvider.TryGet(_currentLevel, out var data);
            _map.SetMap(data.MapSize);

            // Load state from persistence
            _player.Load(save.player);

            _isRunning = true;
        }

        public GameStatePersistence Save()
        {
            return new GameStatePersistence()
            {
                level = _currentLevel,
                player = _player.Save()
            };
        }

        private void Finish()
        {
            _isRunning = false;
        }


        public void ApplyInput(eInputAction action)
        {
            switch (action)
            {
                case eInputAction.MoveUp:
                case eInputAction.MoveDown:
                case eInputAction.MoveLeft:
                case eInputAction.MoveRight:
                    _player.ApplyInput(action);
                    break;

                case eInputAction.Exit:
                    Finish();
                    break;
            }
        }


        public void Display()
        {
            _map.Display.Display();
            _player.Display.Display();
        }
    }
}
