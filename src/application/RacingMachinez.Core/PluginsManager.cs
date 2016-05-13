using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using RacingMachinez.Core.Interfaces;
using RacingMachinez.Core.Interfaces.Logging;

namespace RacingMachinez.Core
{
    public class PluginsManager<T> : IPluginsManager<T>
    {
        private const string LibraryFileExtension = "*.dll";

        [ImportMany] private Lazy<T, IDictionary<string, object>>[] _plugins = null;

        private readonly ILogger _logger;

        public PluginsManager(ILogger logger)
        {
            _logger = logger;
        }

        public IList<T> LoadPlugins(string pluginDirectory)
        {
            if (_plugins == null)
            {
                ComposePlugins(pluginDirectory);
            }

            return _plugins.Select(p => p.Value).ToList();
        }

        private void ComposePlugins(string pluginDirectory)
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
                _plugins = new Lazy<T, IDictionary<string, object>>[0];
            }
        }
    }
}
