
namespace ConsoleApp1.Gameplay
{
    internal class PlayerState : BaseState,
        IPersistable<PlayerState>
    {
        public Vector2Int currentPosition;

        public void SetPosition(Vector2Int position)
        {
            currentPosition = position;
        }

        public void StartClean(PlayerData data)
        {
            this.SetPosition(data.playerSpawnPosition);
        }

        public void Load(PlayerState persistence)
        {
            this.SetPosition(persistence.currentPosition);
        }

        public PlayerState Save()
        {
            return this;
        }
    }
}
