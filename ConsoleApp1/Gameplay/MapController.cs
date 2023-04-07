namespace ConsoleApp1.Gameplay
{
    internal class MapController : 
        Controller<MapState, MapDisplay>
    {
        private MapData _data;

        public Vector2Int Size => _data.size;
        public int[,] Map => _state.map;

        public MapController()
        {
            _state = new MapState();
            _display = new MapDisplay(this);

            _data = new MapData();
        }

        public void StartClean(LevelData data)
        {
            _data = data.Map;

            _state = new MapState();
            _state.StartClean(data);
        }

    }
}
