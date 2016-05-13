using System;

namespace RacingMachinez.Contracts.Plugins
{
    public interface IClusterPlugin : IDisposable
    {
        string ClusterName { get; }

        bool Connect(ClusterConfiguration configuration);

        // TODO: add methods for initialization/calibration/gaming
        void UpdateGameData(GameData gameData);
    }
}
