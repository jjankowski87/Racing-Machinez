using System.Collections.Generic;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Core
{
    public interface IActivePluginSelector
    {
        IEnumerable<IGamePlugin> Test(IEnumerable<IGamePlugin> gamePlugins);

    }
}
