using ConsoleApp1.Display;
using ConsoleApp1.Input;
using System.Text;

namespace ConsoleApp1.Gameplay
{
    internal interface IPersistable<T>
    {
        void Load(T persistence);
        T Save();
    }
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
                    Console.WriteLine($"Move left {action}");
                    Move(eMovement.Left);
                    break;

                case eInputAction.MoveRight:
                    Console.WriteLine($"Move right {action}");
                    Move(eMovement.Right);
                    break;

                case eInputAction.Exit:
                    _isRunning = false;
                    break;
            }
        }

        public void Move(eMovement movement)
        {
            switch (movement)
            {
                case eMovement.Left:
                    _player.MoveLeft(in _map);
                    return;

                case eMovement.Right:
                    _player.MoveRight(in _map);
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
