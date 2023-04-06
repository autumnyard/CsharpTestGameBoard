using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BoardController
    {
        private int[] _board;
        private int _playerPosition;

        public int[] Board => _board;

        public BoardController(int size, int spawnPosition)
        {
            if (size < spawnPosition)
                spawnPosition = size;

            _board = new int[size];
            _board[0] = 0;

            _playerPosition = spawnPosition;
        }

        public void Move(eMovement movement)
        {
            switch (movement)
            {
                case eMovement.Left:
                    if (_playerPosition == 0) return;
                    return;

                case eMovement.Right:
                    if (_playerPosition == _board.Length - 1) return;
                    break;
            }

        }

        public void Print()
        {
            StringBuilder sb = new StringBuilder("Board: ");
            for (int i = 0; i < _board.Length; i++)
            {
                sb.Append($" [{_board[i]}]");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
