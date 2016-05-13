using RacingMachinez.Plugins.ProjectCars.Structures.Enums;

namespace RacingMachinez.Plugins.ProjectCars.Structures
{
    internal struct CarState
    {
        public CarFlags CarFlags;                              // [ enum Car Flags ]
        public float OilTempCelsius;                           // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        public float OilPressureKPa;                           // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float WaterTempCelsius;                         // [ UNITS = Celsius ]   [ UNSET = 0.0f ]
        public float WaterPressureKPa;                         // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float FuelPressureKPa;                          // [ UNITS = Kilopascal ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float FuelLevel;                                // [ RANGE = 0.0f->1.0f ]
        public float FuelCapacity;                             // [ UNITS = Liters ]   [ RANGE = 0.0f->1.0f ]   [ UNSET = 0.0f ]
        public float Speed;                                    // [ UNITS = Metres per-second ]   [ RANGE = 0.0f->... ]
        public float Rpm;                                      // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float MaxRpm;                                   // [ UNITS = Revolutions per minute ]   [ RANGE = 0.0f->... ]   [ UNSET = 0.0f ]
        public float Brake;                                    // [ RANGE = 0.0f->1.0f ]
        public float Throttle;                                 // [ RANGE = 0.0f->1.0f ]
        public float Clutch;                                   // [ RANGE = 0.0f->1.0f ]
        public float Steering;                                 // [ RANGE = -1.0f->1.0f ]
        public int Gear;                                       // [ RANGE = -1 (Reverse)  0 (Neutral)  1 (Gear 1)  2 (Gear 2)  etc... ]   [ UNSET = 0 (Neutral) ]
        public int NumGears;                                   // [ RANGE = 0->... ]   [ UNSET = -1 ]
        public float OdometerKm;                               // [ RANGE = 0.0f->... ]   [ UNSET = -1.0f ]
        public bool AntiLockActive;                            // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
        public int LastOpponentCollisionIndex;                 // [ RANGE = 0->STORED_PARTICIPANTS_MAX ]   [ UNSET = -1 ]
        public float LastOpponentCollisionMagnitude;           // [ RANGE = 0.0f->... ]
        public bool BoostActive;                               // [ UNITS = boolean ]   [ RANGE = false->true ]   [ UNSET = false ]
        public float BoostAmount;                              // [ RANGE = 0.0f->100.0f ] 
    }
}