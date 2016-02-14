using System;

namespace RacingMachinez.Contracts
{
    public class GameData : ICloneable
    {
        public ushort Revs { get; set; }

        public ushort Speed { get; set; }

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
    }
}
