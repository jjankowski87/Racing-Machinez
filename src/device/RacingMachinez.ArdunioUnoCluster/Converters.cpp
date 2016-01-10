#include "Converters.h"

int Converters::ConvertSpeedToAngle(int speed)
{
  speed = Normalize(speed, MIN_SPEED, MAX_SPEED);
  
  if (speed < LOW_SPEED_THRESHOLD)
  {
    return LOW_SPEED_FACTOR * speed;
  }
  
  int highSpeedAngle = HIGH_SPEED_FACTOR * (speed - LOW_SPEED_THRESHOLD);
  return LOW_SPEED_ANGLE + highSpeedAngle;
}

int Converters::ConvertRevsToAngle(int revs)
{
  revs = Normalize(revs, MIN_REVS, MAX_REVS);
  
  return REVS_FACTOR * revs;
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
