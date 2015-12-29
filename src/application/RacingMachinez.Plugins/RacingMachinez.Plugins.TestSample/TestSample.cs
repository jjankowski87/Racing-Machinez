using System.ComponentModel.Composition;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Plugins.TestSample
{
    [Export(typeof (IGamePlugin))]
    public class TestSample : IGamePlugin
    {
        public string GameName => "Test Sample";

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