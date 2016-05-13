using System;
using System.Timers;
using System.ComponentModel.Composition;
using System.IO.MemoryMappedFiles;
using RacingMachinez.Contracts;
using RacingMachinez.Contracts.Plugins;

namespace RacingMachinez.Plugins.ProjectCars
{
    [Export(typeof (IGamePlugin))]
    public class ProjectCarsPlugin : IGamePlugin
    {
        private const string MemoryFileName = "$pcars$";

        private readonly ProjectCarsGameDataReader _dataReader;

        private readonly Timer _gameDataTimer;

        public event EventHandler<GameDataChangedEventArgs> GameDataChanged;

        public event EventHandler<GameStateChangedEventArgs> GameStateChanged;

        public string GameName => "Project CARS";

        public bool IsRunning { get; private set; }

        public GameData GameData { get; private set; }

        public ProjectCarsPlugin()
        {
            _dataReader = new ProjectCarsGameDataReader();

            _gameDataTimer = new Timer { Interval = 25, AutoReset = true, Enabled = true };
            _gameDataTimer.Elapsed += GameDataTimerElapsed;
        }

        public void Dispose()
        {
            _gameDataTimer.Enabled = false;
            _gameDataTimer.Dispose();
        }

        private void GameDataTimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (var file = MemoryMappedFile.OpenExisting(MemoryFileName))
                {
                    using (var viewAccessor = file.CreateViewAccessor())
                    {
                        ChangeGameState(true);

                        var gameData = ProjectCarsGameDataConverter.ConvertGameData(_dataReader.ReadData(viewAccessor));
                        if (!gameData.Equals(GameData))
                        {
                            GameData = gameData;
                            FireGameDataChangedEvent();
                        }
                    }
                }
            }
            catch (Exception)
            {
                ChangeGameState(false);
            }
        }

        private void ChangeGameState(bool isRunning)
        {
            if (isRunning == IsRunning)
            {
                return;
            }

            IsRunning = isRunning;
            FireGameStateChangedEvent();
        }

        private void FireGameDataChangedEvent()
        {
            GameDataChanged?.Invoke(this, new GameDataChangedEventArgs(GameData));
        }

        private void FireGameStateChangedEvent()
        {
            GameStateChanged?.Invoke(this, new GameStateChangedEventArgs(IsRunning));
        }
    }
}