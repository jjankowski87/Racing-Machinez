#include "Converters.h"

int Converters::ConvertSpeedToAngle(ClusterData clusterData, bool enabled)
{
  if (!enabled)
  {
    return clusterData.Speed;
  }
  
  return SPEED_FACTOR * Normalize(clusterData.Speed, MIN_SPEED, MAX_SPEED);;
}

int Converters::ConvertRevsToAngle(ClusterData clusterData, bool enabled)
{
  if (!enabled)
  {
    return clusterData.Revs;
  }

  return REVS_FACTOR * Normalize(clusterData.Revs, MIN_REVS, MAX_REVS);
}

int Converters::Normalize(int value, int minValue, int maxValue)
{
  if (value < minValue)
  {
    return minValue;
  }
  
  if (value > maxValue)
  {
    return maxValue;
  }
  
  return value;
}

