namespace Kernel.Gameplay
{
    public interface IPersistable<T>
    {
        void Load(T persistence);
        T Save();
    }
}
