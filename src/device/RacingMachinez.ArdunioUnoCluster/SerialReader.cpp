#include "SerialReader.h"

SerialReader::SerialReader()
{ 
  _inputString.reserve(STRING_MAX_LENGTH);
  _inputString = "";
  _inputLength = 0; 
  
  _clusterData.State = Initialization;
  ResetClusterData();
}

void SerialReader::Initialize()
{
  Serial.begin(9600);
}

void SerialReader::Read()
{
  while (Serial.available())
  {
    char inputChar = (char)Serial.read();
    if (_inputLength >= STRING_MAX_LENGTH || inputChar == '\n')
    {    
      ParseClusterData();
      _inputLength = 0;
      _inputString = "";
      return;
    }
    
    _inputString += inputChar;
    _inputLength += 1;
  }
}

ClusterData SerialReader::GetLastClusterData()
{ 
  return _clusterData;
}

void SerialReader::SetState(ClusterState state)
{
  _clusterData.State = state;
}

void SerialReader::ParseClusterData()
{
  ParseSpeed();
  ParseRevs();
  ParseClusterMode();
}

void SerialReader::ParseSpeed()
{
  String speed = ParseInputMessage("s");
  if (speed != "")
  {
    _clusterData.Speed = speed.toInt();
  }
}

void SerialReader::ParseRevs()
{
  String revs = ParseInputMessage("r");
  if (revs != "")
  {
    _clusterData.Revs = revs.toInt();
  } 
}

void SerialReader::ParseClusterMode()
{
  String state = ParseInputMessage("m");
  if (state != "")
  {
    ClusterState previousState = _clusterData.State;
    
    int mode = state.toInt();
    if (mode >= 1 && mode <= 3)
    {
      _clusterData.State = static_cast<ClusterState>(mode);      
    }
    else
    {
      _clusterData.State = Unknown;
    }
    
    if (previousState != _clusterData.State)
    {
      ResetClusterData();
    }
  }
}

void SerialReader::ResetClusterData()
{
  _clusterData.Speed = 0;
  _clusterData.Revs = 0;
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
