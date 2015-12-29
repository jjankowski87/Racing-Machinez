using System.Collections.Generic;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Core.Interfaces
{
    public interface IGamePluginsManager
    {
        IList<IGamePlugin> LoadPlugins(string pluginDirectory);
    }
}