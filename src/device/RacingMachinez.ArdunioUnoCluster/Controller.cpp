#include "Controller.h"
#include "Converters.h"
#include "ClusterData.h"

Controller::Controller()
{
  _revsStepper = new StepperMotor(8, 9, 6, 7);
  _lcdCluster = new LcdCluster(12, 11, 5, 4, 3, 2);
  _serialReader = new SerialReader();
  _initializationPhase = 0;
}

Controller::~Controller()
{
  delete _revsStepper;
  delete _lcdCluster;
  delete _serialReader;
}

void Controller::Setup()
{
  _serialReader->Initialize();
  _revsStepper->SetConvertFunction(&Converters::ConvertRevsToAngle);
}

void Controller::Update()
{
  ClusterData clusterData = _serialReader->GetLastClusterData();
  
  if (_previousState == Calibration && clusterData.State != Calibration)
  {
    _revsStepper->Reset();
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
  _revsStepper->Run();
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
    _revsStepper->MoveTo(8000);
    _initializationPhase += 1;
  }
  else if (_initializationPhase == 1)
  {
    if (!_revsStepper->IsRunning())
    {
      _revsStepper->MoveTo(0);
      _initializationPhase += 1;
    }
  }
  else if (_initializationPhase == 2)
  {
    if (!_revsStepper->IsRunning())
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
    _revsStepper->Move(clusterData.Speed); 
  }
}

void Controller::UpdateWorking(ClusterData clusterData)
{
  if (_previousState != Working)
  {
    _lcdCluster->Initialize();
  }
  
  _lcdCluster->DisplayClusterData(clusterData);
  _revsStepper->MoveTo(clusterData.Revs);
}
