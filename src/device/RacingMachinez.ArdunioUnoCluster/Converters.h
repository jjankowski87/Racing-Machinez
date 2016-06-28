#ifndef Converters_h
#define Converters_h

#include "ClusterData.h"

class Converters
{
public:
  static int ConvertSpeedToAngle(ClusterData clusterData, bool enabled);
  static int ConvertRevsToAngle(ClusterData clusterData, bool enabled);
private:
  static constexpr int MIN_SPEED = 0;
  // TODO: change MAX_SPEED to to max position of indicator
  static constexpr int MAX_SPEED = 290;
  static constexpr float SPEED_FACTOR = 0.97166f;
  
  static constexpr int MIN_REVS = 0;
  static constexpr int MAX_REVS = 9000;
  static constexpr float REVS_FACTOR = 0.031579f;
  
  static int Normalize(int value, int minValue, int maxValue);
};

#endif

