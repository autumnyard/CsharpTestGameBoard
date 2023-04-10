using BoardGame1.Map;
using BoardGame1.Player;
using Kernel.Gameplay;

namespace BoardGame1
{
    internal class LevelData : IData
    {
        private const int DEFAULT_MAP_SIZE = 4;
        private const int DEFAULT_PLAYER_SPAWN_POSITION = 1;
        private readonly MapData _map;
        private readonly PlayerData _player;

        public MapData Map => _map;
        public PlayerData Player => _player;

        public LevelData()
        {
            _map = new MapData()
            {
                size = new Vector2Int(DEFAULT_MAP_SIZE, DEFAULT_MAP_SIZE),
            };
            _player = new PlayerData()
            {
                playerSpawnPosition = new Vector2Int(DEFAULT_PLAYER_SPAWN_POSITION, DEFAULT_PLAYER_SPAWN_POSITION),
            };
        }

        public LevelData(Vector2Int mapSize, Vector2Int playerSpawnPosition)
        {
            if (!mapSize.Contains(playerSpawnPosition))
            {
                playerSpawnPosition = mapSize;
            }

            _map = new MapData()
            {
                size = mapSize,
            };
            _player = new PlayerData()
            {
                playerSpawnPosition = playerSpawnPosition,
            };
        }
    }
}
