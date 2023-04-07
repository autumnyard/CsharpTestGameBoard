using ConsoleApp1.Display;

namespace ConsoleApp1.Gameplay
{
    internal abstract class BaseDisplay<TController> : IDisplay<TController>
    {
        public abstract void Display(TController controller);
    }
}
