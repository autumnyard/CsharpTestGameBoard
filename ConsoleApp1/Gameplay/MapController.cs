using ConsoleApp1.Display;
using System.Text;

namespace ConsoleApp1.Gameplay
{
    internal class MapController : Controller<MapController>
    {
        internal sealed class MapDisplay : IDisplayable
        {
            private readonly MapController _controller;

            public MapDisplay(MapController controller)
            {
                _controller = controller;
            }

            public void Display() => Display(_controller._map, _controller._size);

            private static void Display(Vector2Int position)
            {
                Console.WriteLine($" Player position: {position}\n\n");
            }

            private static void Display(int[,] map, Vector2Int size)
            {
                StringBuilder sb = new StringBuilder("Board:\n");
                for (int i = 0; i < size.X; i++)
                {
                    sb.Append($" [ ");
                    for (int j = 0; j < size.Y; j++)
                    {
                        sb.Append($"{map[i, j]} ");
                    }
                    sb.Append($"]\n");
                }
                sb.Append('\n');
                Console.WriteLine(sb.ToString());
            }

            private static void Display(int[] map)
            {
                StringBuilder sb = new StringBuilder("Board:\n");
                for (int i = 0; i < map.Length; i++)
                {
                    sb.Append($" [{map[i]}]");
                }
                sb.Append('\n');
                Console.WriteLine(sb.ToString());
            }
        }

        private Vector2Int _size;
        private int[,] _map;

        public Vector2Int Size => _size;

        public MapController()
        {
            _display = new MapDisplay(this);
        }

        public void SetMap(Vector2Int size)
        {
            _size = new Vector2Int(size);
            _map = new int[_size.X, _size.Y];
        }

        public void Display() => _display.Display();
    }
}
