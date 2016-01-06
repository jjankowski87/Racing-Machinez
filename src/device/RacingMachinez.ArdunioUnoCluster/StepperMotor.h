#ifndef StepperMotor_h
#define StepperMotor_h

#include <AccelStepper.h>

typedef int (*ConvertToAngleFunction)(int);

class StepperMotor
{
public:
  StepperMotor(int motorIn1, int motorIn2, int motorIn3, int motorIn4);
  ~StepperMotor();
  
  void Reset();
  void SetConvertFunction(ConvertToAngleFunction convertToAngleFunction);
  void Run();
  void MoveTo(int angle);
  void Move(int angle);
  boolean IsRunning();
private:
  const float ANGLE_TO_STEPS = 6.0f;
  AccelStepper* _stepper;
  ConvertToAngleFunction _convertToAngleFunction;
};

#endif
