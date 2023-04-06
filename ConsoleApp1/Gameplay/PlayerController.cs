using ConsoleApp1.Display;
using ConsoleApp1.Input;

namespace ConsoleApp1.Gameplay
{
    internal sealed class PlayerController :
        IEquatable<int>,
        IPersistable<PlayerPersistence>,
        IDisplayable
    {
        private readonly MovementValidator _movementValidator;
        private int _currentPosition;

        public PlayerController(MovementValidator movementValidator)
        {
            _movementValidator = movementValidator;
        }

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

        internal void ApplyInput(eInputAction inputAction)
        {
            switch (inputAction)
            {
                case eInputAction.MoveLeft: MoveLeft(); return;
                case eInputAction.MoveRight: MoveRight(); break;
            }
        }

        
        private void MoveLeft()
        {
            bool isValid = _movementValidator.IsValidMovement(_currentPosition, _currentPosition - 1);
            if (!isValid) return;

            _currentPosition--;
        }

        private void MoveRight()
        {
            bool isValid = _movementValidator.IsValidMovement(_currentPosition, _currentPosition + 1);
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
