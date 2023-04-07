using ConsoleApp1.Display;

namespace ConsoleApp1.Gameplay
{
    internal abstract class BaseController<TController, TData, TState, TDisplay>
        where TData : IData
        where TState : IState
        where TDisplay : IDisplay<TController>
    {
        protected readonly TData _data;
        protected readonly TDisplay _display;
        protected TState _state;

        public TData Data => _data;
        public TState State => _state;
        public TDisplay Display => _display;

        protected BaseController(TData data, TDisplay display, TState state)
        {
            _data = data;
            _display = display;
            _state = state;
        }
    }
}
