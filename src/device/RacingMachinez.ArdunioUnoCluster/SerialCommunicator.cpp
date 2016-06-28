#include "SerialCommunicator.h"

SerialCommunicator::SerialCommunicator()
{ 
  _inputString.reserve(STRING_MAX_LENGTH);
  _inputString = "";
  _inputLength = 0; 
}

void SerialCommunicator::Initialize()
{
  Serial.begin(9600);
}

void SerialCommunicator::Read(ClusterData* clusterData)
{
  while (Serial.available())
  {
    char inputChar = (char)Serial.read();
    if (_inputLength >= STRING_MAX_LENGTH || inputChar == '\n')
    {    
      ParseInputMessage(clusterData);
      _inputLength = 0;
      _inputString = "";
      return;
    }
    
    _inputString += inputChar;
    _inputLength += 1;
  }
}

void SerialCommunicator::SendClusterState(ClusterData* clusterData)
{
  Serial.print(String(clusterData->State));
}

void SerialCommunicator::ParseInputMessage(ClusterData* clusterData)
{
  if (_inputString == "m")
  {
    SendClusterState(clusterData);
    return;
  }
  
  ParseSpeed(clusterData);
  ParseRevs(clusterData);
  ParseClusterMode(clusterData);
  ParseGear(clusterData);
}

void SerialCommunicator::ParseSpeed(ClusterData* clusterData)
{
  String speed = ParseInputMessage("s");
  if (speed != "")
  {
    clusterData->Speed = speed.toInt();
  }
}

void SerialCommunicator::ParseRevs(ClusterData* clusterData)
{
  String revs = ParseInputMessage("r");
  if (revs != "")
  {
    clusterData->Revs = revs.toInt();
  } 
}

void SerialCommunicator::ParseClusterMode(ClusterData* clusterData)
{
  String state = ParseInputMessage("m");
  if (state != "")
  {
    int mode = state.toInt();
    if (mode >= 2 && mode <= 3)
    {
      clusterData->State = static_cast<ClusterState>(mode);      
    }
    else
    {
      clusterData->State = Working;
    }

    SendClusterState(clusterData);
  }
}

void SerialCommunicator::ParseGear(ClusterData* clusterData)
{
  String gear = ParseInputMessage("g");
  if (gear.length() > 0)
  {
    clusterData->Gear = gear.charAt(0);  
  }
}

String SerialCommunicator::ParseInputMessage(String property)
{
  int startIndex = _inputString.indexOf(property + "="); 
  if (startIndex == -1)
  {
    return "";
  }
  
  int endIndex = _inputString.indexOf(';', startIndex);  
  if (endIndex == -1)
  {
    return "";
  } 
  
  return _inputString.substring(startIndex + property.length() + 1, endIndex);
}
