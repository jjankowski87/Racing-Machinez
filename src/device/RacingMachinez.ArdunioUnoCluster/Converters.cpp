#include "Converters.h"

int Converters::ConvertSpeedToAngle(int speed)
{
  speed = NormalizeSpeed(speed);
  
  if (speed < LOW_SPEED_THRESHOLD)
  {
    return LOW_SPEED_FACTOR * speed;
  }
  
  int highSpeedAngle = HIGH_SPEED_FACTOR * (speed - LOW_SPEED_THRESHOLD);
  return LOW_SPEED_ANGLE + highSpeedAngle;
}

int Converters::NormalizeSpeed(int speed)
{
  if (speed < MIN_SPEED)
  {
    return MIN_SPEED;
  }
  
  if (speed > MAX_SPEED)
  {
    return MAX_SPEED;
  }
  
  return speed;
}
