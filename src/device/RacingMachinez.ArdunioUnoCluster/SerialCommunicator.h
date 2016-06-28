#ifndef SerialCommunicator_h
#define SerialCommunicator_h

#include "ClusterData.h"
#include <Arduino.h>

class SerialCommunicator
{
public:
  SerialCommunicator();
  
  void Initialize();
  void Read(ClusterData* clusterData);
  void SendClusterState(ClusterData* clusterData);
private:
  const int STRING_MAX_LENGTH = 64;
  String _inputString;
  int _inputLength;

  int _workingSpeed;
  int _workingRevs;
 
  void ParseInputMessage(ClusterData* clusterData);
  void ParseSpeed(ClusterData* clusterData);
  void ParseRevs(ClusterData* clusterData);
  void ParseClusterMode(ClusterData* clusterData);
  void ParseGear(ClusterData* clusterData);
  String ParseInputMessage(String property);
};

#endif

