
namespace ConsoleApp1.Gameplay
{
    internal class PlayerController : IEquatable<int>
    {
        private int _playerPosition;

        public PlayerController(int spawnPosition)
        {
            _playerPosition = spawnPosition;
        }

        public void MoveLeft()
        {
            _playerPosition--;
        }

        public void MoveRight()
        {
            _playerPosition++;
        }

        public override string ToString() => _playerPosition.ToString();

        public bool Equals(int other) => _playerPosition.Equals(other);
        public static bool operator ==(PlayerController player, int other) => player.Equals(other);
        public static bool operator !=(PlayerController player, int other) => !player.Equals(other);
    }
}
