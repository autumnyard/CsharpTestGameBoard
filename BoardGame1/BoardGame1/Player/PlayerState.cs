using Kernel.Gameplay;

namespace BoardGame1.Player
{
    public class PlayerState : BaseState,
        IPersistable<PlayerState>
    {
        public Vector2Int currentPosition;

        public void SetPosition(Vector2Int position)
        {
            currentPosition = position;
        }

        public void StartClean(PlayerData data)
        {
            SetPosition(data.playerSpawnPosition);
        }

        public void Load(PlayerState persistence)
        {
            SetPosition(persistence.currentPosition);
        }

        public PlayerState Save()
        {
            return this;
        }
    }
}
