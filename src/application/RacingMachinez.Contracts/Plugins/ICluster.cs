using System;

namespace RacingMachinez.Contracts.Plugins
{
    public interface ICluster : IDisposable
    {
        event EventHandler<EventArgs> ConnectionLost;

        bool IsConnected { get; }

        ClusterState GetClusterState();

        void Ping();

        void SetClusterState(ClusterState clusterState);

        void UpdateGameData(GameData gameData);
    }
}
