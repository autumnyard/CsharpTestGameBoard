namespace ConsoleApp1.Gameplay
{
    internal interface IPersistable<T>
    {
        void Load(T persistence);
        T Save();
    }
}
