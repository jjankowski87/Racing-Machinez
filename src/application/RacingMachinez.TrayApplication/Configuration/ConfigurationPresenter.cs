using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Core.Interfaces;
using RacingMachinez.Core.Interfaces.DataStore;
using RacingMachinez.TrayApplication.Configuration.Interfaces;
using RacingMachinez.TrayApplication.Framework;

namespace RacingMachinez.TrayApplication.Configuration
{
    public class ConfigurationPresenter : PresenterBase<IConfigurationView>, IConfigurationPresenter
    {
        private readonly IPluginsManager<IGamePlugin> _gamePluginsManager;

        private readonly IPluginsManager<IClusterFactoryPlugin> _clusterFactoryPluginsManager;

        private readonly IConfigurationRepository _configurationRepository;

        private Contracts.DataStore.Configuration _configuration;

        public ConfigurationPresenter(IPluginsManager<IGamePlugin> gamePluginsManager, IPluginsManager<IClusterFactoryPlugin> clusterFactoryPluginsManager, IConfigurationRepository configurationRepository)
        {
            _gamePluginsManager = gamePluginsManager;
            _clusterFactoryPluginsManager = clusterFactoryPluginsManager;
            _configurationRepository = configurationRepository;
        }

        public async Task LoadDataAsync()
        {
            _configuration = await _configurationRepository.LoadConfigurationAsync();

            View.DisplayComPorts(SerialPort.GetPortNames());
            View.PluginsPath = _configuration.PluginDirectory;
            View.SelectedComPort = _configuration.ClusterPort;

            ReloadPluginsData(_configuration.PluginDirectory);
        }

        public void ReloadPluginsData(string pluginsDirectory)
        {
            var plugins = _clusterFactoryPluginsManager.ReloadPlugins(pluginsDirectory);
            View.DisplayClusterPlugins(plugins.Select(plugin => new PluginModel(plugin)));
        }
    }
}
