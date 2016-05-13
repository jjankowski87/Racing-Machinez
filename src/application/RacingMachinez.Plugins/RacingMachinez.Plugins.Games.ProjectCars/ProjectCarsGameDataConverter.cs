using RacingMachinez.Contracts;
using RacingMachinez.Plugins.ProjectCars.Structures;
using System;

namespace RacingMachinez.Plugins.ProjectCars
{
    internal static class ProjectCarsGameDataConverter
    {
        public static GameData ConvertGameData(ProjectCarsGameData projectCarsGameData)
        {
            return new GameData
            {
                Revs = (short)projectCarsGameData.CarState.Rpm,
                Speed = (short)(projectCarsGameData.CarState.Speed * 3.6f),
                Gear = ConvertGear(projectCarsGameData.CarState.Gear)
            };
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
