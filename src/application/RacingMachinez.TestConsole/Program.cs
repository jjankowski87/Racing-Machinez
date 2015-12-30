using System;
using System.Threading;
using RacingMachinez.Core;
using RacingMachinez.Core.Logging;

namespace RacingMachinez.TestConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var logger = new DefaultLogger();
            var pluginsManager = new GamePluginsManager(logger);
            var plugins = pluginsManager.LoadPlugins("Plugins");
            var plugin = plugins[0];

            while(true)
            {
                try
                {
                    Console.Clear();

                    var gameData = plugin.GetGameData();
                    Console.WriteLine("Speed: {0:000}", gameData.Speed);
                    Console.WriteLine("Revs: {0:0000}", gameData.Revs);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex);
                }

                Thread.Sleep(10);
            }
        }
    }
}
