
namespace ConsoleApp1.Gameplay
{
    internal class GameStatePersistence
    {
        //public MapPersistence map; // Now this only saves the map size, which is Data not State, and doesn't need persistence here
        public PlayerPersistence player;
        public int level;
    }
}
