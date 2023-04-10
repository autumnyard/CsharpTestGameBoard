
namespace Kernel.Input
{
    public interface IInputProvider<T> where T : Enum
    {
        void GetInput(out T newInput);
    }
}
