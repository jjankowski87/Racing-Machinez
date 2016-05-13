using System.IO;
using RacingMachinez.Plugins.ProjectCars.Structures;

namespace RacingMachinez.Plugins.ProjectCars
{
    internal class ProjectCarsGameDataReader
    {
        private const int StringLengthMax = 64;

        private const long GameStatesPosition = 8;

        private const long VehicleInformationPosition = 6444;

        private const long CarStatePosition = 6812;

        public ProjectCarsGameData ReadData(UnmanagedMemoryAccessor memoryAccessor)
        {
            return new ProjectCarsGameData
                   {
                       GameStates = ReadGameStates(memoryAccessor),
                       VehicleInformation = ReadVehicleInformation(memoryAccessor),
                       CarState = ReadCarState(memoryAccessor),
                   };
        }

        private static GameStates ReadGameStates(UnmanagedMemoryAccessor memoryAccessor)
        {
            GameStates gameStates;
            memoryAccessor.Read(GameStatesPosition, out gameStates);

            return gameStates;
        }

        private static VehicleInformation ReadVehicleInformation(UnmanagedMemoryAccessor memoryAccessor)
        {
            var carName = memoryAccessor.ReadString(VehicleInformationPosition, StringLengthMax);
            var carClassName = memoryAccessor.ReadString(VehicleInformationPosition + StringLengthMax, StringLengthMax);

            return new VehicleInformation { CarName = carName, CarClassName = carClassName };
        }

        private static CarState ReadCarState(UnmanagedMemoryAccessor memoryAccessor)
        {
            CarState carState;
            memoryAccessor.Read(CarStatePosition, out carState);

            return carState;
        }
    }
}
