namespace RacingMachinez.Plugins.ProjectCars.Structures.Enums
{
    internal enum CarFlags : uint
    {
        CarHeadlight = (1 << 0),
        CarEngineActive = (1 << 1),
        CarEngineWarning = (1 << 2),
        CarSpeedLimiter = (1 << 3),
        CarAbs = (1 << 4),
        CarHandbrake = (1 << 5),
    }
}