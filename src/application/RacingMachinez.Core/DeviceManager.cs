using System.Linq;
using System.Threading.Tasks;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Core.Interfaces;
using RacingMachinez.Core.Interfaces.DataStore;

namespace RacingMachinez.Core
{
    public class DeviceManager : IDeviceManager
    {
        private readonly IPluginsManager<IClusterFactoryPlugin> _clusterFactoryPluginManager;

        private readonly IConfigurationRepository _configurationRepository;

        private readonly IUserNotifier _userNotifier;

        private IClusterFactoryPlugin _clusterFactoryPlugin;

        private ICluster _cluster;

        public DeviceManager(IPluginsManager<IClusterFactoryPlugin> clusterFactoryPluginManager, IConfigurationRepository configurationRepository, IUserNotifier userNotifier)
        {
            _clusterFactoryPluginManager = clusterFactoryPluginManager;
            _configurationRepository = configurationRepository;
            _userNotifier = userNotifier;
        }

        public bool IsClusterConnected => _cluster?.IsConnected == true;

        public async Task ReloadClustersAsync()
        {
            await CreateClusterAsync();
        }

        public async Task TryToConnectClusterAsync()
        {
            if (IsClusterConnected)
            {
                return;
            }

            await CreateClusterAsync();
        }

        public void CheckClusterConnection()
        {
            _cluster?.Ping();
        }

        public void SendDataToCluster(GameData gameData)
        {
            if (IsClusterConnected)
            {
                _cluster.UpdateGameData(gameData);
            }
        }

        private void CloseClusterConnection()
        {
            if (_cluster != null)
            {
                _cluster?.Dispose();
                _cluster = null;
                _userNotifier.ClusterConnectionChanged(_clusterFactoryPlugin.ClusterName, false);
            }
        }

        private async Task CreateClusterAsync()
        {
            var configuration = await _configurationRepository.LoadConfigurationAsync();
            var plugins = _clusterFactoryPluginManager.ReloadPlugins(configuration.PluginDirectory);

            _clusterFactoryPlugin = plugins.FirstOrDefault(plugin => plugin.ClusterId == configuration.ActiveClusterPluginId);
            _cluster = _clusterFactoryPlugin?.ConnectCluster(new ClusterConfiguration { PortName = configuration.ClusterPort });

            if (_cluster != null)
            {
                _cluster.ConnectionLost += (sender, eventArgs) => CloseClusterConnection();
                _userNotifier.ClusterConnectionChanged(_clusterFactoryPlugin.ClusterName, true);
            }
        }
    }
}
