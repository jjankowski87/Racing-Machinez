#ifndef TftCluster_h
#define TftCluster_h

#include <ILI9341_due.h>
#include "IClusterItem.h"
#include "ClusterData.h"

class TftCluster : public IClusterItem
{
public:
  TftCluster(int csPin, int dcPin, int rstPin);
  virtual ~TftCluster();
  
  virtual boolean PerformInitialization();
  virtual void FinishInitialization();
  virtual void UpdateData(ClusterData clusterData);
private:
  ILI9341_due* _tft;
  char _previousGear;
  bool _isInitializationStarted;
  
  void DisplayGear(char gear);
};

#endif
