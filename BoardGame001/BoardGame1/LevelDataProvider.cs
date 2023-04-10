
namespace BoardGame1
{
    internal class LevelDataProvider
    {
        private LevelData[] _levels;

        public LevelDataProvider()
        {
            _levels = new LevelData[]
            {
                new LevelData(new Vector2Int(4,4), new Vector2Int(1,2)),
                new LevelData(new Vector2Int(7,5), new Vector2Int(3,2)),
            };
        }

        public bool TryGet(int levelNumber, out LevelData data)
        {
            data = new LevelData();

            if (_levels == null) return false;
            if (_levels.Length < levelNumber) return false;

            data = _levels[levelNumber];
            return true;
        }
    }
}
