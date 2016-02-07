#ifndef Controller_h
#define Controller_h

#include "SerialReader.h"
#include "IClusterItem.h"

class Controller
{
public:
  Controller(ClusterItems clusterItems);
  ~Controller();

  void Update();
  void Setup();
  void SerialEvent();
private:
  static const int SPEED_AND_REVS_SCALE_ANGLE = 252;
  
  IClusterItem** _clusterItems;
  SerialReader* _serialReader;
  ClusterData _clusterData;
  int _numberOfClusterItems;
  
  void InitializeClusterItems(ClusterItems clusterItems);
  void UpdateClusterItems(ClusterData clusterData);
  void PerformClusterInitialization();
};

#endif
