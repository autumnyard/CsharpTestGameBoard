namespace ConsoleApp1.Gameplay
{
    internal class MapController : 
        Controller<MapState, MapDisplay>
    {
        private Vector2Int _size;
        private int[,] _map;

        public Vector2Int Size => _size;
        public int[,] Map => _map;

        public MapController()
        {
            _state = new MapState();
            _display = new MapDisplay(this);
        }

        public void SetMap(Vector2Int size)
        {
            _size = new Vector2Int(size);
            _map = new int[_size.X, _size.Y];
        }
    }
}
