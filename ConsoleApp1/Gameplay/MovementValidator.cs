
namespace ConsoleApp1.Gameplay
{
    internal class MovementValidator
    {
        private MapController _map;

        public MovementValidator(MapController map)
        {
            _map = map;
        }

        public bool IsValidMovement(int currentPosition, int nextPosition)
        {
            if (nextPosition < 0) return false;
            if (nextPosition >= _map.Size ) return false;

            return true;
        }
    }
}
