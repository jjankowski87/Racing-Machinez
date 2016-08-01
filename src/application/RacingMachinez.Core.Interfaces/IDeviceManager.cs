using System.Threading.Tasks;
using RacingMachinez.Contracts;

namespace RacingMachinez.Core.Interfaces
{
    public interface IDeviceManager
    {
        bool IsClusterConnected { get; }

        Task ReloadClustersAsync();

        Task TryToConnectClusterAsync();

        void CheckClusterConnection();

        void SendDataToCluster(GameData gameData);
    }
}