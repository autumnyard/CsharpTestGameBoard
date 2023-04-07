
namespace ConsoleApp1.Gameplay
{
    internal class PlayerState : State
    {
        public Vector2Int currentPosition;

        public void Set(Vector2Int position)
        {
            currentPosition = position;
        }
    }
}
