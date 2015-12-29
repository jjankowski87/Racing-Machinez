using System;
using RacingMachinez.Core.Interfaces.Logging;

namespace RacingMachinez.Core.Logging
{
    public class DefaultLogger : ILogger
    {
        public void LogError(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }

        public void LogError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
