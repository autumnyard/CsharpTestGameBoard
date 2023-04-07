using ConsoleApp1.Display;
using ConsoleApp1.Input;

namespace ConsoleApp1.Gameplay.Player
{
    internal sealed class PlayerController :
        BaseController<PlayerController, PlayerData, PlayerState, PlayerDisplay>,
        IEquatable<Vector2Int>,
        IDisplayable
    {
        private readonly MovementValidator _movementValidator;

        public Vector2Int CurrentPosition => _state.currentPosition;

        public PlayerController(LevelData data, MovementValidator movementValidator)
            : base(data.Player, new PlayerDisplay(), new PlayerState())
        {
            _movementValidator = movementValidator;
        }

        public void Initialize()
        {
            _state = new PlayerState();
            _state.StartClean(_data);
        }

        public void Initialize(PlayerState persistence)
        {
            _state = new PlayerState();
            _state.Load(persistence);
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

        void IDisplayable.Display() => _display.Display(this);

        public override string ToString() => _state.currentPosition.ToString();
        public bool Equals(Vector2Int other) => _state.currentPosition.Equals(other);

        public static bool operator ==(PlayerController player, Vector2Int other) => player.Equals(other);
        public static bool operator !=(PlayerController player, Vector2Int other) => !player.Equals(other);
    }
}
