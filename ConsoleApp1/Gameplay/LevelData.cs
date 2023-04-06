
namespace ConsoleApp1.Gameplay
{
    internal class LevelData
    {
        private const int DEFAULT_MAP_SIZE = 4;
        private const int DEFAULT_PLAYER_SPAWN_POSITION = 1;
        private readonly int _mapSize;
        private readonly int _playerSpawnPosition;

        public int MapSize => _mapSize;
        public int PlayerSpawnPosition => _playerSpawnPosition;

        public LevelData()
        {
            _mapSize = DEFAULT_MAP_SIZE;
            _playerSpawnPosition = DEFAULT_PLAYER_SPAWN_POSITION;
        }

        public LevelData(int mapSize, int playerSpawnPosition)
        {
            _mapSize = mapSize;
            _playerSpawnPosition = playerSpawnPosition;

            if (_mapSize < playerSpawnPosition)
            {
                _playerSpawnPosition = _mapSize;
            }
        }
    }
}
