using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Core.Interfaces;
using RacingMachinez.Core.Interfaces.DataStore;

namespace RacingMachinez.Core
{
    public class GameManager : IGamesManager
    {
        private readonly IPluginsManager<IGamePlugin> _gamePluginManager;

        private readonly IConfigurationRepository _configurationRepository;

        private IList<IGamePlugin> _activeGamePlugins;

        public GameManager(IPluginsManager<IGamePlugin> gamePluginManager, IConfigurationRepository configurationRepository)
        {
            _gamePluginManager = gamePluginManager;
            _configurationRepository = configurationRepository;
        }

        public async Task<IGamePlugin> GetActiveGamePluginAsync()
        {
            if (_activeGamePlugins == null)
            {
                await ReloadGamesAsync();
            }

            return _activeGamePlugins?.FirstOrDefault(plugin => plugin.IsRunning());
        }

        public async Task ReloadGamesAsync()
        {
            _activeGamePlugins = await LoadActiveGamePluginsAsync();
        }

        private async Task<IList<IGamePlugin>> LoadActiveGamePluginsAsync()
        {
            var configuration = await _configurationRepository.LoadConfigurationAsync();
            var plugins = _gamePluginManager.ReloadPlugins(configuration.PluginDirectory);

            return plugins.Where(plugin => configuration.ActiveGamePluginIds.Contains(plugin.GameId)).ToList();
        }
    }
}
