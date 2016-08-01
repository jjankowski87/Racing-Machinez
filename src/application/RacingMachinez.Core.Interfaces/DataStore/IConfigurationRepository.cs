using System.Threading.Tasks;
using RacingMachinez.Contracts.DataStore;

namespace RacingMachinez.Core.Interfaces.DataStore
{
    public interface IConfigurationRepository
    {
        Task<Configuration> LoadConfigurationAsync();

        Task<bool> SaveConfigurationAsync(Configuration configuration);
    }
}
