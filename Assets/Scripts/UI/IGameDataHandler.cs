using Server.Data;

namespace UI
{
    public interface IGameDataHandler
    {
        void InjectData(GameDataContainer gameDataContainer);
    }
}