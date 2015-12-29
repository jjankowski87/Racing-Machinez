namespace RacingMachinez.Contracts.Plugins
{
    public interface IGamePlugin
    {
        string GameName { get; }

        GameData GetGameData();
    }
}
