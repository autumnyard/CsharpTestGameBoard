using ConsoleApp1.Input;

namespace ConsoleApp1.Gameplay
{
    internal sealed class PlayerController : Controller<PlayerController>,
        IEquatable<Vector2Int>,
        IPersistable<PlayerPersistence>
    {

        private readonly MovementValidator _movementValidator;
        private Vector2Int _currentPosition;

        public Vector2Int CurrentPosition => _currentPosition;

        public PlayerController(MovementValidator movementValidator)
        {
            _display = new PlayerDisplay(this);
            _movementValidator = movementValidator;
            _currentPosition = default;
        }

        public void NewGame(Vector2Int spawnPosition)
        {
            _currentPosition = new Vector2Int(spawnPosition);
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
                case eInputAction.MoveUp: MoveUp(); return;
                case eInputAction.MoveDown: MoveDown(); return;
                case eInputAction.MoveLeft: MoveLeft(); return;
                case eInputAction.MoveRight: MoveRight(); break;
            }
        }


        private void MoveUp()
        {
            var requestedPosition = new Vector2Int(_currentPosition.X, _currentPosition.Y - 1);
            TryToMove(requestedPosition);
        }

        private void MoveDown()
        {
            var requestedPosition = new Vector2Int(_currentPosition.X, _currentPosition.Y + 1);
            TryToMove(requestedPosition);
        }

        private void MoveLeft()
        {
            var requestedPosition = new Vector2Int(_currentPosition.X - 1, _currentPosition.Y);
            TryToMove(requestedPosition);
        }

        private void MoveRight()
        {
            var requestPosition = new Vector2Int(_currentPosition.X + 1, _currentPosition.Y);
            TryToMove(requestPosition);
        }

        private void TryToMove(Vector2Int requestedNewPosition)
        {
            bool isValid = _movementValidator.IsValidMovement(_currentPosition, requestedNewPosition);
            if (!isValid) return;

            _currentPosition = requestedNewPosition;
        }


        public override string ToString() => _currentPosition.ToString();
        public bool Equals(Vector2Int other) => _currentPosition.Equals(other);
        public static bool operator ==(PlayerController player, Vector2Int other) => player.Equals(other);
        public static bool operator !=(PlayerController player, Vector2Int other) => !player.Equals(other);
    }
}
