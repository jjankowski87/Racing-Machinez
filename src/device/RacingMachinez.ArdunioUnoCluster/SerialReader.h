#ifndef SerialReader_h
#define SerialReader_h

#include "ClusterData.h"
#include <Arduino.h>

class SerialReader
{
public:
  SerialReader();
  
  void Initialize();
  void Read(ClusterData* clusterData);
  
private:
  const int STRING_MAX_LENGTH = 64;
  String _inputString;
  int _inputLength;
 
  void ParseClusterData(ClusterData* clusterData);
  void ParseSpeed(ClusterData* clusterData);
  void ParseRevs(ClusterData* clusterData);
  void ParseClusterMode(ClusterData* clusterData);
  String ParseInputMessage(String property);
};

#endif
