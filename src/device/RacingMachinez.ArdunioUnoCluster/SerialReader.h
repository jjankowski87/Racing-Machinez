#ifndef SerialReader_h
#define SerialReader_h

#include "ClusterData.h"
#include <Arduino.h>

class SerialReader
{
public:
  SerialReader();
  
  void Initialize();
  void Read();
  ClusterData GetLastClusterData();
  void SetState(ClusterState state);
  void ResetClusterData();
  
private:
  const int STRING_MAX_LENGTH = 64;
  String _inputString;
  int _inputLength;
  ClusterData _clusterData;
 
  void ParseClusterData();
  void ParseSpeed();
  void ParseRevs();
  void ParseClusterMode();
  String ParseInputMessage(String property);
};

#endif
