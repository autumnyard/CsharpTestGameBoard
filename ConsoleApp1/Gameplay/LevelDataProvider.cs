
namespace ConsoleApp1.Gameplay
{
    internal class LevelDataProvider
    {
        private LevelData[] _levels;

        public LevelDataProvider()
        {
            _levels = new LevelData[]
            {
                new LevelData(4,2),
                new LevelData(6,2),
            };
        }

        public bool TryGet(int levelNumber, out LevelData data)
        {
            data = new();

            if (_levels == null) return false;
            if (_levels.Length < levelNumber) return false;

            data = _levels[levelNumber];
            return true;
        }
    }
}
