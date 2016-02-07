#include "TftCluster.h"
#include "fonts\roboto32.h"

TftCluster::TftCluster(int csPin, int dcPin, int rstPin)
{
  _tft = new ILI9341_due(csPin, dcPin, rstPin);
  _isInitializationStarted = false;
}

TftCluster::~TftCluster()
{
  delete _tft;
}
  
bool TftCluster::PerformInitialization()
{  
  if (!_isInitializationStarted)
  {
    _tft->begin();
    _tft->fillScreen(ILI9341_BLACK);    
    _tft->setFont(roboto32);
    _tft->setTextColor(ILI9341_RED, ILI9341_BLACK);
    _tft->fillRect(0, 76, 240, 4, ILI9341_RED);
    _tft->fillRect(0, 241, 240, 4, ILI9341_RED);
    _tft->printAligned("welcome", gTextAlignMiddleCenter, gTextEraseFullLine);
    _isInitializationStarted = true;
  }
  
  return true;
}

void TftCluster::FinishInitialization()
{
  _isInitializationStarted = false;  
  DisplayGear('N');
}

void TftCluster::UpdateData(ClusterData clusterData)
{
  if (!_isInitializationStarted && _previousGear != clusterData.Gear)
  {
    DisplayGear(clusterData.Gear);   
    _previousGear = clusterData.Gear;
  }
}

void TftCluster::DisplayGear(char gear)
{
  _tft->setTextScale(3);
  _tft->printAligned(String(gear), gTextAlignMiddleCenter, gTextEraseFullLine);
}
