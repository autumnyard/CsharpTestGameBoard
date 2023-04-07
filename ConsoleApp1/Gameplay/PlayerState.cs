
namespace ConsoleApp1.Gameplay
{
    internal class PlayerState : State,
        IPersistable<PlayerState>
    {
        public Vector2Int currentPosition;

        public void Set(Vector2Int position)
        {
            currentPosition = position;
        }

        public void StartClean(LevelData data)
        {
            this.Set(data.PlayerSpawnPosition);
        }

        public void Load(PlayerState persistence)
        {
            this.Set(persistence.currentPosition);
        }

        public PlayerState Save()
        {
            return this;
        }
    }
}
