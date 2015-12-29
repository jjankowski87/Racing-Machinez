using System.ComponentModel.Composition;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Plugins.ProjectCars
{
    [Export(typeof (IGamePlugin))]
    public class ProjectCarsPlugin : IGamePlugin
    {
        public string GameName => "Project CARS";

        public GameData GetGameData()
        {
            return new GameData
            {
                Revs = 1500,
                Speed = 120
            };
        }
    }
}