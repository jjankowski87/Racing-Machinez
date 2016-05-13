using RacingMachinez.TrayApplication.Configuration.Interfaces;
using RacingMachinez.TrayApplication.Framework;
using System;
using System.Windows.Forms;

namespace RacingMachinez.TrayApplication
{
    public class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;

        private IFormManager _formManager;

        public TrayApplicationContext(IFormManager formManager)
        {
            _formManager = formManager;
            _notifyIcon = new NotifyIcon
                {
                    Text = Resources.Strings.ApplicationName,
                    Icon = Resources.Graphics.Tachometer,
                    ContextMenu = new ContextMenu(new[]
                        {
                            new MenuItem(Resources.Strings.Configuration, new EventHandler(OnConfigurationClicked)),
                            new MenuItem(Resources.Strings.Exit, new EventHandler(OnExitClicked))
                        }),
                    Visible = true,
                };
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            ExitThread();
        }

        private void OnConfigurationClicked(object sender, EventArgs e)
        {
            _formManager.ShowView<IConfigurationView>();
        }
    }
}
