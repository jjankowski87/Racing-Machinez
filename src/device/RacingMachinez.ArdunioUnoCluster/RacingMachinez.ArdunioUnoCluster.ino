#include <LiquidCrystal.h>
#include <AccelStepper.h>
#include <Arduino.h>

#include "StepperMotor.h"
#include "GameData.h"
#include "SerialReader.h"
#include "LcdCluster.h"

StepperMotor speedStepper(6, 7, 8, 9);
LcdCluster lcdCluster(12, 11, 5, 4, 3, 2);
SerialReader serialReader;

void setup()
{
  lcdCluster.Initialize();
  serialReader.Initialize();
}

void loop()
{
  if (serialReader.IsReadingComplete())
  {
    GameData gameData = serialReader.GetLastGameData();
    
    lcdCluster.DisplayGameData(gameData);
    speedStepper.MoveTo(gameData.Speed);
  }
  
  speedStepper.Run();
}

void serialEvent()
{
  serialReader.Read();
}
