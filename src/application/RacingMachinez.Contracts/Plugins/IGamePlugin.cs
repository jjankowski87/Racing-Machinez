namespace RacingMachinez.Contracts.Plugins
{
    public interface IGamePlugin
    {
        string GameName { get; }

        bool IsRunning();

        GameData GetGameData();
    }
}
