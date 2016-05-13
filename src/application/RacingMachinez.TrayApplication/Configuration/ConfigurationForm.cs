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
    }
}
