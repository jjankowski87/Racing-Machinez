#ifndef StepperMotor_h
#define StepperMotor_h

#include <AccelStepper.h>

class StepperMotor
{
public:
  StepperMotor(int motorIn1, int motorIn2, int motorIn3, int motorIn4);
  ~StepperMotor();
  
  void Run();
  void MoveTo(int angle);
private:
  const float ANGLE_TO_STEPS = 5.73f;
  AccelStepper* _stepper;
};

#endif
