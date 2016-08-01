using RacingMachinez.TrayApplication.Configuration;
using RacingMachinez.TrayApplication.Configuration.Interfaces;
using RacingMachinez.TrayApplication.Framework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RacingMachinez.Core;
using RacingMachinez.Contracts.Plugins;
using RacingMachinez.Core.DataStore;
using RacingMachinez.Core.Logging;

namespace RacingMachinez.TrayApplication
{
    public class CompositionRoot
    {
        public static ApplicationContext Create()
        {
            // TODO: use simple injector
            var viewFactory = new Dictionary<Type, Func<IView>>();
            var formManager = new FormManager(viewFactory);

            var logger = new DefaultLogger();
            var gamePluginManager = new PluginsManager<IGamePlugin>(logger);
            var clusterFactoryPluginManager = new PluginsManager<IClusterFactoryPlugin>(logger);
            var userNotifier = new UserNotifier(formManager);
            var configurationRepository = new ConfigurationRepository();
            var deviceManager = new DeviceManager(clusterFactoryPluginManager, configurationRepository, userNotifier);
            var gameManager = new GameManager(gamePluginManager, configurationRepository);
            var applicationManager = new ApplicationManager(gameManager, deviceManager);

            viewFactory.Add(typeof(IConfigurationView), () => new ConfigurationForm(new ConfigurationPresenter(gamePluginManager, clusterFactoryPluginManager, configurationRepository)));

            return new TrayApplicationContext(formManager, applicationManager);
        }
    }
}
