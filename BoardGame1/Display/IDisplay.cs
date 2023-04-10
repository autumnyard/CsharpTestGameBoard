namespace BoardGame1.Display
{
    internal interface IDisplay<TController>
    {
        void Display(TController controller);
    }
}
