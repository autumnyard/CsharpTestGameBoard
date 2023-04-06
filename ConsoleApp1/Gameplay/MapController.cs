
using ConsoleApp1.Display;
using System.Text;

namespace ConsoleApp1.Gameplay
{
    internal class MapController : IPersistable<MapPersistence>, IDisplayable
    {
        private int[] _board;

        public int Size => _board.Length;

        public void NewGame(int size)
        {
            _board = new int[size];
        }

        public void Load(MapPersistence persistence)
        {
            _board = new int[persistence.size];
        }


        public MapPersistence Save()
        {
            return new()
            {
                size = _board.Length,
            };
        }


        public bool IsValidMovement(int currentPosition, int nextPosition)
        {
            if (nextPosition < 0) return false;
            if (nextPosition >= _board.Length - 1) return false;

            return true;
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
