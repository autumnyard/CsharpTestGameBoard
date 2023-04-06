using ConsoleApp1.Display;
using ConsoleApp1.Input;

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

        internal void ApplyInput(eInputAction inputAction, in MapController map)
        {
            switch (inputAction)
            {
                case eInputAction.MoveLeft: MoveLeft(in map); return;
                case eInputAction.MoveRight: MoveRight(in map); break;
            }
        }

        
        private void MoveLeft(in MapController map)
        {
            bool isValid = map.IsValidMovement(_currentPosition, _currentPosition - 1);
            if (!isValid) return;

            _currentPosition--;
        }

        private void MoveRight(in MapController map)
        {
            bool isValid = map.IsValidMovement(_currentPosition, _currentPosition + 1);
            if (!isValid) return;

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
