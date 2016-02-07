using System;
using System.Threading;
using RacingMachinez.Contracts;
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

                Thread.Sleep(25);

                //arduino.Send(new GameData { Revs = 0 });
                //Thread.Sleep(20);

                //for (int i = 0; i <= 9; i++)
                //{
                //    arduino.Send(new GameData { Revs = (ushort)(i * 1000) });
                //    Thread.Sleep(20);
                //}

                //for (int i = 8; i >= 0; i--)
                //{
                //    arduino.Send(new GameData { Revs = (ushort)(i * 1000) });
                //    Thread.Sleep(20);
                //}

                //arduino.Send(new GameData { Revs = 0 });

                //Console.ReadKey();
            }
        }
    }
}
