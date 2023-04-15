
namespace Kernel.Input
{
    public interface IInputProcessor<TIn, TOut>
        where TIn : Enum
        where TOut : Enum
    {
        void Process(TIn input, out TOut output);
    }
}
