#ifndef Converters_h
#define Converters_h

class Converters
{
public:
  static int ConvertSpeedToAngle(int speed);
private:
  static const int MIN_SPEED = 0;
  static const int MAX_SPEED = 260;
  static const int LOW_SPEED_THRESHOLD = 80;
  static const float LOW_SPEED_FACTOR = 1.35f;
  static const float HIGH_SPEED_FACTOR = 0.81f;
  static const int LOW_SPEED_ANGLE = 108;  // 80 * 1.35
  
  static int NormalizeSpeed(int speed);
};

#endif
