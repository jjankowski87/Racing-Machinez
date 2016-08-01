using System;

namespace RacingMachinez.Contracts.Plugins
{
    public interface IGamePlugin
    {
        Guid GameId { get; }

        string GameName { get; }

        bool IsRunning();

        GameData GetGameData();
    }
}
