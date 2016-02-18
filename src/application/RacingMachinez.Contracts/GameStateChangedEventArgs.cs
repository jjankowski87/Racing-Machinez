using System;

namespace RacingMachinez.Contracts
{
    public class GameStateChangedEventArgs : EventArgs
    {
        public GameStateChangedEventArgs(bool isRunning)
        {
            IsRunning = isRunning;
        }

        public bool IsRunning { get; private set; }
    }
}