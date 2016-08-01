using System;
using System.Collections.Generic;
using System.Linq;
using RacingMachinez.TrayApplication.Configuration.Interfaces;
using System.Windows.Forms;

namespace RacingMachinez.TrayApplication.Configuration
{
    public partial class ConfigurationForm : Form, IConfigurationView
    {
        private readonly IConfigurationPresenter _presenter;

        public ConfigurationForm(IConfigurationPresenter presenter)
        {
            InitializeComponent();

            _presenter = presenter;
            _presenter.View = this;
        }

        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await _presenter.LoadDataAsync();
        }

        private void ButtonSelectDirectoryClicked(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = PluginsPath;
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    PluginsPath = folderDialog.SelectedPath;
                    _presenter.ReloadPluginsData(PluginsPath);
                }
            }
        }

        private void ButtonSaveClicked(object sender, EventArgs e)
        {
        }

        private void ButtonCloseClicked(object sender, EventArgs e)
        {
            Close();
        }

        public string PluginsPath
        {
            get { return txtPluginsDirectory.Text; }
            set { txtPluginsDirectory.Text = value; }
        }

        public string SelectedComPort
        {
            get { return cbComPort.SelectedText; }
            set { cbComPort.SelectedItem = value; }
        }

        public void DisplayComPorts(IEnumerable<string> comPorts)
        {
            cbComPort.Items.Clear();
            cbComPort.Items.AddRange(comPorts.ToArray());
        }

        public void DisplayClusterPlugins(IEnumerable<PluginModel> pluginNames)
        {
            cbActiveClusterPlugin.DisplayMember = nameof(PluginModel.Name);
            cbActiveClusterPlugin.Items.Clear();
            cbActiveClusterPlugin.Items.AddRange(pluginNames.ToArray());
        }
    }
}
