using RacingMachinez.TrayApplication.Configuration;
using RacingMachinez.TrayApplication.Configuration.Interfaces;
using RacingMachinez.TrayApplication.Framework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RacingMachinez.Core;
using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Core.Logging;

namespace RacingMachinez.TrayApplication
{
    public class CompositionRoot
    {
        public static ApplicationContext Create()
        {
            var viewFactory = new Dictionary<Type, Func<IView>>();
            var formManager = new FormManager(viewFactory);

            var logger = new DefaultLogger();
            var gamePluginManager = new PluginsManager<IGamePlugin>(logger);
            var clusterFactoryPluginManager = new PluginsManager<IClusterFactoryPlugin>(logger);
            var userNotifier = new UserNotifier(formManager);
            var applicationManager = new ApplicationManager(gamePluginManager, clusterFactoryPluginManager, userNotifier);

            viewFactory.Add(typeof(IConfigurationView), () => new ConfigurationForm(new ConfigurationPresenter(applicationManager)));

            return new TrayApplicationContext(formManager, applicationManager);
        }
    }
}
