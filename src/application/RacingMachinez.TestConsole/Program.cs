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
            var arduino = new Writer();

            while(true)
            {
                try
                {
                    arduino.Send(plugin.GetGameData());
                }
                catch (Exception ex)
                {
                    logger.LogError(ex);
                }

                Thread.Sleep(50);
            }
        }
    }
}
