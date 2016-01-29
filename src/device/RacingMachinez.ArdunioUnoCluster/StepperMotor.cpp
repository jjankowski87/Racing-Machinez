#include "StepperMotor.h"

StepperMotor::StepperMotor(int motorIn1, int motorIn2, int motorIn3, int motorIn4, ConvertToAngleFunction convertToAngleFunction, int helloValue)
{
  _stepper = new AccelStepper(AccelStepper::HALF4WIRE, motorIn1, motorIn2, motorIn3, motorIn4);
  _convertToAngleFunction = convertToAngleFunction;
  _helloValue = helloValue;
  _helloPhase = 0;

  _stepper->setCurrentPosition(0);
  _stepper->setMaxSpeed(700);
  _stepper->setAcceleration(3000.0f);
  _stepper->setSpeed(700);
}

StepperMotor::~StepperMotor()
{
  delete _stepper; 
}

boolean StepperMotor::Hello()
{
  if (_helloPhase == 0)
  {
    _stepper->moveTo(_helloValue * ANGLE_TO_STEPS);
    _helloPhase++;
  }
  else if (_helloPhase == 1 && !_stepper->isRunning())
  {
    _stepper->moveTo(0);
    _helloPhase++;
  }
  else if (_helloPhase == 2 && !_stepper->isRunning())
  {
    return true;
  }
  
  return false;
}

void StepperMotor::UpdateData(ClusterData clusterData)
{
  if (HasStateChangedFrom(clusterData.State, Calibration))
  {
    _stepper->setCurrentPosition(0);
  }
  else if (HasStateChangedFrom(clusterData.State, Initialization))
  {
    _helloPhase = 0;
  }
  
  int angle = CalculateAngle(clusterData);
  if (angle != _previousAngle)
  {
    Move(angle, clusterData.State);
    _previousAngle = angle;
  }
  
  _previousState = clusterData.State;
  _stepper->run();
}

int StepperMotor::CalculateAngle(ClusterData clusterData)
{
  switch (clusterData.State)
  {
    case Working:
      return _convertToAngleFunction(clusterData, true);   
    case Calibration:
      return _convertToAngleFunction(clusterData, false);
    default:
      return _previousAngle;
  }
}

void StepperMotor::Move(int angle, ClusterState clusterState)
{ 
  switch (clusterState)
  {
    case Working:
      _stepper->moveTo(angle * ANGLE_TO_STEPS);
      break;
    case Calibration:
      _stepper->move(angle * ANGLE_TO_STEPS);
      break;
  }
}

boolean StepperMotor::HasStateChangedFrom(ClusterState currentState, ClusterState requiredState)
{
  return _previousState == requiredState && currentState != requiredState;
}
