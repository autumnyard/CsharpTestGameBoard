using ConsoleApp1.Gameplay.Map;
using ConsoleApp1.Gameplay.Player;

namespace ConsoleApp1.Gameplay.Game
{
    internal record GamePersistence(int level, MapState map, PlayerState player);
}
