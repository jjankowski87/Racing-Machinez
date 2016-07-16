using System.ComponentModel.Composition;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Plugins.Clusters.Auduino
{
    [Export(typeof(IClusterFactoryPlugin))]
    public class AuduinoClusterFactoryPlugin : IClusterFactoryPlugin
    {
        public string ClusterName => "Auduino v.0.4";

        public ICluster ConnectCluster(ClusterConfiguration configuration)
        {
            var cluster = new AuduinoCluster();
            if (cluster.Connect(configuration))
            {
                return cluster;
            }

            cluster.Dispose();
            return null;
        }
    }
}
