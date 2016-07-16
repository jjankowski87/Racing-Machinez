using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Core.Interfaces;
using RacingMachinez.Plugins.Clusters.Auduino;

namespace RacingMachinez.Core
{
    public class DeviceManager
    {
        private readonly IPluginsManager<IClusterFactoryPlugin> _clusterFactoryPluginManager;

        private readonly IUserNotifier _userNotifier;

        private readonly IClusterFactoryPlugin _clusterPluginFactory;

        private ICluster _cluster;

        public DeviceManager(IPluginsManager<IClusterFactoryPlugin> clusterFactoryPluginManager, IUserNotifier userNotifier)
        {
            // TODO: change to load plugin from IPluginsManager
            _clusterPluginFactory = new AuduinoClusterFactoryPlugin();

            _userNotifier = userNotifier;
            _clusterFactoryPluginManager = clusterFactoryPluginManager;
        }

        public bool IsClusterConnected => _cluster?.IsConnected == true;

        public void TryToConnectCluster()
        {
            if (IsClusterConnected)
            {
                return;
            }

            _cluster = _clusterPluginFactory.ConnectCluster(new Contracts.ClusterConfiguration { PortName = "COM4" });
            if (_cluster != null)
            {
                _cluster.ConnectionLost += (sender, eventArgs) => CloseClusterConnection();
                _userNotifier.ClusterConnectionChanged(_clusterPluginFactory.ClusterName, true);
            }
        }

        public void CheckClusterConnection()
        {
            _cluster?.Ping();
        }

        private void CloseClusterConnection()
        {
            if (_cluster != null)
            {
                _cluster?.Dispose();
                _cluster = null;
                _userNotifier.ClusterConnectionChanged(_clusterPluginFactory.ClusterName, false);
            }
        }
    }
}
