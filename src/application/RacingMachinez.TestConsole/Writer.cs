using System.IO.Ports;
using RacingMachinez.Contracts;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace RacingMachinez.TestConsole
{
    public class Writer : IDisposable
    {
        private readonly SerialPort _arduinoPort;
        private readonly GameDataQueryBuilder _queryBuilder = new GameDataQueryBuilder();
        private GameData _previousGameData = new GameData();

        public Writer()
        {
            _arduinoPort = new SerialPort("COM3");

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

    public class GameDataQueryBuilder
    {
        private readonly IDictionary<string, Func<GameData, string>> _dataBuilders = new Dictionary<string, Func<GameData, string>>
            {
                { "s", gameData => gameData.Speed.ToString() },
                { "r", gameData => gameData.Revs.ToString() },
                { "g", gameData => gameData.Gear.ToString() }
            };

        public string Build(GameData currentGameData, GameData previousGameData)
        {
            var stringBuilder = new StringBuilder();

            foreach (var builder in _dataBuilders)
            {
                var currentValue = builder.Value(currentGameData);
                var previousValue = builder.Value(previousGameData);

                if (currentGameData != previousGameData)
                {
                    stringBuilder.AppendFormat("{0}={1};", builder.Key, currentValue);
                }
            }

            return stringBuilder.ToString();
        }
    }
}