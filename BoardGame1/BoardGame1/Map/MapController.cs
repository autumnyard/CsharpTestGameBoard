using Kernel.Display;
using Kernel.Gameplay;

namespace BoardGame1.Map
{
    internal class MapController :
        BaseController<MapController, MapData, MapState, MapDisplay>,
        IDisplayable
    {
        public Vector2Int Size => _data.size;
        public int[,] Map => _state.map;

        public MapController(LevelData data)
            : base(data.Map, new MapDisplay(), new MapState())
        {
        }

        public void Initialize()
        {
            _state = new MapState();
            _state.StartClean(_data);
        }

        public void Initialize(MapState persistence)
        {
            _state = new MapState();
            _state.Load(persistence);
        }


        void IDisplayable.Display() => _display.Display(this);
    }
}
