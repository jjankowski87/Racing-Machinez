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
    _tft->setTextColor(ILI9341_WHITE, ILI9341_BLACK);
    _tft->printAligned("welcome", gTextAlignMiddleCenter, gTextEraseFullLine);
    _isInitializationStarted = true;
  }
  
  return true;
}

void TftCluster::FinishInitialization()
{
  _tft->fillScreen(ILI9341_BLACK);
  _tft->setTextScale(3);
  _isInitializationStarted = false;  
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
  _tft->fillRect(80, 100, 80, 112, ILI9341_RED);
  _tft->fillRect(83, 103, 74, 106, ILI9341_BLACK);
  _tft->printAligned(String(gear), gTextAlignMiddleCenter);
}
