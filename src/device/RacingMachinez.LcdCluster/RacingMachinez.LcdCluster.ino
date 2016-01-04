#include <LiquidCrystal.h>
#include <AccelStepper.h>
#define HALFSTEP 8

AccelStepper speedStepper(HALFSTEP, 6, 8, 7, 9);
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

const int StringMaxLength = 64;
String inputString = "";           // a string to hold incoming data
boolean isStringComplete = false;  // whether the string is complete
int inputLength = 0;
float oneKmhSteps = 10.0f;

void setup()
{
  Serial.begin(9600);
  inputString.reserve(StringMaxLength);
  
  lcd.begin(16, 2);
  initializeSpeedStepper();
}

void initializeSpeedStepper()
{
  speedStepper.setCurrentPosition(0);
  speedStepper.setMaxSpeed(1000);
  speedStepper.setAcceleration(1000.0);
  speedStepper.setSpeed(1000);
}

void loop()
{
  if (isStringComplete) 
  {
    int speed = displaySpeed(inputString);
    displayRevs(inputString);

    inputString = "";
    isStringComplete = false;

    displaySpeedAnalog(speed);
  }
  
  speedStepper.run();
}

void displaySpeedAnalog(int speed)
{
    int stepsFromStart = oneKmhSteps * speed;    
    speedStepper.moveTo(stepsFromStart);
}

// Displays speed on LCD from formatted string: "s=120;"
// "speed:  xxx km/h"
int displaySpeed(String message)
{
  String speed = parseInputMessage(message, "s");
  if (speed == "-1")
  {
    return 0;
  }
  
  int speedLength = speed.length(); 
  if (speedLength == 0)
  {
    speed = "0";
    speedLength = 1;
  }
  else if (speedLength > 3)
  {
    speed = "999";
    speedLength = 3;
  }
  
  lcd.setCursor(0, 0);
  lcd.print("speed:");
  lcd.print("          "); 

  lcd.setCursor(11 - speedLength, 0);
  lcd.print(speed); 
  
  lcd.setCursor(12, 0);
  lcd.print("km/h"); 
  
  return speed.toInt();
}

// Displays revs on LCD from formatted string: "r=1200;"
// "revs: xxxxx  rpm"
void displayRevs(String message)
{ 
  String revs = parseInputMessage(message, "r");
  if (revs == "-1")
  {
    return;
  }
  
  int revsLength = revs.length();  
  if (revsLength == 0)
  {
    revs = "0";
    revsLength = 1;
  }
  else if (revsLength > 5)
  {
    revs = "99999";
    revsLength = 5;
  }
  
  lcd.setCursor(0, 1);
  lcd.print("revs:");
  lcd.print("           ");  

  lcd.setCursor(11 - revsLength, 1);
  lcd.print(revs); 
  
  lcd.setCursor(13, 1);
  lcd.print("rpm"); 
}

// Returns parsed value from input string in given property
// e.g. message = "sp=123;", property = "sp", returns 123
String parseInputMessage(String message, String property)
{
  int startIndex = message.indexOf(property + "="); 
  if (startIndex == -1)
  {
    return "-1";
  }
  
  int endIndex = message.indexOf(';', startIndex);  
  if (endIndex == -1)
  {
    return "-1";
  } 
  
  return message.substring(startIndex + property.length() + 1, endIndex);
}

// Reads string from serial input and stores in inputString variable.
// If reading is completed it sets inStringComplete variable to true.
void serialEvent()
{
  while (Serial.available() && inputLength <= StringMaxLength)
  {
    char inputChar = (char)Serial.read();
    if (inputChar == '\n')
    {
      isStringComplete = true;
      inputLength = 0;
      return;
    }
    
    inputString += inputChar;
    inputLength += 1;
  }
}
