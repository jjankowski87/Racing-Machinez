using System.Collections.Generic;
using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Core.Interfaces;

namespace RacingMachinez.Core
{
    public class ApplicationManager : IApplicationManager
    {
        // TODO: configurable (maybe form)
        private const string PluginsPath = "Plugins";

        private readonly IPluginsManager<IGamePlugin> _gamePluginManager;

        private IList<IGamePlugin> _gamePlugins = new List<IGamePlugin>();

        private DeviceManager _deviceManager;

        public ApplicationManager(IPluginsManager<IGamePlugin> gamePluginManager, IPluginsManager<IClusterFactoryPlugin> clusterFactoryPluginManager, IUserNotifier userNotifier)
        {
            _deviceManager = new DeviceManager(clusterFactoryPluginManager, userNotifier);

            _gamePluginManager = gamePluginManager;

            _gamePlugins = _gamePluginManager.ReloadPlugins(PluginsPath);
            DeviceConnected();
        }

        public void DeviceConnected()
        {
            if (_deviceManager.IsClusterConnected)
            {
                return;
            }

            _deviceManager.TryToConnectCluster();
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

        public void PerformGameOperations()
        {
            //if (_cluster?.IsConnected == true)
            //{
            //    foreach (var game in _gamePlugins.Where(g => g.IsRunning()))
            //    {
            //        _cluster.UpdateGameData(game.GetGameData());
            //        return;
            //    }
            //}
        }
    }
}
