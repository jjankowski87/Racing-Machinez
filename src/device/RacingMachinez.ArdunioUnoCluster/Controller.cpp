#include "Controller.h"
#include "Converters.h"
#include "ClusterData.h"

Controller::Controller()
{
  _speedStepper = new StepperMotor(6, 7, 8, 9);
  _lcdCluster = new LcdCluster(12, 11, 5, 4, 3, 2);
  _serialReader = new SerialReader();
  _initializationPhase = 0;
}

Controller::~Controller()
{
  delete _speedStepper;
  delete _lcdCluster;
  delete _serialReader;
}

void Controller::Setup()
{
  _serialReader->Initialize();
  _speedStepper->SetConvertFunction(&Converters::ConvertSpeedToAngle);
}

void Controller::Update()
{
  ClusterData clusterData = _serialReader->GetLastClusterData();
  
  if (_previousState == Calibration && clusterData.State != Calibration)
  {
    _speedStepper->Reset();
  }
  
  switch (clusterData.State)
  {
    case Initialization:
      UpdateInitialization();
      break;
    case Calibration:   
      UpdateCalibration(clusterData);
      _serialReader->ResetClusterData();
      break;
    case Working:
      UpdateWorking(clusterData);
      break;
    default:  
      _lcdCluster->DisplayText("Other");
      return;
  }
  
  _previousState = clusterData.State;
  _speedStepper->Run();
}

void Controller::SerialEvent()
{
  _serialReader->Read();
}

void Controller::UpdateInitialization()
{
  if (_previousState != Initialization)
  {
    _lcdCluster->DisplayText("Hello");
  }
  
  if (_initializationPhase == 0)
  {
    _speedStepper->MoveTo(260);
    _initializationPhase += 1;
  }
  else if (_initializationPhase == 1)
  {
    if (!_speedStepper->IsRunning())
    {
      _speedStepper->MoveTo(0);
      _initializationPhase += 1;
    }
  }
  else if (_initializationPhase == 2)
  {
    if (!_speedStepper->IsRunning())
    {
      _serialReader->SetState(Working);
      _initializationPhase = 0;
    }
  }
}

void Controller::UpdateCalibration(ClusterData clusterData)
{
  if (_previousState != Calibration)
  {
    _lcdCluster->DisplayText("Calibration");
  }
  
  if (clusterData.Speed != 0)
  {
    _speedStepper->Move(clusterData.Speed); 
  }
}

void Controller::UpdateWorking(ClusterData clusterData)
{
  if (_previousState != Working)
  {
    _lcdCluster->Initialize();
  }
  
  _lcdCluster->DisplayClusterData(clusterData);
  _speedStepper->MoveTo(clusterData.Speed);
}
