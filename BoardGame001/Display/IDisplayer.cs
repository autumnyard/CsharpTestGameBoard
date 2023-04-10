
namespace BoardGame1.Display
{
    internal interface IDisplayer
    {
        void AddDisplayable(IDisplayable displayable);
        void RemoveDisplayable(IDisplayable displayable);
        void Display();
    }
}