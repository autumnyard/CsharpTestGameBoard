
using ConsoleApp1.Display;
using System.Text;

namespace ConsoleApp1.Gameplay
{
    internal class MapController : IDisplayable
    {
        private int[] _board;

        public int Size => _board.Length;

        public void SetMap(int size)
        {
            _board = new int[size];
        }

        public void Display()
        {
            StringBuilder sb = new StringBuilder("Board: ");
            for (int i = 0; i < _board.Length; i++)
            {
                sb.Append($" [{_board[i]}]");
            }
            sb.Append('\n');
            Console.WriteLine(sb.ToString());
        }
    }
}
