using BoardGame1.Display;

namespace BoardGame1.Gameplay
{
    internal abstract class BaseDisplay<TController> : IDisplay<TController>
    {
        public abstract void Display(TController controller);
    }
}
