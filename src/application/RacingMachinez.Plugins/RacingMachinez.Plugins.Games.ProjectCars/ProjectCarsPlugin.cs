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
        private const string MemoryFileName = "$pcars$";

        private readonly ProjectCarsGameDataReader _dataReader;

        public Guid GameId => new Guid(0x1a8438d1, 0xb287, 0x47b5, 0xb3, 0x48, 0x63, 0x5, 0x82, 0x31, 0xc7, 0xb7);

        public string GameName => "Project CARS";

        public ProjectCarsPlugin()
        {
            _dataReader = new ProjectCarsGameDataReader();
        }

        public bool IsRunning()
        {
            try
            {
                using (var file = MemoryMappedFile.OpenExisting(MemoryFileName))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public GameData GetGameData()
        {
            try
            {
                using (var file = MemoryMappedFile.OpenExisting(MemoryFileName))
                {
                    using (var viewAccessor = file.CreateViewAccessor())
                    {
                        return ProjectCarsGameDataConverter.ConvertGameData(_dataReader.ReadData(viewAccessor));
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}