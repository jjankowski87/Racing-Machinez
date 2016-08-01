using System.Threading.Tasks;
using RacingMachinez.TrayApplication.Framework;

namespace RacingMachinez.TrayApplication.Configuration.Interfaces
{
    public interface IConfigurationPresenter : IPresenter<IConfigurationView>
    {
        Task LoadDataAsync();

        void ReloadPluginsData(string pluginsDirectory);
    }
}
