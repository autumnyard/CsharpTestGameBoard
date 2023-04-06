using ConsoleApp1.Display;
using ConsoleApp1.Input;
using System.Text;

namespace ConsoleApp1.Gameplay
{
    internal class GameStateController : IDisplayable, IPersistable<GameStatePersistence>
    {
        private MapController _map;
        private PlayerController _player;
        private bool _isRunning;

        public bool IsRunning => _isRunning;

        public void NewGame(int mapSize, int playerSpawnPosition)
        {
            if (mapSize < playerSpawnPosition)
                playerSpawnPosition = mapSize;

            _map = new MapController();
            _map.NewGame(mapSize);


            _player = new PlayerController();
            _player.NewGame(playerSpawnPosition);

            _isRunning = true;
        }

        public void Load(GameStatePersistence save)
        {
            _map = new MapController();
            _map.Load(save.map);

            _player = new PlayerController();
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


        public void ApplyInput(eInputAction action)
        {
            switch (action)
            {
                case eInputAction.MoveLeft:
                case eInputAction.MoveRight:
                    _player.ApplyInput(action, in _map);
                    break;

                case eInputAction.Exit:
                    _isRunning = false;
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
