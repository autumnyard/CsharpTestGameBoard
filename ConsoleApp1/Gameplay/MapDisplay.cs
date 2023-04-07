﻿using ConsoleApp1.Display;
using System.Text;

namespace ConsoleApp1.Gameplay
{
    internal sealed class MapDisplay : IDisplayable
    {
        private readonly MapController _controller;

        public MapDisplay(MapController controller)
        {
            _controller = controller;
        }

        public void Display() => Display(_controller);


        private static void Display(MapController controller)
        {
            Display(controller.Map, controller.Size);
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
}