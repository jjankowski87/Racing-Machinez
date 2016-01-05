#ifndef SerialReader_h
#define SerialReader_h

#include "GameData.h"
#include <Arduino.h>

class SerialReader
{
public:
  SerialReader();
  
  void Initialize();
  void Read();
  bool IsReadingComplete();
  GameData GetLastGameData();
  
private:
  const int STRING_MAX_LENGTH = 64;
  bool _isReadingComplete;
  String _inputString;
  int _inputLength;
  GameData _gameData;
 
  void ParseGameData();
  void ParseSpeed();
  void ParseRevs();
  String ParseInputMessage(String property);
};

#endif
