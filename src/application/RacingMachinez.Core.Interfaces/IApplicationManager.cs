using System.Threading.Tasks;

namespace RacingMachinez.Core.Interfaces
{
    public interface IApplicationManager
    {
        Task DeviceConnectedAsync();

        void DeviceDisconnected();

        void PerformClusterCalibration(short speed, short revs);

        Task PerformOperationsAsync();

        Task ReloadApplicationAsync();
    }
}
