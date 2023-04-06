using ConsoleApp1.Input;
using System.Text;

namespace ConsoleApp1.Gameplay
{
    internal class GameStateController : IDisplayable
    {
        private int[] _board;
        private PlayerController _player;
        private bool _isRunning;

        public bool IsRunning => _isRunning;

        public GameStateController(int size, int spawnPosition)
        {
            if (size < spawnPosition)
                spawnPosition = size;

            _board = new int[size];
            _board[0] = 0;

            _player = new PlayerController(spawnPosition);

            _isRunning = true;
        }

        public void ApplyInput(eInputAction action)
        {
            switch (action)
            {
                case eInputAction.MoveLeft:
                    Console.WriteLine($"Move left {action}");
                    Move(eMovement.Left);
                    break;

                case eInputAction.MoveRight:
                    Console.WriteLine($"Move right {action}");
                    Move(eMovement.Right);
                    break;

                case eInputAction.Exit:
                    _isRunning = false;
                    break;
            }
        }

        public void Move(eMovement movement)
        {
            switch (movement)
            {
                case eMovement.Left:
                    if (_player == 0) return;
                    _player.MoveLeft();
                    return;

                case eMovement.Right:
                    if (_player == _board.Length - 1) return;
                    _player.MoveRight();
                    break;
            }
        }

        public void Display()
        {
            StringBuilder sb = new StringBuilder("Board: ");
            for (int i = 0; i < _board.Length; i++)
            {
                sb.Append($" [{_board[i]}]");
            }
            sb.Append('\n');
            sb.Append($" Player position: {_player}");
            sb.Append('\n');
            sb.Append('\n');
            Console.WriteLine(sb.ToString());
        }
    }
}
