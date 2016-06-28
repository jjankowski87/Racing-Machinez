#include <AccelStepper.h>
#include <Arduino.h>
#include <SPI.h>
#include <ILI9341_due.h>
#include <ILI9341_due_config.h>

#include "Enums.h"
#include "Controller.h"

Controller controller(Tachometer | Speedometer | Tft);

boolean isInitialized = false;

void setup()
{
  controller.Setup();
}

void loop()
{
  if (IsDeviceInitialized())
  {
    controller.Update();  
  }
}

void serialEvent()
{
  controller.SerialEvent();
}

bool IsDeviceInitialized()
{
  if (!isInitialized)
  {
    if (millis() > 1000)
    {
      isInitialized = true;
    }
  }

  return isInitialized;
}

