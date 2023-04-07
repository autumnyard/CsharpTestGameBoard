using ConsoleApp1.Display;

namespace ConsoleApp1.Gameplay
{
    internal abstract class Controller<TState, TDisplay>
        where TState : IState
        where TDisplay : IDisplayable
    {
        protected TState _state;
        protected TDisplay _display;

        public TState State => _state;
        public TDisplay Display => _display;
    }
}
