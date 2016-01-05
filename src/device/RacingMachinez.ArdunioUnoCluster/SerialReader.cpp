#include "SerialReader.h"

SerialReader::SerialReader()
{ 
  _inputString.reserve(STRING_MAX_LENGTH);
  _isReadingComplete = false;
  _inputString = "";
  _inputLength = 0; 
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
      ParseGameData();
      _isReadingComplete = true;
      _inputLength = 0;
      _inputString = "";
      return;
    }
    
    _inputString += inputChar;
    _inputLength += 1;
  }
}

bool SerialReader::IsReadingComplete()
{
  return _isReadingComplete;
}

GameData SerialReader::GetLastGameData()
{
  _isReadingComplete = false;   
  return _gameData;
}

void SerialReader::ParseGameData()
{
  ParseSpeed();
  ParseRevs();
}

void SerialReader::ParseSpeed()
{
  String speed = ParseInputMessage("s");
  if (speed != "")
  {
    int intSpeed = speed.toInt();
    if (intSpeed < 0)
    {
      intSpeed = 0;
    }
    else if (intSpeed > 999)
    {
      intSpeed = 999;
    }
    
    _gameData.Speed = intSpeed;
  }
}

void SerialReader::ParseRevs()
{
  String revs = ParseInputMessage("r");
  if (revs != "")
  {
    int intRevs = revs.toInt();
    if (intRevs < 0)
    {
      intRevs = 0;
    }
    else if (intRevs > 99999)
    {
      intRevs = 99999;
    }
    
    _gameData.Revs = intRevs;
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
