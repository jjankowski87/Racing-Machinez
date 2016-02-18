using System;

namespace RacingMachinez.Contracts
{
    public class GameData : ICloneable
    {
        public short Revs { get; set; }

        public short Speed { get; set; }

        public char Gear { get; set; }

        public object Clone()
        {
            return new GameData
                   {
                       Revs = Revs,
                       Speed = Speed,
                       Gear = Gear
                   };
        }

        public override bool Equals(object obj)
        {
            GameData gameData = obj as GameData;
            if (gameData == null)
            {
                return false;
            }

            return Revs == gameData.Revs && Speed == gameData.Speed && Gear == gameData.Gear;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var result = 0;
                result = (result * 397) ^ Revs;
                result = (result * 397) ^ Speed;
                result = (result * 397) ^ Gear;
                return result;
            }
        }
    }
}
