#ifndef LcdCluster_h
#define LcdCluster_h

#include <LiquidCrystal.h>
#include "GameData.h"

class LcdCluster
{
public:
  LcdCluster(int rsPin, int enablePin, int data4Pin, int data5Pin, int data6Pin, int data7Pin);
  ~LcdCluster();
  
  void Initialize();
  void DisplayGameData(GameData gameData);
  
private:
  LiquidCrystal* _lcd;
  GameData _previouslyDisplayed;
  
  void DisplaySpeed(int speed);
  void DisplayRevs(int revs);
  int GetLength(int value);
};

#endif
