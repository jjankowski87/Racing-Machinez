using System;

namespace RacingMachinez.Core.Interfaces.Logging
{
    public interface ILogger
    {
        void LogError(Exception exception);

        void LogError(string message);
    }
}
