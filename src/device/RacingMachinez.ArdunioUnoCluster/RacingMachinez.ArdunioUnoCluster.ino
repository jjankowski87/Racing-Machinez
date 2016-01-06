#include <LiquidCrystal.h>
#include <AccelStepper.h>
#include <Arduino.h>

#include "Controller.h"

Controller controller;

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
