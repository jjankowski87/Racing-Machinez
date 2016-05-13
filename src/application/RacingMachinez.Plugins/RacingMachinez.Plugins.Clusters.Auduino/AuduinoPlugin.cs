using System;
using System.ComponentModel.Composition;
using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Contracts;

namespace RacingMachinez.Plugins.Clusters.Auduino
{
    [Export(typeof (IClusterPlugin))]
    public class AuduinoPlugin : IClusterPlugin
    {
        private Writer writer;

        public string ClusterName => "Auduino v.0.1";

        public bool Connect(ClusterConfiguration configuration)
        {
            if (writer != null)
            {
                return true;
            }

            try
            {
                writer = new Writer(configuration);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void UpdateGameData(GameData gameData)
        {
            writer?.Send(gameData);
        }

        public void Dispose()
        {
            writer?.Dispose();
        }
    }
}
