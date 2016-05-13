using System;
using System.IO.Ports;
using RacingMachinez.Contracts;

namespace RacingMachinez.Plugins.Clusters.Auduino
{
    public class Writer : IDisposable
    {
        private readonly SerialPort _arduinoPort;
        private readonly GameDataQueryBuilder _queryBuilder = new GameDataQueryBuilder();
        private GameData _previousGameData = new GameData();

        public Writer(ClusterConfiguration configuration)
        {
            _arduinoPort = new SerialPort(configuration.PortName);

            _arduinoPort.BaudRate = 9600;
            _arduinoPort.Parity = Parity.None;
            _arduinoPort.StopBits = StopBits.One;
            _arduinoPort.DataBits = 8;
            _arduinoPort.Handshake = Handshake.None;
            _arduinoPort.RtsEnable = true;

            _arduinoPort.ReadTimeout = 100;
            _arduinoPort.WriteTimeout = 100;
            _arduinoPort.Open();
        }

        public void Dispose()
        {
            _arduinoPort.Close();
        }

        public void Send(GameData gameData)
        {
            var dataString = _queryBuilder.Build(gameData, _previousGameData);
            if (dataString != string.Empty)
            {
                _arduinoPort.WriteLine(dataString);
            }

            _previousGameData = (GameData)gameData.Clone();
        }
    }
}
