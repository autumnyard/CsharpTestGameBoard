
namespace ConsoleApp1.Gameplay
{
    internal class MapState : State,
        IPersistable<MapState>
    {
        public void StartClean(LevelData data)
        {
        }

        public void Load(MapState persistence)
        {
        }

        public MapState Save()
        {
            return this;
        }
    }
}
