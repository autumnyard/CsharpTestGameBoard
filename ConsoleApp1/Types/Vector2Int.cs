
namespace ConsoleApp1
{
    internal class Vector2Int
    {
        private int _x;
        private int _y;

        public int X => _x;
        public int Y => _y;

        public Vector2Int()
        {
        }

        public Vector2Int(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Vector2Int(Vector2Int vector2Int)
        {
            _x = vector2Int.X;
            _y = vector2Int.Y;
        }

        public bool Contains(Vector2Int b) => _x >= b._x && _y >= b._y;

        public override string ToString() => $"({_x},{_y})";
    }
}
