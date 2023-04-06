
namespace ConsoleApp1.Gameplay
{
    internal class PlayerController : IEquatable<int>, IPersistable<int>
    {
        private int _currentPosition;

        public void NewGame(int spawnPosition)
        {
            _currentPosition = spawnPosition;
        }

        public void Load(int persistence)
        {
            _currentPosition = persistence;
        }

        public int Save()
        {
            return _currentPosition;
        }

        public void MoveLeft()
        {
            _currentPosition--;
        }

        public void MoveRight()
        {
            _currentPosition++;
        }

        public override string ToString() => _currentPosition.ToString();

        public bool Equals(int other) => _currentPosition.Equals(other);


        public static bool operator ==(PlayerController player, int other) => player.Equals(other);
        public static bool operator !=(PlayerController player, int other) => !player.Equals(other);
    }
}
