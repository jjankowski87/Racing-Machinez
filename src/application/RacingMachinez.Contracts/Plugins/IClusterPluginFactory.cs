namespace RacingMachinez.Contracts.Plugins
{
    public interface IClusterFactoryPlugin
    {
        string ClusterName { get; }

        ICluster ConnectCluster(ClusterConfiguration configuration);
    }
}
