using System.Threading.Tasks;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Core.Interfaces
{
    public interface IGamesManager
    {
        Task ReloadGamesAsync();

        Task<IGamePlugin> GetActiveGamePluginAsync();
    }
}
