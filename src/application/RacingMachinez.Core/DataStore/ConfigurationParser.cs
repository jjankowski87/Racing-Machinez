using System;
using System.Linq;

namespace RacingMachinez.Core.DataStore
{
    internal class ConfigurationParser
    {
        public static Configuration CreateFromFile(string fileContent)
        {
            var configuration = new Configuration();
            var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            if (lines.Length > 0)
            {
                configuration.ActiveGamePluginIds = lines[0].Split(' ').Select(part => Guid.Parse(part)).ToList();
            }

            if (lines.Length > 1)
            {
                configuration.ActiveClusterPluginId = Guid.Parse(lines[1]);
            }

            if (lines.Length > 2)
            {
                configuration.ClusterPort = lines[2];
            }


            return configuration;
        }

        public string CreateFile(Configuration configuration)
        {
            return string.Concat(string.Join(" ", configuration.ActiveGamePluginIds.Select(id => id.ToString())),
                Environment.NewLine,
                configuration.ActiveClusterPluginId.ToString(),
                Environment.NewLine,
                configuration.ClusterPort);
        }
    }
}
