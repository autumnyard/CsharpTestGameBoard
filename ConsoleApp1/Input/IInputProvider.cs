namespace ConsoleApp1.Input
{
    internal interface IInputProvider
    {
        eInputAction GetInput();
        void Display();
    }
}
