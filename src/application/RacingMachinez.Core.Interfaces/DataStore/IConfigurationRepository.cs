using System;
using System.Collections.Generic;

namespace RacingMachinez.Core.Interfaces.DataStore
{
    public interface IConfigurationRepository
    {
        IList<Guid> GetActiveGamePluginIds();

        void DisableGamePlugin(Guid gamePluginId);

        void EnableGamePlugin(Guid gamePluginId);

        Guid GetActiveClusterPlugin();

        void SetActiveClusterPlugin(Guid clusterPluginId);

        string GetClusterPort();

        void SetClusterPort();
    }
}
