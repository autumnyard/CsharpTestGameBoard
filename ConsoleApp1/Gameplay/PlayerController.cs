using ConsoleApp1.Input;

namespace ConsoleApp1.Gameplay
{
    internal sealed class PlayerController : 
        Controller<PlayerState, PlayerDisplay>,
        IEquatable<Vector2Int>
    {
        private readonly MovementValidator _movementValidator;

        public Vector2Int CurrentPosition => _state.currentPosition;

        public PlayerController(MovementValidator movementValidator)
        {
            _state = new PlayerState();
            _display = new PlayerDisplay(this);

            _movementValidator = movementValidator;
        }

        public void StartClean(LevelData data)
        {
            _state = new PlayerState();
            _state.StartClean(data);
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
            var requestedPosition = new Vector2Int(_state.currentPosition.X, _state.currentPosition.Y - 1);
            TryToMove(requestedPosition);
        }

        private void MoveDown()
        {
            var requestedPosition = new Vector2Int(_state.currentPosition.X, _state.currentPosition.Y + 1);
            TryToMove(requestedPosition);
        }

        private void MoveLeft()
        {
            var requestedPosition = new Vector2Int(_state.currentPosition.X - 1, _state.currentPosition.Y);
            TryToMove(requestedPosition);
        }

        private void MoveRight()
        {
            var requestPosition = new Vector2Int(_state.currentPosition.X + 1, _state.currentPosition.Y);
            TryToMove(requestPosition);
        }

        private void TryToMove(Vector2Int requestedNewPosition)
        {
            bool isValid = _movementValidator.IsValidMovement(_state.currentPosition, requestedNewPosition);
            if (!isValid) return;

            _state.SetPosition(requestedNewPosition);
        }


        public override string ToString() => _state.currentPosition.ToString();
        public bool Equals(Vector2Int other) => _state.currentPosition.Equals(other);
        public static bool operator ==(PlayerController player, Vector2Int other) => player.Equals(other);
        public static bool operator !=(PlayerController player, Vector2Int other) => !player.Equals(other);
    }
}
