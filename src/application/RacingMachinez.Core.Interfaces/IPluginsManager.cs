using System.Collections.Generic;

namespace RacingMachinez.Core.Interfaces
{
    public interface IPluginsManager<T>
    {
        IList<T> LoadPlugins(string pluginDirectory);
    }
}
