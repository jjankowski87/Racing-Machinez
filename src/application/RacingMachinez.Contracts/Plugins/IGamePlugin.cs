using System;

namespace RacingMachinez.Contracts.Plugins
{
    public interface IGamePlugin : IDisposable
    {
        string GameName { get; }

        GameData GameData { get; }

        bool IsRunning { get; }

        event EventHandler<GameDataChangedEventArgs> GameDataChanged;

        event EventHandler<GameStateChangedEventArgs> GameStateChanged;
    }
}
