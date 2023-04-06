using System.Text;

namespace ConsoleApp1.Input
{
    internal class InputProvider : IInputProvider, IDisplayable
    {
        private Dictionary<ConsoleKey, eInputAction> _inputMap;

        public InputProvider()
        {
            _inputMap = new Dictionary<ConsoleKey, eInputAction>()
            {
                 { ConsoleKey.Escape, eInputAction.Exit}
            };

            _inputMap.Add(ConsoleKey.LeftArrow, eInputAction.MoveLeft);
            _inputMap.Add(ConsoleKey.A, eInputAction.MoveLeft);

            _inputMap.Add(ConsoleKey.RightArrow, eInputAction.MoveRight);
            _inputMap.Add(ConsoleKey.D, eInputAction.MoveRight);
        }

        public eInputAction GetInput()
        {
            var key = Console.ReadKey();


            bool foundKey = _inputMap.TryGetValue(key.Key, out var input);
            return foundKey ? input : eInputAction.None;
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
