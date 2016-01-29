#include "Controller.h"
#include "Converters.h"
#include "ClusterData.h"

// TODO: bit configuration for enabling particular cluster items: REVS | SPEED | LCD
Controller::Controller()
{
  _serialReader = new SerialReader();
  
  _clusterItems = new IClusterItem*[NUMBER_OF_CLUSTER_ITEMS];
  _clusterItems[0] = new StepperMotor(2, 3, 4, 5, &Converters::ConvertRevsToAngle, SPEED_AND_REVS_SCALE_ANGLE);
  _clusterItems[1] = new StepperMotor(14, 15, 16, 17, &Converters::ConvertSpeedToAngle, SPEED_AND_REVS_SCALE_ANGLE);
  
  _clusterData.State = Initialization;
}

Controller::~Controller()
{
  for (int i = 0; i < NUMBER_OF_CLUSTER_ITEMS; i++)
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
  
  for (int i = 0; i < NUMBER_OF_CLUSTER_ITEMS; i++)
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

void Controller::PerformClusterInitialization()
{
  boolean isHelloFinished = true;
  for (int i = 0; i < NUMBER_OF_CLUSTER_ITEMS; i++)
  {
    isHelloFinished = _clusterItems[i]->Hello() && isHelloFinished;
  }
  
  if (isHelloFinished)
  {  
    _clusterData.State = Working;
  } 
}
