using ConsoleApp1.Display;
using ConsoleApp1.Input;

namespace ConsoleApp1.Gameplay
{
    internal class GameStateController : IDisplayable, IPersistable<GameStatePersistence>
    {
        private MapController _map;
        private PlayerController _player;
        private MovementValidator _movementValidator;
        private bool _isRunning;

        public bool IsRunning => _isRunning;

        public void NewGame(int mapSize, int playerSpawnPosition)
        {
            if (mapSize < playerSpawnPosition)
                playerSpawnPosition = mapSize;

            _map = new MapController();
            _movementValidator = new MovementValidator(_map);
            _player = new PlayerController(_movementValidator);

            _map.NewGame(mapSize);
            _player.NewGame(playerSpawnPosition);

            _isRunning = true;
        }

        public void Load(GameStatePersistence save)
        {
            _map = new MapController();

            _movementValidator = new MovementValidator(_map);
            _player = new PlayerController(_movementValidator);

            _map.Load(save.map);
            _player.Load(save.player);

            _isRunning = true;
        }

        public GameStatePersistence Save()
        {
            return new GameStatePersistence()
            {
                map = _map.Save(),
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
            _map.Display();
            _player.Display();
        }
    }
}
