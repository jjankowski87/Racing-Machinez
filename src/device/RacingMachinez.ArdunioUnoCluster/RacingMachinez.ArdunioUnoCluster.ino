#include <AccelStepper.h>
#include <Arduino.h>
#include <SPI.h>
#include <ILI9341_due.h>
#include <ILI9341_due_config.h>

#include "Enums.h"
#include "Controller.h"

Controller controller(Tachometer | Speedometer | Tft);

void setup()
{
  controller.Setup();
}

void loop()
{
  controller.Update();
}

void serialEvent()
{
  controller.SerialEvent();
}
