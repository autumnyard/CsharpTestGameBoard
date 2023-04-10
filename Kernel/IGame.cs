namespace Kernel
{
    public interface IGame
    {
        bool IsRunning { get; }

        void Finish();
        void Initialize();
        void LoadGame();
        void NewGame(int level);
        void Tick();
    }
}