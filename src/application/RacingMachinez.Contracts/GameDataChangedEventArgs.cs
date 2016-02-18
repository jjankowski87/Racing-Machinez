using System;

namespace RacingMachinez.Contracts
{
    public class GameDataChangedEventArgs : EventArgs
    {
        public GameDataChangedEventArgs(GameData gameData)
        {
            GameData = gameData;
        }

        public GameData GameData { get; private set; }
    }
}
