using System;
using System.ComponentModel.Composition;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Plugins.TestSample
{
    [Export(typeof (IGamePlugin))]
    public class TestSample : IGamePlugin
    {
        public GameData GameData
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string GameName => "Test Sample";

        public bool IsRunning
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<GameDataChangedEventArgs> GameDataChanged;
        public event EventHandler<GameStateChangedEventArgs> GameStateChanged;

        public GameData GetGameData()
        {
            return new GameData
            {
                Revs = 8000,
                Speed = 260
            };
        }
    }
}