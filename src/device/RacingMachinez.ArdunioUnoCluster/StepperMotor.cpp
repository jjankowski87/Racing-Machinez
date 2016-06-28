#include "StepperMotor.h"

StepperMotor::StepperMotor(int motorIn1, int motorIn2, int motorIn3, int motorIn4, ConvertToAngleFunction convertToAngleFunction, int initializationValue)
{
  _stepper = new AccelStepper(AccelStepper::HALF4WIRE, motorIn1, motorIn2, motorIn3, motorIn4);
  _convertToAngleFunction = convertToAngleFunction;
  _initializationValue = initializationValue;
  _initializationPhase = 0;

  _stepper->setCurrentPosition(0);  
  _stepper->setAcceleration(600.0f);
  _stepper->setMaxSpeed(550);
}

StepperMotor::~StepperMotor()
{
  delete _stepper; 
}

boolean StepperMotor::PerformInitialization()
{
  if (_initializationPhase == 0)
  {
    _stepper->moveTo(_initializationValue * ANGLE_TO_STEPS);
    _initializationPhase++;
  }
  else if (_initializationPhase == 1 && !_stepper->isRunning())
  {
    _stepper->moveTo(0);
    _initializationPhase++;
  }
  else if (_initializationPhase == 2 && !_stepper->isRunning())
  {
    return true;
  }
  
  return false;
}

void StepperMotor::FinishInitialization()
{    
  _initializationPhase = 0;
}

void StepperMotor::UpdateData(ClusterData clusterData)
{
  if (_previousState == Calibration && clusterData.State != Calibration)
  {
    _previousAngle = _previousWorkingAngle;
    _stepper->setCurrentPosition(_previousWorkingPosition);
  }
  else if (_previousState != Calibration && clusterData.State == Calibration)
  {
    _previousWorkingPosition = _stepper->currentPosition();
    _previousWorkingAngle = _previousAngle;
    
    _previousAngle = 0;
    _stepper->setCurrentPosition(0);
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
