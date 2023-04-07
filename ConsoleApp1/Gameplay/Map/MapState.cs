namespace ConsoleApp1.Gameplay.Map
{
    internal class MapState : BaseState,
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

        public void StartClean(MapData data)
        {
            CreateNewMap(data.size);
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
