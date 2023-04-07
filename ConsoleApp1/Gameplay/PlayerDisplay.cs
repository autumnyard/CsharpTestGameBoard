using ConsoleApp1.Display;

namespace ConsoleApp1.Gameplay
{
    internal sealed class PlayerDisplay : IDisplayable
    {
        private readonly PlayerController _controller;

        public PlayerDisplay(PlayerController controller)
        {
            _controller = controller;
        }

        public void Display() => Display(_controller);


        private static void Display(PlayerController controller)
        {
            Display(controller.CurrentPosition);
        }

        private static void Display(Vector2Int position)
        {
            Console.WriteLine($" Player position: {position}\n\n");
        }
    }
}
