#include "LcdCluster.h"

LcdCluster::LcdCluster(int rsPin, int enablePin, int data4Pin, int data5Pin, int data6Pin, int data7Pin)
{
  _lcd = new LiquidCrystal(rsPin, enablePin, data4Pin, data5Pin, data6Pin, data7Pin);
  _lcd->begin(16, 2);
}

LcdCluster::~LcdCluster()
{
  delete _lcd;
}
  
void LcdCluster::Initialize()
{  
  _lcd->setCursor(0, 0);
  _lcd->print("speed:    0 km/h");

  _lcd->setCursor(0, 1);
  _lcd->print("revs:     0  rpm");
}

void LcdCluster::DisplayClusterData(ClusterData clusterData)
{
  if (clusterData.Speed != _previouslyDisplayed.Speed)
  {
    DisplaySpeed(NormalizeValue(clusterData.Speed, 0, 999));
  }
  
  if (clusterData.Revs != _previouslyDisplayed.Revs)
  {
    DisplayRevs(NormalizeValue(clusterData.Revs, 0, 30000));
  }
  
  _previouslyDisplayed = clusterData;
}

void LcdCluster::DisplayText(String text)
{
  _lcd->clear();
  _lcd->setCursor(0, 0);
  _lcd->print(text);
}

void LcdCluster::DisplaySpeed(int speed)
{
  _lcd->setCursor(8, 0);
  _lcd->print("   "); 

  _lcd->setCursor(11 - GetLength(speed), 0);
  _lcd->print(speed); 
}

void LcdCluster::DisplayRevs(int revs)
{ 
  _lcd->setCursor(6, 1);
  _lcd->print("     ");  

  _lcd->setCursor(11 - GetLength(revs), 1);
  _lcd->print(revs); 
}

int LcdCluster::GetLength(int value)
{
  if (value < 0)
  {
    value = -value;
  }
  
  if (value >= 10000)
  {
    return 5;
  }
  if (value >= 1000)
  {
    return 4;
  }
  if (value >= 100)
  {
    return 3;
  }
  if (value >= 10)
  {
    return 2;
  }
  
  return 1;
}

int LcdCluster::NormalizeValue(int value, int minValue, int maxValue)
{
  if (value < minValue)
  {
    return minValue;
  }
  if (value > maxValue)
  {
    return maxValue;
  }
  
  return value;
}
