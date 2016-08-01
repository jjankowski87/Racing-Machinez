using RacingMachinez.TrayApplication.Configuration.Interfaces;
using RacingMachinez.TrayApplication.Framework;
using System;
using System.Windows.Forms;
using RacingMachinez.Core.Interfaces;

namespace RacingMachinez.TrayApplication
{
    public class TrayApplicationContext : ApplicationContext
    {
        private readonly UsbNotificationNativeForm _notificationWindow;

        private readonly NotifyIcon _notifyIcon;

        private readonly Timer _applicationTimer;

        private readonly IApplicationManager _applicationManager;

        private readonly IFormManager _formManager;

        private bool _isInitialized = false;

        public TrayApplicationContext(IFormManager formManager, IApplicationManager applicationManager)
        {
            _formManager = formManager;
            _notifyIcon = new NotifyIcon
                {
                    Text = Resources.Strings.ApplicationName,
                    Icon = Resources.Graphics.Tachometer,
                    ContextMenu = new ContextMenu(new[]
                        {
                            new MenuItem(Resources.Strings.Configuration, OnConfigurationClicked),
                            new MenuItem(Resources.Strings.Exit, OnExitClicked)
                        }),
                    Visible = true,
                };

            // TODO: interval configurable
            _applicationManager = applicationManager;
            _applicationTimer = new Timer { Enabled = true, Interval = 25 };
            _applicationTimer.Tick += OnApplicationTimerTicked;
            _notificationWindow = new UsbNotificationNativeForm(applicationManager);
        }

        private async void OnApplicationTimerTicked(object sender, EventArgs e)
        {
            if (!_isInitialized)
            {
                await _applicationManager.ReloadApplicationAsync();
                _isInitialized = true;
                return;
            }

            await _applicationManager.PerformGameOperationsAsync();
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
