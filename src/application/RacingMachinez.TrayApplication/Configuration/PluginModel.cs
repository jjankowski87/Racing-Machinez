using System;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.TrayApplication.Configuration
{
    public class PluginModel
    {
        public PluginModel(IGamePlugin gamePlugin)
        {
            Id = gamePlugin.GameId;
            Name = gamePlugin.GameName;
        }

        public PluginModel(IClusterFactoryPlugin clusterFactoryPlugin)
        {
            Id = clusterFactoryPlugin.ClusterId;
            Name = clusterFactoryPlugin.ClusterName;
        }

        public Guid Id { set; get; }

        public string Name { get; set; }
    }
}