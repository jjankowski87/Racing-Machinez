using System.Collections.Generic;
using RacingMachinez.TrayApplication.Framework;

namespace RacingMachinez.TrayApplication.Configuration.Interfaces
{
    public interface IConfigurationView : IView
    {
        string PluginsPath { get; set; }

        string SelectedComPort { get; set; }

        void DisplayComPorts(IEnumerable<string> comPorts);

        void DisplayClusterPlugins(IEnumerable<PluginModel> pluginNames);
    }
}
