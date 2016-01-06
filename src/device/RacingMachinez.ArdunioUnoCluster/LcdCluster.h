#ifndef LcdCluster_h
#define LcdCluster_h

#include <LiquidCrystal.h>
#include "ClusterData.h"

class LcdCluster
{
public:
  LcdCluster(int rsPin, int enablePin, int data4Pin, int data5Pin, int data6Pin, int data7Pin);
  ~LcdCluster();
  
  void Initialize();
  void DisplayClusterData(ClusterData clusterData);
  void DisplayText(String text);
  
private:
  LiquidCrystal* _lcd;
  ClusterData _previouslyDisplayed;
  
  void DisplaySpeed(int speed);
  void DisplayRevs(int revs);
  static int GetLength(int value);
  static int NormalizeValue(int value, int minValue, int maxValue);
};

#endif
