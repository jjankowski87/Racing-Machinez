using System;
using System.ComponentModel.Composition;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Plugins.Clusters.Auduino
{
    [Export(typeof(IClusterFactoryPlugin))]
    public class AuduinoClusterFactoryPlugin : IClusterFactoryPlugin
    {
        public Guid ClusterId => new Guid(0x53e720d3, 0x2c29, 0x4895, 0x93, 0xbd, 0xec, 0x97, 0x98, 0x84, 0xab, 0xc2);

        public string ClusterName => "Auduino v.0.5";

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
