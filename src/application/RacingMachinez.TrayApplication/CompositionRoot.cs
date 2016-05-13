using RacingMachinez.TrayApplication.Configuration;
using RacingMachinez.TrayApplication.Configuration.Interfaces;
using RacingMachinez.TrayApplication.Framework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RacingMachinez.TrayApplication
{
    public class CompositionRoot
    {
        public static ApplicationContext Create()
        {
            var viewFactory = new Dictionary<Type, Func<IView>>
            {
                { typeof(IConfigurationView), () => new ConfigurationForm(new ConfigurationPresenter()) }
            };

            return new TrayApplicationContext(new FormManager(viewFactory));
        }
    }
}
