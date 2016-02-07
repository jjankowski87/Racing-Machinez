using System.IO.Ports;
using RacingMachinez.Contracts;

namespace RacingMachinez.TestConsole
{
    public class Writer
    {
        private readonly SerialPort _arduinoPort;

        public Writer()
        {
            _arduinoPort = new SerialPort("COM3");

            _arduinoPort.BaudRate = 9600;
            _arduinoPort.Parity = Parity.None;
            _arduinoPort.StopBits = StopBits.One;
            _arduinoPort.DataBits = 8;
            _arduinoPort.Handshake = Handshake.None;
            _arduinoPort.RtsEnable = true;
        }

        public void Send(GameData gameData)
        {
            try
            {
                _arduinoPort.Open();
                // TODO: send gear only when it was changed
                _arduinoPort.WriteLine(string.Format("s={0};r={1};g={2};", gameData.Speed, gameData.Revs, gameData.Gear));
            }
            finally
            {
                _arduinoPort.Close();
            }
        }
    }
}