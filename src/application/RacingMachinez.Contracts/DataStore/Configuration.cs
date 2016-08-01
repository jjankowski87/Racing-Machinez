using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;

namespace RacingMachinez.Contracts.DataStore
{
    public class Configuration
    {
        public IList<Guid> ActiveGamePluginIds { get; set; }

        public Guid ActiveClusterPluginId { get; set; }

        public string ClusterPort { get; set; }

        public string PluginDirectory { get; set; }

        public static Configuration Default()
        {
            return new Configuration
                   {
                       ActiveGamePluginIds = new List<Guid>(),
                       ActiveClusterPluginId = Guid.Empty,
                       ClusterPort = SerialPort.GetPortNames().FirstOrDefault(),
                       PluginDirectory = Directory.GetCurrentDirectory()
                   };
        }
    }
}
