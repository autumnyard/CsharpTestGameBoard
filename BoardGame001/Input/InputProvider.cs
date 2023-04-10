using System;
using System.Collections.Generic;
using System.Text;
using BoardGame1.Display;

namespace BoardGame1.Input
{
    internal class InputProvider : IInputProvider, IDisplayable
    {
        private Dictionary<ConsoleKey, eInputAction> _inputMap;

        public InputProvider()
        {
            _inputMap = new Dictionary<ConsoleKey, eInputAction>()
            {
                 { ConsoleKey.Spacebar, eInputAction.Save},
                 { ConsoleKey.Escape, eInputAction.Exit}
            };

            _inputMap.Add(ConsoleKey.UpArrow, eInputAction.MoveUp);
            _inputMap.Add(ConsoleKey.W, eInputAction.MoveUp);

            _inputMap.Add(ConsoleKey.DownArrow, eInputAction.MoveDown);
            _inputMap.Add(ConsoleKey.S, eInputAction.MoveDown);

            _inputMap.Add(ConsoleKey.LeftArrow, eInputAction.MoveLeft);
            _inputMap.Add(ConsoleKey.A, eInputAction.MoveLeft);

            _inputMap.Add(ConsoleKey.RightArrow, eInputAction.MoveRight);
            _inputMap.Add(ConsoleKey.D, eInputAction.MoveRight);
        }

        public void GetInput(out eInputAction newInput)
        {
            var key = Console.ReadKey();

            bool foundKeyInMap = _inputMap.TryGetValue(key.Key, out var input);

            newInput = foundKeyInMap ? input : eInputAction.None;
        }

        public void Display()
        {
            StringBuilder sb = new StringBuilder("Input Map: \n");
            foreach (var input in _inputMap)
            {
                sb.Append($"  [{input.Key} --> {input.Value}] \n");
            }
            sb.Append('\n');
            sb.Append('\n');
            Console.WriteLine(sb.ToString());
        }
    }
}
