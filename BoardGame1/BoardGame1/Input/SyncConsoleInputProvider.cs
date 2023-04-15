using Kernel.Display;
using Kernel.Input;

namespace BoardGame1.BoardGame1.Input
{
    internal class SyncConsoleInputProvider : IInputProvider<ConsoleKey>
    {
        public void GetInput(out ConsoleKey newInput)
        {
            newInput = QueryNextConsoleKey();
        }

        private ConsoleKey QueryNextConsoleKey()
        {
            var key = Console.ReadKey();
            return key.Key;
        }
    }
}
