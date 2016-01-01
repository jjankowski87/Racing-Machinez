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
                _arduinoPort.WriteLine(string.Format("s={0};r={1};", gameData.Speed, gameData.Revs));
            }
            finally
            {
                _arduinoPort.Close();
            }
        }
    }
}