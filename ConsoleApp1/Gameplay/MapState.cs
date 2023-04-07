
namespace ConsoleApp1.Gameplay
{
    internal class MapState : State,
        IPersistable<MapState>
    {
        public int[,] map;


        private void CreateNewMap(Vector2Int size)
        {
            map = new int[size.X, size.Y];
        }

        private void SetMap(Vector2Int size)
        {
            map = new int[size.X, size.Y];
        }

        public void StartClean(LevelData data)
        {
            CreateNewMap(data.Map.size);
        }

        public void Load(MapState persistence)
        {
            map = persistence.map;
        }

        public MapState Save()
        {
            return this;
        }
    }
}
