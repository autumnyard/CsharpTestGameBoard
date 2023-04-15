using Kernel.Display;
using Kernel.Input;
using System.Text;

namespace BoardGame1.BoardGame1.Input
{
    internal sealed class DictInputProcessor : IInputProcessor<ConsoleKey, eInputAction>,
        IDisplayable
    {
        private Dictionary<ConsoleKey, eInputAction> _inputMap;

        public DictInputProcessor()
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


        public void Process(ConsoleKey input, out eInputAction output)
        {
            bool foundKeyInMap = _inputMap.TryGetValue(input, out output);

            output = foundKeyInMap ? output : eInputAction.None;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Input Map: \n");
            foreach (var input in _inputMap)
            {
                sb.Append($"  [{input.Key} --> {input.Value}] \n");
            }
            return sb.ToString();
        }

        public void Display()
        {
            Console.WriteLine($"Input Map: {this}\n\n");
        }
    }
}
