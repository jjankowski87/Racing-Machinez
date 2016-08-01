using System;

namespace RacingMachinez.Contracts.Plugins
{
    public interface IClusterFactoryPlugin
    {
        Guid ClusterId { get; }

        string ClusterName { get; }

        ICluster ConnectCluster(ClusterConfiguration configuration);
    }
}
