using ConsoleApp1.Display;

namespace ConsoleApp1.Gameplay
{
    internal abstract class Controller<T> : IDisplayable
    {
        protected IDisplayable _display;

        public void Display()
        {
            _display.Display();
        }
    }
}
