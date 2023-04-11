using BoardGame1.BoardGame1.Input;
using BoardGame1.Map;
using BoardGame1.Player;
using Kernel.Display;
using Kernel.Gameplay;

namespace BoardGame1.BoardGame1.Game
{
    internal class GameLogic : IDisplayable, IPersistable<GamePersistence>
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
            Initialize(level);

            _map.Initialize();
            _player.Initialize();

            _isRunning = true;
        }

        #region IPersistable

        public void Load(GamePersistence persistence)
        {
            Initialize(persistence.level);

            _map.Initialize(persistence.map);
            _player.Initialize(persistence.player);

            _isRunning = true;
        }

        public GamePersistence Save()
        {
            return new GamePersistence(
                _currentLevel,
                _map.State.Save(),
                _player.State.Save());

        }

        #endregion // IPersistable

        private void Initialize(int level)
        {
            // Load from level data
            _currentLevel = level;
            _levelDataProvider = new LevelDataProvider();
            _levelDataProvider.TryGet(level, out var data);

            _map = new MapController(data);
            _movementValidator = new MovementValidator(_map);
            _player = new PlayerController(data, _movementValidator);
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


        #region IDisplayable

        public void Display()
        {
            _map.Display.Display(_map);
            _player.Display.Display(_player);
        }

        #endregion // IDisplayable

    }
}
