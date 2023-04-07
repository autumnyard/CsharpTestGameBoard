
namespace ConsoleApp1.Gameplay
{
    internal class MovementValidator
    {
        private MapController _map;

        public MovementValidator(MapController map)
        {
            _map = map;
        }

        public bool IsValidMovement(Vector2Int currentPosition, Vector2Int nextPosition)
        {
            if (nextPosition.X < 0 || nextPosition.Y < 0) return false;
            if (!_map.Size.Contains(nextPosition)) return false;

            return true;
        }
    }
}
