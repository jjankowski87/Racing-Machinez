#include "Controller.h"
#include "Converters.h"
#include "ClusterData.h"
#include "StepperMotor.h"
#include "TftCluster.h"

Controller::Controller(ClusterItems clusterItems)
{
  _serialReader = new SerialReader();
  _clusterData.State = Initialization;
  
  InitializeClusterItems(clusterItems);
}

Controller::~Controller()
{
  for (int i = 0; i < _numberOfClusterItems; i++)
  {
    delete _clusterItems[i];
  }
  
  delete [] _clusterItems;
  delete _serialReader;
}

void Controller::Setup()
{
  _serialReader->Initialize();
}

void Controller::Update()
{
  if (_clusterData.State == Initialization)
  {
    PerformClusterInitialization();
  }
  
  for (int i = 0; i < _numberOfClusterItems; i++)
  {
    _clusterItems[i]->UpdateData(_clusterData);
  } 
}

void Controller::SerialEvent()
{
  if (_clusterData.State != Initialization)
  {
    _serialReader->Read(&_clusterData);
  }
}

void Controller::InitializeClusterItems(ClusterItems clusterItems)
{
  _numberOfClusterItems = 0;
  for (int i = 0; i < 3; i++)
  {
    if (((clusterItems >> i) % 2) == 1)
    {
      _numberOfClusterItems++;
    }
  }
  
  _clusterItems = new IClusterItem*[_numberOfClusterItems];  
  int itemIndex = 0;
  if (clusterItems & Tachometer)
  {    
    _clusterItems[itemIndex++] = new StepperMotor(2, 3, 4, 5, &Converters::ConvertRevsToAngle, SPEED_AND_REVS_SCALE_ANGLE);
  }
  
  if (clusterItems & Speedometer)
  {
    _clusterItems[itemIndex++] = new StepperMotor(14, 15, 16, 17, &Converters::ConvertSpeedToAngle, SPEED_AND_REVS_SCALE_ANGLE); 
  }
  
  if (clusterItems & Tft)
  {
    _clusterItems[itemIndex++] = new TftCluster(10, 9, 8);
  }
}

void Controller::PerformClusterInitialization()
{
  boolean isInitializationFinished = true;
  for (int i = 0; i < _numberOfClusterItems; i++)
  {
    isInitializationFinished = _clusterItems[i]->PerformInitialization() && isInitializationFinished;
  }
  
  if (isInitializationFinished)
  {
    for (int i = 0; i < _numberOfClusterItems; i++)
    {
      _clusterItems[i]->FinishInitialization();
    }  
    
    _clusterData.State = Working;
  } 
}
