#ifndef Converters_h
#define Converters_h

#include "ClusterData.h"

class Converters
{
public:
  static int ConvertSpeedToAngle(ClusterData clusterData, bool enabled);
  static int ConvertRevsToAngle(ClusterData clusterData, bool enabled);
private:
  static const int MIN_SPEED = 0;
  // TODO: change MAX_SPEED to to max position of indicator
  static const int MAX_SPEED = 260;
  static const float SPEED_FACTOR = 0.97166f;
  
  static const int MIN_REVS = 0;
  static const int MAX_REVS = 9000;
  static const float REVS_FACTOR = 0.031579f;
  
  static int Normalize(int value, int minValue, int maxValue);
};

#endif
