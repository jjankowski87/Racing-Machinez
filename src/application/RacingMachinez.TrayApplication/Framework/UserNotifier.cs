using System;
using System.Windows.Forms;
using RacingMachinez.Core;
using RacingMachinez.TrayApplication.Configuration.Interfaces;
using RacingMachinez.TrayApplication.Resources;

namespace RacingMachinez.TrayApplication.Framework
{
    public class UserNotifier : IUserNotifier
    {
        private const int NotificationBalloonTipTimeout = 3000;

        private readonly IFormManager _formManager;

        public UserNotifier(IFormManager formManager)
        {
            _formManager = formManager;
        }

        public void ClusterConnectionChanged(string clusterName, bool isConnected)
        {
            var title = isConnected ? Strings.ClusterConnectedTitle : Strings.ClusterDisconnectedTitle;
            var message = isConnected ? Strings.ClusterConnectedMessage : Strings.ClusterDisconnectedMessage;

            ShowNotification(title, string.Format(message, clusterName));
        }

        public void GameStateChanged(string gameName, bool isStarted)
        {
            var title = isStarted ? Strings.GameStartedTitle : Strings.GameStoppedTitle;
            var message = isStarted ? Strings.GameStartedMessage : Strings.GameStoppedMessage;

            ShowNotification(title, string.Format(message, gameName));
        }

        private void ShowNotification(string title, string text)
        {
            var notification = new NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Information,
                BalloonTipIcon = ToolTipIcon.Info,
                BalloonTipTitle = title,
                BalloonTipText = text,
            };

            notification.BalloonTipClicked += NotificationBalloonTipClicked;
            notification.BalloonTipClosed += NotificationBalloonTipClosed;
            notification.ShowBalloonTip(NotificationBalloonTipTimeout);
        }

        private void HideNotification(NotifyIcon notification)
        {
            if (notification == null)
            {
                return;
            }

            notification.BalloonTipClicked -= NotificationBalloonTipClicked;
            notification.BalloonTipClosed -= NotificationBalloonTipClosed;
            notification.Visible = false;
            notification.Dispose();
        }

        private void NotificationBalloonTipClicked(object sender, EventArgs e)
        {
            _formManager.ShowView<IConfigurationView>();
            HideNotification(sender as NotifyIcon);
        }

        private void NotificationBalloonTipClosed(object sender, EventArgs e)
        {
            HideNotification(sender as NotifyIcon);
        }
    }
}
