using System;
using System.Collections.Generic;

namespace RacingMachinez.Core.DataStore
{
    internal class Configuration
    {
        public Configuration()
        {
            ActiveGamePluginIds = new List<Guid>();
        }

        public IList<Guid> ActiveGamePluginIds { get; set; }

        public Guid ActiveClusterPluginId { get; set; }

        public string ClusterPort { get; set; }
    }
}
