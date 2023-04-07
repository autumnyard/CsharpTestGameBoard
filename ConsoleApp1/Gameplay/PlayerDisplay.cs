
namespace ConsoleApp1.Gameplay
{
    internal sealed class PlayerDisplay : BaseDisplay<PlayerController>
    {
        public override void Display(PlayerController controller)
        {
            Display(controller.CurrentPosition);
        }

        private static void Display(Vector2Int position)
        {
            Console.WriteLine($" Player position: {position}\n\n");
        }
    }
}
