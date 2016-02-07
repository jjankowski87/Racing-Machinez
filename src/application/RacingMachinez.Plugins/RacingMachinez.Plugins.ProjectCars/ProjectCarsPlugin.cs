using System;
using System.ComponentModel.Composition;
using System.IO.MemoryMappedFiles;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Plugins.ProjectCars
{
    [Export(typeof (IGamePlugin))]
    public class ProjectCarsPlugin : IGamePlugin
    {
        private readonly ProjectCarsGameDataReader _dataReader;

        public string GameName => "Project CARS";

        public ProjectCarsPlugin()
        {
            _dataReader = new ProjectCarsGameDataReader();
        }

        public GameData GetGameData()
        {
            try
            {
                using (var file = MemoryMappedFile.OpenExisting("$pcars$"))
                {
                    using (var viewAccessor = file.CreateViewAccessor())
                    {
                        var gameData = _dataReader.ReadData(viewAccessor);

                        return new GameData
                        {
                            Revs = (ushort)gameData.CarState.Rpm,
                            Speed = (ushort)(gameData.CarState.Speed * 3.6f),
                            Gear = ConvertGear(gameData.CarState.Gear)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new GameData();
        }

        private static char ConvertGear(int gear)
        {
            if (gear >= 1 && gear <= 9)
            {
                return Convert.ToChar(48 + gear);
            }

            if (gear < 0)
            {
                return 'R';
            }

            return 'N';
        }
    }
}