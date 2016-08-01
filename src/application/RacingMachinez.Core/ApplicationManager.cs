using System.Threading.Tasks;
using RacingMachinez.Core.Interfaces;

namespace RacingMachinez.Core
{
    public class ApplicationManager : IApplicationManager
    {
        private readonly IGamesManager _gamesManager;

        private readonly IDeviceManager _deviceManager;

        public ApplicationManager(IGamesManager gamesManager, IDeviceManager deviceManager)
        {
            _gamesManager = gamesManager;
            _deviceManager = deviceManager;
        }

        public async Task ReloadApplicationAsync()
        {
            await _gamesManager.ReloadGamesAsync();
            await _deviceManager.ReloadClustersAsync();
        }

        public async Task DeviceConnectedAsync()
        {
            if (_deviceManager.IsClusterConnected)
            {
                return;
            }

            await _deviceManager.TryToConnectClusterAsync();
        }

        public void DeviceDisconnected()
        {
            _deviceManager.CheckClusterConnection();
        }

        public void PerformClusterCalibration(short speed, short revs)
        {
            //if (_cluster?.IsConnected == true)
            //{
            //    if (_cluster.GetClusterState() != Contracts.ClusterState.Calibration)
            //    {
            //        _cluster.SetClusterState(Contracts.ClusterState.Calibration);
            //    }

            //    var calibrationData = new Contracts.GameData { Speed = speed, Revs = revs };
            //    _cluster.UpdateGameData(calibrationData);
            //}
        }

        public async Task PerformGameOperationsAsync()
        {
            if (_deviceManager.IsClusterConnected)
            {
                var gamePlugin = await _gamesManager.GetActiveGamePluginAsync();
                if (gamePlugin != null)
                {
                    _deviceManager.SendDataToCluster(gamePlugin.GetGameData());
                }
            }
        }
    }
}
