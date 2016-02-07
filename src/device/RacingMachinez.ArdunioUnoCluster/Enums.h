#ifndef Enums_h
#define Enums_h

enum ClusterState
{
  Unknown = 0,
  Initialization = 1,
  Calibration = 2,
  Working = 3  
};

enum ClusterItems
{
    Tachometer = 1 << 0,
    Speedometer = 1 << 1,
    Tft = 1 << 2,
};

inline ClusterItems operator|(ClusterItems a, ClusterItems b)
{
  return static_cast<ClusterItems>(static_cast<int>(a) | static_cast<int>(b));
}

#endif
