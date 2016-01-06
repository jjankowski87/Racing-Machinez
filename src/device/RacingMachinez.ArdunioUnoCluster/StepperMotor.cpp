#include "StepperMotor.h"

StepperMotor::StepperMotor(int motorIn1, int motorIn2, int motorIn3, int motorIn4)
{
  _stepper = new AccelStepper(AccelStepper::FULL4WIRE, motorIn1, motorIn3, motorIn2, motorIn4);
  Reset();
}

StepperMotor::~StepperMotor()
{
  delete _stepper; 
}

void StepperMotor::Reset()
{
  _stepper->setCurrentPosition(0);
  _stepper->setMaxSpeed(1000);
  _stepper->setAcceleration(1000.0);
  _stepper->setSpeed(1000);
}

void StepperMotor::Run()
{
  _stepper->run();
}

void StepperMotor::MoveTo(int angle)
{
  if (_convertToAngleFunction != 0)
  {
    angle = _convertToAngleFunction(angle);
  }
  
  _stepper->moveTo(angle * ANGLE_TO_STEPS);
}

void StepperMotor::Move(int angle)
{
  if (_stepper->isRunning())
  {
    return;
  }
  
  _stepper->move(angle * ANGLE_TO_STEPS);
}

void StepperMotor::SetConvertFunction(ConvertToAngleFunction convertToAngleFunction)
{
  _convertToAngleFunction = convertToAngleFunction;
}

boolean StepperMotor::IsRunning()
{
  return _stepper->isRunning();
}
