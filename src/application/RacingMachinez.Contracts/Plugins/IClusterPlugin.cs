namespace RacingMachinez.Contracts.Plugins
{
    public interface IClusterPlugin
    {
        string ClusterName { get; }

        void SetGameData(GameData gameData);
    }
}
