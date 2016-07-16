namespace RacingMachinez.Core
{
    public interface IUserNotifier
    {
        void ClusterConnectionChanged(string clusterName, bool isConnected);

        void GameStateChanged(string gameName, bool isStarted);
    }
}
