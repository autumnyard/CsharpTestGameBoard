
using System.Collections.Generic;

namespace BoardGame1.Display
{
    internal class Displayer : IDisplayer
    {
        private List<IDisplayable> _displayables;

        public Displayer()
        {
            _displayables = new List<IDisplayable>();
        }

        public void AddDisplayable(IDisplayable displayable)
        {
            _displayables.Add(displayable);
        }

        public void RemoveDisplayable(IDisplayable displayable)
        {
            _displayables.Remove(displayable);
        }

        public void Display()
        {
            for (int i = 0; i < _displayables.Count; i++)
            {
                _displayables[i].Display();
            }
        }
    }
}
