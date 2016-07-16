using System;
using System.IO.Ports;
using System.Linq;
using RacingMachinez.Contracts;

namespace RacingMachinez.Plugins.Clusters.Auduino
{
    public class ComCommunicator : IDisposable
    {
        private readonly GameDataQueryBuilder _queryBuilder = new GameDataQueryBuilder();

        private GameData _previousGameData = new GameData();

        private SerialPort _arduinoPort;

        private bool _isDisposed = false;

        public ComCommunicator(ClusterConfiguration configuration)
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
            Dispose(true);
        }

        public ClusterState GetState()
        {
            _arduinoPort.WriteLine("m");
            var line = _arduinoPort.ReadLine();
            var nextData = _arduinoPort.ReadExisting();
            if (!string.IsNullOrWhiteSpace(nextData))
            {
                line = nextData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Last();
            }

            if (!string.IsNullOrWhiteSpace(line))
            {
                ClusterState clusterStateValue;
                if (Enum.TryParse(line, out clusterStateValue))
                {
                    return clusterStateValue;
                }
            }

            return ClusterState.Unknown;
        }

        public void SetState(ClusterState state)
        {
            _arduinoPort.WriteLine(string.Format("m={0};", (int)state));
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

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                _arduinoPort.Close();
                _arduinoPort = null;
            }

            _isDisposed = true;
        }
    }
}
