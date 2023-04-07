using ConsoleApp1.Display;

namespace ConsoleApp1.Gameplay
{
    internal abstract class Controller<T> : IDisplayable
        where T: State
    {
        protected T _state;
        protected IDisplayable _display;

        public void Display()
        {
            _display.Display();
        }
    }
}
