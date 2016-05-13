using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Timers;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Plugins.TestSample
{
    [Export(typeof (IGamePlugin))]
    public class TestSample : IGamePlugin
    {
        private StreamReader reader;

        private Timer _gameDataTimer;

        public event EventHandler<GameDataChangedEventArgs> GameDataChanged;

        public event EventHandler<GameStateChangedEventArgs> GameStateChanged;

        public GameData GameData { get; private set; }

        public string GameName => "Test Sample";

        public bool IsRunning => true;

        public TestSample()
        {
            _gameDataTimer = new Timer { Interval = 25, AutoReset = true, Enabled = true };
            _gameDataTimer.Elapsed += GameDataTimerElapsed;

            reader = new StreamReader("Sample.txt");
        }

        public void Dispose()
        {
            _gameDataTimer.Enabled = false;
            _gameDataTimer.Dispose();
            reader.Close();
            reader.Dispose();
        }

        private void GameDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (reader.EndOfStream)
            {
                reader.BaseStream.Position = 0;
            }

            var line = reader.ReadLine();
            var parts = line.Split(';');

            GameData = new GameData();
            if (parts.Length > 0)
            {
                GameData.Speed = short.Parse(parts[0]);
            }

            if (parts.Length > 1)
            {
                GameData.Revs = short.Parse(parts[1]);
            }

            if (parts.Length > 2)
            {
                GameData.Gear = parts[2][0];
            }

            GameDataChanged?.Invoke(this, new GameDataChangedEventArgs(GameData));
        }
    }
}