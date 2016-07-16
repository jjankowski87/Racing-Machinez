using RacingMachinez.Core.Interfaces;
using RacingMachinez.TrayApplication.Configuration.Interfaces;
using RacingMachinez.TrayApplication.Framework;

namespace RacingMachinez.TrayApplication.Configuration
{
    public class ConfigurationPresenter : PresenterBase<IConfigurationView>, IConfigurationPresenter
    {
        private readonly IApplicationManager _applicationManager;

        public ConfigurationPresenter(IApplicationManager applicationManager)
        {
            _applicationManager = applicationManager;
        }
    }
}
