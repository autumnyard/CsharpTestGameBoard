using Kernel.Display;
using Kernel.Input;
using System.Text;

namespace BoardGame1.BoardGame1.Input
{
    internal class SyncProcessedConsoleInputProvider : IInputProvider<eInputAction>, 
        IDisplayable
    {
        IInputProcessor<ConsoleKey, eInputAction> inputProcessor;

        public SyncProcessedConsoleInputProvider()
        {
            inputProcessor = new DictInputProcessor();
        }

        public void GetInput(out eInputAction newInput)
        {
            var pressedKey = QueryNextConsoleKey();
            inputProcessor.Process(pressedKey, out newInput);
        }

        private ConsoleKey QueryNextConsoleKey()
        {
            var key = Console.ReadKey();
            return key.Key;
        }

        public void Display()
        {
            Console.WriteLine($"Input Map: {inputProcessor}\n\n");
        }
    }
}
