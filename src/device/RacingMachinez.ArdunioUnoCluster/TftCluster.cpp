#include "TftCluster.h"
#include "DigitalNumbersFont.h"

TftCluster::TftCluster(int csPin, int dcPin, int rstPin)
{
  _tft = new ILI9341_due(csPin, dcPin, rstPin);
  _isInitializationStarted = false;
  _isGearDisplayPrepared = false;
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
    _tft->setFont(DigitalNumbersFont);
    _tft->setTextColor(ILI9341_WHITE, ILI9341_BLACK);
    _tft->printAligned("HELLO", gTextAlignMiddleCenter, gTextEraseFullLine);
    _isInitializationStarted = true;
  }
  
  return true;
}

void TftCluster::FinishInitialization()
{
  _tft->fillScreen(ILI9341_BLACK);
  _tft->fillRect(80, 100, 80, 112, ILI9341_RED);
  _tft->fillRect(83, 103, 74, 106, ILI9341_BLACK);
  
  _tft->setTextScale(3);
  _isInitializationStarted = false;  
}

void TftCluster::UpdateData(ClusterData clusterData)
{
  if (_isInitializationStarted)
  {
    return;
  }
  
  if (_previousGear != clusterData.Gear)
  {
    if (!_isGearDisplayPrepared)
    {
      _tft->fillRect(93, 114, 52, 78, ILI9341_BLACK);
      _isGearDisplayPrepared = true;
    }
    else
    {
      _tft->printAligned(String(clusterData.Gear), gTextAlignMiddleCenter);
      _previousGear = clusterData.Gear;
      _isGearDisplayPrepared = false;
    }
  }
}
