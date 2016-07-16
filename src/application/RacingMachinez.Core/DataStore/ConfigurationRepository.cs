using System;
using System.Collections.Generic;
using RacingMachinez.Core.Interfaces.DataStore;

namespace RacingMachinez.Core.DataStore
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private const string ConfigurationFileName = "config.ini";

        public void EnableGamePlugin(Guid gamePluginId)
        {

        }

        public void DisableGamePlugin(Guid gamePluginId)
        {

        }

        public IList<Guid> GetActiveGamePluginIds()
        {
            return new List<Guid>();
        }

        public string GetClusterPort()
        {
            return "COM3";
        }

        public void SetClusterPort()
        {
            
        }

        public Guid GetActiveClusterPlugin()
        {
            return Guid.Empty;
        }

        public void SetActiveClusterPlugin(Guid clusterPluginId)
        {

        }
    }
}
