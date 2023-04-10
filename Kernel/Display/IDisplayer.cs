
namespace Kernel.Display
{
    public interface IDisplayer
    {
        void AddDisplayable(IDisplayable displayable);
        void RemoveDisplayable(IDisplayable displayable);
        void Display();
    }
}