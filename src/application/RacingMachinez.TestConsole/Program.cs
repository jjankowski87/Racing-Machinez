using System;
using RacingMachinez.Core;
using RacingMachinez.Core.Logging;
using RacingMachinez.Contracts;

namespace RacingMachinez.TestConsole
{
    internal class Program
    {
        private static Writer arduino = new Writer();

        public static void Main(string[] args)
        {
            var logger = new DefaultLogger();
            var pluginsManager = new GamePluginsManager(logger);
            var plugins = pluginsManager.LoadPlugins("Plugins");
            var plugin = plugins[0];

            plugin.GameStateChanged += Plugin_GameStateChanged;
            plugin.GameDataChanged += Plugin_GameDataChanged;

            Console.ReadKey();
            arduino.Dispose();
        }

        private static void Plugin_GameDataChanged(object sender, GameDataChangedEventArgs e)
        {
            arduino.Send(e.GameData);
        }

        private static void Plugin_GameStateChanged(object sender, GameStateChangedEventArgs e)
        {
            Console.WriteLine(e.IsRunning ? "Game is running" : "Game is stopped");
        }
    }
}
