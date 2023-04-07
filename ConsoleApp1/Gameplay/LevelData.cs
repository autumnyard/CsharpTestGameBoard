
namespace ConsoleApp1.Gameplay
{
    internal class LevelData
    {
        private const int DEFAULT_MAP_SIZE = 4;
        private const int DEFAULT_PLAYER_SPAWN_POSITION = 1;
        private readonly Vector2Int _mapSize;
        private readonly Vector2Int _playerSpawnPosition;

        public Vector2Int MapSize => _mapSize;
        public Vector2Int PlayerSpawnPosition => _playerSpawnPosition;

        public LevelData()
        {
            _mapSize = new Vector2Int(DEFAULT_MAP_SIZE, DEFAULT_MAP_SIZE);
            _playerSpawnPosition = new Vector2Int(DEFAULT_PLAYER_SPAWN_POSITION, DEFAULT_PLAYER_SPAWN_POSITION);
        }

        public LevelData(Vector2Int mapSize, Vector2Int playerSpawnPosition)
        {
            _mapSize = mapSize;
            _playerSpawnPosition = playerSpawnPosition;

            if (!_mapSize.Contains(playerSpawnPosition))
            {
                _playerSpawnPosition = _mapSize;
            }
        }
    }
}
