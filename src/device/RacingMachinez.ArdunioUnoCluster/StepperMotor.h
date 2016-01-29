#ifndef StepperMotor_h
#define StepperMotor_h

#include <AccelStepper.h>
#include "IClusterItem.h"
#include "ClusterData.h"

typedef int (*ConvertToAngleFunction)(ClusterData, bool);

class StepperMotor : public IClusterItem
{
public:
  StepperMotor(int motorIn1, int motorIn2, int motorIn3, int motorIn4, ConvertToAngleFunction convertToAngleFunction, int helloValue);
  virtual ~StepperMotor();  
  
  virtual boolean Hello();
  virtual void UpdateData(ClusterData clusterData);
private:
  const float ANGLE_TO_STEPS = 3.36f;
  AccelStepper* _stepper;
  ClusterState _previousState;
  int _previousAngle;
  int _helloValue;
  short int _helloPhase;
  ConvertToAngleFunction _convertToAngleFunction;  
  
  int CalculateAngle(ClusterData clusterData);
  void Move(int angle, ClusterState clusterState);
  boolean HasStateChangedFrom(ClusterState currentState, ClusterState requiredState);
};

#endif
