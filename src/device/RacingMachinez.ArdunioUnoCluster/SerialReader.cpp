#include "SerialReader.h"

SerialReader::SerialReader()
{ 
  _inputString.reserve(STRING_MAX_LENGTH);
  _inputString = "";
  _inputLength = 0; 
}

void SerialReader::Initialize()
{
  Serial.begin(9600);
}

void SerialReader::Read(ClusterData* clusterData)
{
  while (Serial.available())
  {
    char inputChar = (char)Serial.read();
    if (_inputLength >= STRING_MAX_LENGTH || inputChar == '\n')
    {    
      ParseClusterData(clusterData);
      _inputLength = 0;
      _inputString = "";
      return;
    }
    
    _inputString += inputChar;
    _inputLength += 1;
  }
}

void SerialReader::ParseClusterData(ClusterData* clusterData)
{
  ParseSpeed(clusterData);
  ParseRevs(clusterData);
  ParseClusterMode(clusterData);
  ParseGear(clusterData);
}

void SerialReader::ParseSpeed(ClusterData* clusterData)
{
  String speed = ParseInputMessage("s");
  if (speed != "")
  {
    clusterData->Speed = speed.toInt();
  }
}

void SerialReader::ParseRevs(ClusterData* clusterData)
{
  String revs = ParseInputMessage("r");
  if (revs != "")
  {
    clusterData->Revs = revs.toInt();
  } 
}

void SerialReader::ParseClusterMode(ClusterData* clusterData)
{
  String state = ParseInputMessage("m");
  if (state != "")
  {
    int mode = state.toInt();
    if (mode >= 1 && mode <= 3)
    {
      clusterData->State = static_cast<ClusterState>(mode);      
    }
    else
    {
      clusterData->State = Unknown;
    }
  }
}

void SerialReader::ParseGear(ClusterData* clusterData)
{
  String gear = ParseInputMessage("g");
  if (gear.length() > 0)
  {
    clusterData->Gear = gear.charAt(0);  
  }
}

String SerialReader::ParseInputMessage(String property)
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
