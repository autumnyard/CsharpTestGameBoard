
using ConsoleApp1.Display;

namespace ConsoleApp1.Gameplay
{
    internal sealed class PlayerController :
        IEquatable<int>,
        IPersistable<PlayerPersistence>,
        IDisplayable
    {
        private int _currentPosition;

        public void NewGame(int spawnPosition)
        {
            _currentPosition = spawnPosition;
        }

        public void Load(PlayerPersistence persistence)
        {
            _currentPosition = persistence.currentPosition;
        }

        public PlayerPersistence Save()
        {
            return new PlayerPersistence()
            {
                currentPosition = _currentPosition
            };
        }

        public void MoveLeft(in MapController map)
        {
            if (_currentPosition == 0) return;
            _currentPosition--;
        }

        public void MoveRight(in MapController map)
        {
            if (_currentPosition == map.Size - 1) return;
            _currentPosition++;
        }

        public void Display()
        {
            Console.WriteLine($" Player position: {_currentPosition}\n\n");
        }


        public override string ToString() => _currentPosition.ToString();

        public bool Equals(int other) => _currentPosition.Equals(other);

        public static bool operator ==(PlayerController player, int other) => player.Equals(other);
        public static bool operator !=(PlayerController player, int other) => !player.Equals(other);
    }
}
