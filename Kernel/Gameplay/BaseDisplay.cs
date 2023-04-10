using Kernel.Display;

namespace Kernel.Gameplay
{
    public abstract class BaseDisplay<TController> : IDisplay<TController>
    {
        public abstract void Display(TController controller);
    }
}
