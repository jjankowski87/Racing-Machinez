using System;
using RacingMachinez.Core;
using RacingMachinez.Core.Logging;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;
using System.IO.Ports;

namespace RacingMachinez.TestConsole
{
    internal class Program
    {
        public static ICluster cluster;

        public static void Main(string[] args)
        {
            var names = SerialPort.GetPortNames();

            var logger = new DefaultLogger();
            var gamePluginsManager = new PluginsManager<IGamePlugin>(logger);
            var clusterPluginsManager = new PluginsManager<ICluster>(logger);

            var gamePlugins = gamePluginsManager.ReloadPlugins("Plugins");
            var clusterPlugins = clusterPluginsManager.ReloadPlugins("Plugins");
            var gamePlugin = gamePlugins[1];
            cluster = clusterPlugins[0];
            //gamePlugin.GameStateChanged += PluginGameStateChanged;
            //gamePlugin.GameDataChanged += PluginGameDataChanged;

           // var connected = cluster.Connect(new ClusterConfiguration { PortName = "COM3" });

            Console.ReadKey();
            cluster.Dispose();
            //gamePlugin.Dispose();
        }

        private static void PluginGameDataChanged(object sender, GameDataChangedEventArgs e)
        {
            cluster.UpdateGameData(e.GameData);
        }

        private static void PluginGameStateChanged(object sender, GameStateChangedEventArgs e)
        {
            Console.WriteLine(e.IsRunning ? "Game is running" : "Game is stopped");
        }
    }
}
