using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Core.Interfaces;
using RacingMachinez.Core.Interfaces.Logging;

namespace RacingMachinez.Core
{
    public class GamePluginsManager : IGamePluginsManager
    {
        private const string LibraryFileExtension = "*.dll";

        [ImportMany] private Lazy<IGamePlugin, IDictionary<string, object>>[] _gamePlugins = null;

        private readonly ILogger _logger;

        public GamePluginsManager(ILogger logger)
        {
            _logger = logger;
        }

        public IList<IGamePlugin> LoadPlugins(string pluginDirectory)
        {
            if (_gamePlugins == null)
            {
                LoadGamePlugins(pluginDirectory);
            }

            return _gamePlugins.Select(p => p.Value).ToList();
        }

        private void LoadGamePlugins(string pluginDirectory)
        {
            try
            {
                var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var directoryCatalog = new DirectoryCatalog(Path.Combine(currentPath, pluginDirectory), LibraryFileExtension);
                var container = new CompositionContainer(directoryCatalog);

                container.ComposeParts(this);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception);
                _gamePlugins = new Lazy<IGamePlugin, IDictionary<string, object>>[0];
            }
        }
    }
}
