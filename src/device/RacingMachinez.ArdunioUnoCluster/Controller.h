#ifndef Controller_h
#define Controller_h

#include "StepperMotor.h"
#include "SerialReader.h"
#include "IClusterItem.h"

class Controller
{
public:
  Controller();
  ~Controller();

  void Update();
  void Setup();
  void SerialEvent();
private:
  static const int NUMBER_OF_CLUSTER_ITEMS = 2;
  static const int SPEED_AND_REVS_SCALE_ANGLE = 252;
  
  IClusterItem** _clusterItems;
  SerialReader* _serialReader;
  ClusterData _clusterData;
  
  void UpdateClusterItems(ClusterData clusterData);
  void PerformClusterInitialization();
};

#endif
