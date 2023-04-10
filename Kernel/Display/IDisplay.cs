
namespace Kernel.Display
{
    public interface IDisplay<TController>
    {
        void Display(TController controller);
    }
}
