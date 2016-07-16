using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RacingMachinez.Core;
using RacingMachinez.Core.Interfaces;

namespace RacingMachinez.TrayApplication.Framework
{
    internal class UsbNotificationNativeForm : Form
    {
        private readonly IApplicationManager _applicationManager;

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        static IntPtr HWND_MESSAGE = new IntPtr(-3);

        public UsbNotificationNativeForm(IApplicationManager applicationManager)
        {
            _applicationManager = applicationManager;
            UsbNotification.RegisterUsbDeviceNotification(Handle);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetParent(Handle, HWND_MESSAGE);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == UsbNotification.DeviceChangeEvent)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.UsbDeviceDisconnected:
                        _applicationManager.DeviceDisconnected();
                        break;
                    case UsbNotification.UsbDeviceConnected:
                        _applicationManager.DeviceConnected();
                        break;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UsbNotification.UnregisterUsbDeviceNotification();
            }

            base.Dispose(disposing);
        }
    }
}
