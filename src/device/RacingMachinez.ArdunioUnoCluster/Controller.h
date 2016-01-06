#ifndef Controller_h
#define Controller_h

#include "StepperMotor.h"
#include "SerialReader.h"
#include "LcdCluster.h"

class Controller
{
public:
  Controller();
  ~Controller();

  void Update();
  void Setup();
  void SerialEvent();
private:
  int _initializationPhase;
  StepperMotor* _speedStepper;
  LcdCluster* _lcdCluster;
  SerialReader* _serialReader;
  ClusterState _previousState;
  
  void UpdateInitialization();
  void UpdateCalibration(ClusterData clusterData);
  void UpdateWorking(ClusterData clusterData);
};

#endif
