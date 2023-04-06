
namespace ConsoleApp1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IInputProvider inputProvider = new InputProvider();

            BoardController board = new BoardController(3, 2);

            bool isPlaying = true;

            while (isPlaying)
            {

                board.Print();

                var newInput = inputProvider.GetInput();

                switch (newInput)
                {
                    case eInputAction.MoveLeft:
                        Console.WriteLine($"Move left {newInput}");
                        board.Move(eMovement.Left);
                        break;

                    case eInputAction.MoveRight:
                        Console.WriteLine($"Move right {newInput}");
                        board.Move(eMovement.Right);
                        break;

                    case eInputAction.Exit:
                        isPlaying = false;
                        break;

                    case eInputAction.None:
                    default:
                        break;
                }


            }


            return 0;
        }
    }
}