namespace RacingMachinez.Core.Interfaces
{
    public interface IApplicationManager
    {
        void DeviceConnected();

        void DeviceDisconnected();

        void PerformClusterCalibration(short speed, short revs);

        void PerformGameOperations();
    }
}
