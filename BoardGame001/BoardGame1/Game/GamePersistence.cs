using BoardGame1.Map;
using BoardGame1.Player;

namespace BoardGame1.Game
{
    public record GamePersistence(int level, MapState map, PlayerState player);
}
