
namespace ConsoleApp1
{
    internal interface IInputProvider
    {
        eInputAction GetInput();
    }

    internal class InputProvider : IInputProvider
    {

        public eInputAction GetInput()
        {
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    return eInputAction.Exit;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return eInputAction.MoveLeft;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return eInputAction.MoveRight;

                default:
                    return eInputAction.None;
            }
        }
    }
}
