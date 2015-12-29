using System;
using System.Linq;
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

            Console.WriteLine(string.Join(", ", plugins.Select(p => p.GameName)));

            Console.ReadKey();
        }
    }
}
